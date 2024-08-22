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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LAB7_BDBD
{
    public partial class FormChangeDiagnoz : Form
    {
        OleDbConnection cn = new OleDbConnection(
        @"Provider=Microsoft.ACE.OLEDB.12.0;" +
        @"Data Source=""C:\Users\Vladislav888\Desktop\lab7.accdb"""
        );
        public FormChangeDiagnoz(OleDbConnection connection)
        {
            InitializeComponent();
            cn = connection;
        }
        private void Add_new_Employee(int id, String named, String lechenie)
        {
            cn.Open();
            try
            {
                OleDbCommand checkCmd = new OleDbCommand();
                checkCmd.Connection = cn;
                checkCmd.CommandText =
                "SELECT COUNT(*) FROM Диагноз WHERE [Идентификатор диагноза] = @id ";
                checkCmd.Parameters.AddWithValue("@id", id);

                int existingRecordsCount = (int)checkCmd.ExecuteScalar();

                if (existingRecordsCount > 0)
                {
                    MessageBox.Show("Диагноз с такими номером уже существует в базе данных.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "INSERT INTO Диагноз ( [Идентификатор диагноза],[Описание диагноза],Лечение) VALUES (@id,@named,@lechenie)";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@named", named);
                cmd.Parameters.AddWithValue("@lechenie", lechenie);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Диагноз успешно добавлен в базу данных.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                cn.Close();
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormChangeDiagnoz_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id;
            string named = textBox2.Text;
            string lechenie = textBox3.Text;

            try
            {
                id = int.Parse(textBox1.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Поле 'Идентификатор' должно быть числовым или не должно быть пустым.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Add_new_Employee(id, named, lechenie);
        }
        private void Delete_Employee(int id)
        {
            int employeeCount = GetEmployeeCountByID(id);

            if (employeeCount == 0)
            {
                MessageBox.Show("Диагноз с таким ID не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (employeeCount >= 1)
            {
                DeleteEmployeeByID(id);
            }
        }
        private int GetEmployeeCountByID(int id)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM Диагноз WHERE [Идентификатор диагноза] = @id", cn);
                cmd.Parameters.AddWithValue("@id", id);
                int count = (int)cmd.ExecuteScalar();
                return count;
            }
            finally
            {
                cn.Close();
            }
        }
        private void DeleteEmployeeByID(int id)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand("DELETE FROM Диагноз WHERE [Идентификатор диагноза] = @id", cn);
                cmd.Parameters.AddWithValue("@id", id);
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id;
            try
            {
                id = int.Parse(textBox4.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Поле 'Идентификатор' должно быть числовым или не должно быть пустым.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Delete_Employee(id);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id;

            if (!int.TryParse(textBox5.Text, out id))
            {
                MessageBox.Show("Поле 'ID' должно быть числовым.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int employeeCount = GetEmployeeCountByID(id);

            if (employeeCount == 0)
            {
                MessageBox.Show("Диагноз с таким ID не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                FillEmployeeDetails(id);
            }
        }
        private void FillEmployeeDetails(int id)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand("SELECT [Описание диагноза], Лечение FROM Диагноз WHERE [Идентификатор диагноза] = @id", cn);
                cmd.Parameters.AddWithValue("@id", id);

                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        textBox7.Text = reader["Описание диагноза"].ToString();
                        textBox8.Text = reader["Лечение"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Диагноз не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            finally
            {
                cn.Close();
            }
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }


        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
        private void Update_Employee(int id, String named, String lechenie)
        {
            cn.Open();
            try
            {
                // Здесь код для обновления данных врача в базе данных
                // Пример обновления данных:
                OleDbCommand cmd = new OleDbCommand("UPDATE Диагноз SET [Описание диагноза] = @named, Лечение = @lechenie WHERE [Идентификатор диагноза] = @id", cn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@named", named);
                cmd.Parameters.AddWithValue("@lechenie", lechenie);
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
        private void button4_Click(object sender, EventArgs e)
        {
            string lechenie = textBox8.Text;
            string named = textBox7.Text;
            int id = int.Parse(textBox5.Text);
            Update_Employee(id, named, lechenie);
        }
    }
}
