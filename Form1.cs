using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace LAB7_BDBD
{
    public partial class Form1 : Form
    {
        OleDbConnection cn = new OleDbConnection(
        @"Provider=Microsoft.ACE.OLEDB.12.0;" +
        @"Data Source=""C:\Users\Vladislav888\Desktop\lab7.accdb"""
        );

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            FormDisplayDoctors formDisplayDoctors = new FormDisplayDoctors(cn); // Передаем текущее соединение с БД
            formDisplayDoctors.Show(); // Показываем форму как диалоговое окно
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormDisplayDiagnoz formDisplayDiagnoz = new FormDisplayDiagnoz(cn); // Передаем текущее соединение с БД
            formDisplayDiagnoz.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormDisplayLPY formDisplayHuman = new FormDisplayLPY(cn); // Передаем текущее соединение с БД
            formDisplayHuman.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormDisplayHuman formDisplayHuman = new FormDisplayHuman(cn); // Передаем текущее соединение с БД
            formDisplayHuman.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormDisplayPriem formDisplayPriem = new FormDisplayPriem(cn); // Передаем текущее соединение с БД
            formDisplayPriem.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormDisplayProcedyra formDisplayProcedyra = new FormDisplayProcedyra(cn); // Передаем текущее соединение с БД
            formDisplayProcedyra.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormChangeDiagnoz formChangeDiagnoz = new FormChangeDiagnoz(cn); // Передаем текущее соединение с БД
            formChangeDiagnoz.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }
    }
}