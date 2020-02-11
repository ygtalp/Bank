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
    public partial class Form5 : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=BankClientDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        private object son;
        private string tur;
        private string tip;
        Form2 objFrm2 = new Form2();
        private string idGet;

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Vadeli");
            comboBox1.Items.Add("Vadesiz");

            comboBox2.Items.Add("Döviz");
            comboBox2.Items.Add("Altın");
            comboBox2.Items.Add("TL");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int n = r.Next(10, 99);
            int nb = r.Next(1000, 9999);
            if (comboBox1.Text == "Vadeli")
            {
                tur = "VDL" + n;
            }
            else if (comboBox1.Text == "Vadesiz")
            {
                tur = "VDS" + n;
            }

            if (comboBox2.Text == "Döviz")
            {
                tip = "DVZ" + nb;
            }

            else if (comboBox2.Text == "Altın")
            {
                tip = "GLD" + nb;

            }
            else if (comboBox2.Text == "TL")
            {
                tip = "TL" + nb;

            }

            son = tur + tip;
            listBox1.Items.Clear();
            listBox1.Items.Add(son);

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("Lütfen hesap türü ve tipini seçiniz");
            }
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {


                    Form2 objFrm2 = new Form2();
                    idGet = Form2.id2;
                    MessageBox.Show(idGet);
                   
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("AddHesap", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@HesapNo", listBox1.Items[0].ToString());
                    sqlCmd.Parameters.AddWithValue("@Bakiye", 100);
                    sqlCmd.Parameters.AddWithValue("@Id",idGet);
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Hesap Başarıyla Oluşturuldu");

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 objFrm3 = new Form3();
            objFrm3.Show();
        }

        public void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
