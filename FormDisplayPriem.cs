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

namespace LAB7_BDBD
{
    public partial class FormDisplayPriem : Form
    {
        private OleDbConnection cn;
        public FormDisplayPriem(OleDbConnection connection)
        {
            InitializeComponent();
            cn = connection;
        }

        private void FormDisplayPriem_Load(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter("SELECT * FROM Приём", cn);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridView1.DataSource = dt; // предполагается, что ваш DataGridView называется dataGridView1
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
