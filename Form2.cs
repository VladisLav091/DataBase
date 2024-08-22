using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LAB7_BDBD
{
    public partial class Form2 : Form
    {
        OleDbConnection cn = new OleDbConnection(
        @"Provider=Microsoft.ACE.OLEDB.12.0;" +
        @"Data Source=""C:\Users\Vladislav888\Desktop\lab7.accdb"""
        );
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SetDetailTextBoxesEnabled(false);
            textBox16.Enabled = true; // Поле для номера лечебного заведения активно
            textBox17.Enabled = true; // Поле для табельного номера врача активно
        }
        private bool CheckHospitalExists(int numhospital)
        {
            bool exists = false;
            cn.Open();
            try
            {
                OleDbCommand checkHospitalCmd = new OleDbCommand("SELECT COUNT(*) FROM Врач WHERE [Номер лечебного заведения] = @numhospital", cn);
                checkHospitalCmd.Parameters.AddWithValue("@numhospital", numhospital);
                exists = (Convert.ToInt32(checkHospitalCmd.ExecuteScalar()) > 0);
            }
            finally
            {
                cn.Close();
            }
            return exists;
        }
        private void Add_new_Employee(String family, String name, int numhospital, int numdoctor, String surname, String special, int numbercabinet)
        {
            cn.Open();
            try
            {
                // Проверка на наличие дубликатов в базе данных
                OleDbCommand checkCmd = new OleDbCommand();
                checkCmd.Connection = cn;
                checkCmd.CommandText =
                "SELECT COUNT(*) FROM Врач WHERE [Номер лечебного заведения] = @numhospital AND [Табельный номер врача] = @numdoctor";
                checkCmd.Parameters.AddWithValue("@numhospital", numhospital);
                checkCmd.Parameters.AddWithValue("@numdoctor", numdoctor);

                int existingRecordsCount = (int)checkCmd.ExecuteScalar();

                if (existingRecordsCount > 0)
                {
                    MessageBox.Show("Врач с такими номером лечебного заведения и табельным номером врача уже существует в базе данных.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "INSERT INTO Врач ( [Номер лечебного заведения], [Табельный номер врача], Фамилия, Имя, Отчество, Специальность, [Номер кабинета] ) VALUES (@numhospital,@numdoctor,@Family, @Name,@surname,@special,@numbercabinet)";
                cmd.Parameters.AddWithValue("@numhospital", numhospital);
                cmd.Parameters.AddWithValue("@numdoctor", numdoctor);
                cmd.Parameters.AddWithValue("@Family", family);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@special", special);
                cmd.Parameters.AddWithValue("@numbercabinet", numbercabinet);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Врач успешно добавлен в базу данных.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                cn.Close();
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            string family = textBox1.Text;
            string name = textBox2.Text;
            string surname = textBox5.Text;
            string special = textBox6.Text;
            int numhospital;
            int numdoctor;
            int numbercabinet;

            try
            {
                numhospital = int.Parse(textBox3.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Поле 'Номер лечебного заведения' должно быть числовым или не должно быть пустым.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Число в поле 'Номер лечебного заведения' слишком большое.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                numdoctor = int.Parse(textBox4.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Поле 'Табельный номер врача' должно быть числовым.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Число в поле 'Табельный номер врача' слишком большое.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                numbercabinet = int.Parse(textBox7.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Поле 'Номер кабинета' должно быть числовым.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Число в поле 'Номер кабинета' слишком большое.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка на пустые значения для полей, которые не могут быть пустыми
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Поле 'Номер лечебного заведения' не должно быть пустым.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Поле 'Табельный номер врача' не должно быть пустым.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!CheckHospitalExists(numhospital))
            {
                MessageBox.Show("Лечебного заведения с таким номером не существует в базе данных.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Теперь, когда все проверки пройдены, можно добавлять нового сотрудника
            Add_new_Employee(family, name, numhospital, numdoctor, surname, special, numbercabinet);
        }
        private int GetEmployeeCountByFamily(string family)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM Врач WHERE Фамилия = @Family", cn);
                cmd.Parameters.AddWithValue("@Family", family);
                int count = (int)cmd.ExecuteScalar();
                return count;
            }
            finally
            {
                cn.Close();
            }
        }

        private void Delete_Employee(string family)
        {
            int employeeCount = GetEmployeeCountByFamily(family);

            if (employeeCount == 0)
            {
                MessageBox.Show("Врач с такой фамилией не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (employeeCount > 1)
            {
                // Запрос табельного номера у пользователя, можно использовать, например, InputBox или другой способ ввода
                string tabNumber = Microsoft.VisualBasic.Interaction.InputBox("Введите табельный номер врача:", "Уточнение данных", "", -1, -1);

                // Проверяем, что номер введен
                if (string.IsNullOrWhiteSpace(tabNumber))
                {
                    MessageBox.Show("Табельный номер не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Выполняем удаление по фамилии и табельному номеру
                DeleteEmployeeByTabNumber(family, tabNumber);
            }
            else
            {
                // Удаление врача по фамилии, если он один
                DeleteEmployeeByFamily(family);
            }
        }
        private void DeleteEmployeeByFamily(string family)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand("DELETE FROM Врач WHERE Фамилия = @Family", cn);
                cmd.Parameters.AddWithValue("@Family", family);
                int rowsAffected = cmd.ExecuteNonQuery();
                MessageBox.Show(rowsAffected > 0 ? "Запись успешно удалена!" : "Запись не найдена. Ничего не было удалено.",
                                rowsAffected > 0 ? "Успех" : "Ошибка",
                                MessageBoxButtons.OK,
                                rowsAffected > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
        }

        private void DeleteEmployeeByTabNumber(string family, string tabNumber)
        {
            cn.Open();
            try
            {
                // Проверяем, существует ли врач с такой фамилией и табельным номером
                OleDbCommand checkComboCmd = new OleDbCommand("SELECT COUNT(*) FROM Врач WHERE Фамилия = @Family AND [Табельный номер врача] = @TabNumber", cn);
                checkComboCmd.Parameters.AddWithValue("@Family", family);
                checkComboCmd.Parameters.AddWithValue("@TabNumber", tabNumber);

                int comboExists = Convert.ToInt32(checkComboCmd.ExecuteScalar());
                if (comboExists > 0)
                {
                    // Запрос дополнительных данных у пользователя - номера лечебного учреждения
                    string medicalInstitutionNumber = Microsoft.VisualBasic.Interaction.InputBox("Введите номер лечебного заведения:", "Уточнение данных", "", -1, -1);

                    // Проверяем, что номер лечебного учреждения введен
                    if (string.IsNullOrWhiteSpace(medicalInstitutionNumber))
                    {
                        MessageBox.Show("Номер лечебного учреждения не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Проверяем, существует ли запись с указанными фамилией, табельным номером и номером лечебного учреждения
                    OleDbCommand checkInstitutionCmd = new OleDbCommand("SELECT COUNT(*) FROM Врач WHERE Фамилия = @Family AND [Табельный номер врача] = @TabNumber AND [Номер лечебного заведения] = @MedicalInstitutionNumber", cn);
                    checkInstitutionCmd.Parameters.AddWithValue("@Family", family);
                    checkInstitutionCmd.Parameters.AddWithValue("@TabNumber", tabNumber);
                    checkInstitutionCmd.Parameters.AddWithValue("@MedicalInstitutionNumber", medicalInstitutionNumber);

                    int institutionExists = Convert.ToInt32(checkInstitutionCmd.ExecuteScalar());
                    if (institutionExists == 0)
                    {
                        // Запись с такой комбинацией данных не найдена
                        MessageBox.Show("Запись с такими данными не найдена. Проверьте корректность введенного номера лечебного учреждения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Если все проверки пройдены, выполняем удаление
                    OleDbCommand cmd = new OleDbCommand("DELETE FROM Врач WHERE Фамилия = @Family AND [Табельный номер врача] = @TabNumber AND [Номер лечебного заведения] = @MedicalInstitutionNumber", cn);
                    cmd.Parameters.AddWithValue("@Family", family);
                    cmd.Parameters.AddWithValue("@TabNumber", tabNumber);
                    cmd.Parameters.AddWithValue("@MedicalInstitutionNumber", medicalInstitutionNumber);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    MessageBox.Show(rowsAffected > 0 ? "Запись успешно удалена!" : "Ошибка при удалении записи. Убедитесь, что введены корректные данные.", "Успех", MessageBoxButtons.OK, rowsAffected > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                }
                else
                {
                    // Врач с такой комбинацией фамилии и табельного номера не найден
                    MessageBox.Show("Врач с такой комбинацией фамилии и табельного номера не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                cn.Close();
            }
        }


        private void Update_Employee(int numhospital, int numdoctor, string family, string name, string surname, string special, int numbercabinet)
        {
            cn.Open();
            try
            {
                // Здесь код для обновления данных врача в базе данных
                // Пример обновления данных:
                OleDbCommand cmd = new OleDbCommand("UPDATE Врач SET Фамилия = @family, Имя = @name, Отчество = @surname, Специальность = @special, [Номер кабинета] = @numbercabinet WHERE [Номер лечебного заведения] = @numhospital AND [Табельный номер врача] = @numdoctor", cn);
                cmd.Parameters.AddWithValue("@family", family);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@special", special);
                cmd.Parameters.AddWithValue("@numbercabinet", numbercabinet);
                cmd.Parameters.AddWithValue("@numhospital", numhospital);
                cmd.Parameters.AddWithValue("@numdoctor", numdoctor);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Данные успешно обновлены.", "Обновление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Нет данных для обновления.", "Обновление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            finally
            {
                cn.Close();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Delete_Employee(textBox8.Text);
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Здесь добавьте код для сбора данных из текстовых полей
            string family = textBox15.Text;
            string name = textBox14.Text;
            string surname = textBox11.Text;
            string special = textBox10.Text;
            int numhospital = int.Parse(textBox16.Text);
            int numdoctor = int.Parse(textBox17.Text);
            int numbercabinet;
            try
            {
                numbercabinet = int.Parse(textBox9.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Поле 'Номер кабинета' должно быть числовым.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Теперь вызовите метод обновления
            Update_Employee(numhospital, numdoctor, family, name, surname, special, numbercabinet);
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        private void SetDetailTextBoxesEnabled(bool enabled)
        {
            textBox9.Enabled = enabled;
            textBox10.Enabled = enabled;
            textBox11.Enabled = enabled;
            textBox14.Enabled = enabled;
            textBox15.Enabled = enabled;
            // ... Включить или выключить остальные текстовые поля ...
            button3.Enabled = enabled; // Предполагается, что это кнопка для обновления данных
        }
        private void FillEmployeeDetails(int numHospital, int numDoctor)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand("SELECT Фамилия, Имя, Отчество, Специальность, [Номер кабинета] FROM Врач WHERE [Номер лечебного заведения] = @numhospital AND [Табельный номер врача] = @numdoctor", cn);
                cmd.Parameters.AddWithValue("@numhospital", numHospital);
                cmd.Parameters.AddWithValue("@numdoctor", numDoctor);

                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        textBox15.Text = reader["Фамилия"].ToString();
                        textBox14.Text = reader["Имя"].ToString();
                        textBox11.Text = reader["Отчество"].ToString();
                        textBox10.Text = reader["Специальность"].ToString();
                        textBox9.Text = reader["Номер кабинета"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Врач не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            finally
            {
                cn.Close();
            }
        }
        private bool CheckIfEmployeeExists(int numHospital, int numDoctor)
        {
            bool exists = false;
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM Врач WHERE [Номер лечебного заведения] = @numhospital AND [Табельный номер врача] = @numdoctor", cn);
                cmd.Parameters.AddWithValue("@numhospital", numHospital);
                cmd.Parameters.AddWithValue("@numdoctor", numDoctor);

                exists = (int)cmd.ExecuteScalar() > 0;
            }
            finally
            {
                cn.Close();
            }
            return exists;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int numHospital;
            int numDoctor;

            if (!int.TryParse(textBox16.Text, out numHospital))
            {
                MessageBox.Show("Поле 'Номер лечебного заведения' должно быть числовым.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBox17.Text, out numDoctor))
            {
                MessageBox.Show("Поле 'Табельный номер врача' должно быть числовым.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CheckIfEmployeeExists(numHospital, numDoctor))
            {
                FillEmployeeDetails(numHospital, numDoctor);
                SetDetailTextBoxesEnabled(true);
            }
            else
            {
                MessageBox.Show("Врач с такими номерами не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
