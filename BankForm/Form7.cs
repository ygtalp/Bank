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
    public partial class Form7 : Form
    {
        private SqlDataAdapter da;
        private DataSet ds;
        public string idGet;
        public Form7()
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=BankClientDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {


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
            string userId = Form2.id2;
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount > 0 && textBox1.Text != "" && textBox2.Text != "")
            {
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=BankClientDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
                    sqlcon.Open();
                    string hesap = textBox1.Text;
                    string miktar = textBox2.Text;
                    string HesapNo = (string)dataGridView1.CurrentRow.Cells[0].Value;
                    string hesapBakiye = (string)dataGridView1.CurrentRow.Cells[1].Value;
                    int intMiktar = Convert.ToInt32(miktar);
                    int intHesapBakiye = Convert.ToInt32(hesapBakiye);
                    int snc = intHesapBakiye - intMiktar;
                    if (snc < 0)
                    {
                        MessageBox.Show("Hesabınızdaki bakiye yetersizdir.");
                    }
                    else
                    {
                        string qry = "update Hesap set Bakiye='" + snc + "' where HesapNo='" + HesapNo + "' ;";
                        SqlCommand cmdData = new SqlCommand(qry, sqlcon);
                        SqlDataReader myReader;
                        myReader = cmdData.ExecuteReader();
                        MessageBox.Show("Para Transferiniz başarıyla yapıldı.");

                        string query = "INSERT INTO Hareket (HesapNo,Aktarilan,Miktar,Ilk,Son,UserId) VALUES (@HesapNo,@Aktarilan,@Miktar,@Ilk,@Son,@UserId)";
                        SqlCommand command = new SqlCommand(query, sqlcon);
                        command.Parameters.AddWithValue("@HesapNo", HesapNo);
                        command.Parameters.AddWithValue("@Aktarilan", textBox1.Text.Trim());
                        command.Parameters.AddWithValue("@Miktar", intMiktar);
                        command.Parameters.AddWithValue("@Ilk", intHesapBakiye);
                        command.Parameters.AddWithValue("@Son", snc);
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Kayıt alındı.");





                    }
                    dataGridView1.DataSource = null;
                    griddoldur();
                }
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen para aktarılacak hesabı giriniz");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Lütfen miktar giriniz");
            }
            else
            {
                MessageBox.Show("Lütfen hesap seçiniz");

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form3 objFrm3 = new Form3();
            this.Hide();
            objFrm3.Show();
        }
    }
}
