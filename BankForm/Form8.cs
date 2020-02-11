using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankForm
{
    public partial class Form8 : Form
    {
        private SqlDataAdapter da;
        private DataSet ds;
        private string idGet;

        public Form8()
        {
            InitializeComponent();
        }

        public void griddoldur()
        {

            idGet = Form2.id2;
            SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=BankClientDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            da = new SqlDataAdapter("Select HesapNo,Bakiye From Hesap WHERE Id='" + idGet + "'", sqlcon);
            ds = new DataSet();
            sqlcon.Open();
            da.Fill(ds, "Hesap");
            dataGridView1.DataSource = ds.Tables["Hesap"];
            sqlcon.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);

            dataGridView2.Visible = true;
            if (selectedRowCount<1)
            {
                MessageBox.Show("Lütfen hesap seçiniz");

            }
            else
            {
                string HesapNo = (string)dataGridView1.CurrentRow.Cells[0].Value;
                SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=BankClientDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
                da = new SqlDataAdapter("Select HesapNo,Aktarilan,Miktar,Ilk,Son From Hareket WHERE HesapNo='" + HesapNo + "'", sqlcon);
                ds = new DataSet();
                sqlcon.Open();
                da.Fill(ds, "Hareket");
                dataGridView2.DataSource = ds.Tables["Hareket"];

            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 objFrm3 = new Form3();
            this.Hide();
            objFrm3.Show();
        }
    }
}
