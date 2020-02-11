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
    public partial class Form6 : Form
    {
        private SqlDataAdapter da;
        private DataSet ds;
        public string idGet;
        private object aaa;
        private SqlConnection sqlcon;
        private string bakiyeSon;

        public object DataAccess { get; private set; }

        public Form6()

        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=BankClientDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");

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

        private void Form6_Load(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount>0)
            {
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=BankClientDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
                    sqlcon.Open();
                    string idGrid = (string)dataGridView1.CurrentRow.Cells[0].Value;
                    SqlCommand Command = new SqlCommand("DeleteHesap", sqlcon);
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@HesapNo", idGrid);
                    Command.ExecuteNonQuery();
                    dataGridView1.Rows.RemoveAt(item.Index);
                    MessageBox.Show(idGrid + " hesabı başarıyla silindi");

                }

            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz hesabı seçiniz.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            textBox1.Visible = true;
            button3.Visible = true;
            string miktar = textBox1.Text;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 objFrm3 = new Form3();
            this.Hide();
            objFrm3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount > 0)
            {

                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=BankClientDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
                    sqlcon.Open();

                    string HesapNo = (string)dataGridView1.CurrentRow.Cells[0].Value;
                    string bakiye = (string)dataGridView1.CurrentRow.Cells[1].Value;
                    int intBakiye = Convert.ToInt32(bakiye);

                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Lütfen Miktar Giriniz");
                    }
                    else
                    {
                        string userId = Form2.id2;
                        MessageBox.Show(userId);
                        int intBox = Convert.ToInt32(textBox1.Text);
                        int bakiyeSon = intBakiye + intBox;
                        string qry = "update Hesap set Bakiye='" + bakiyeSon + "' where HesapNo='" + HesapNo + "' ;";
                        SqlCommand cmdData = new SqlCommand(qry, sqlcon);
                        SqlDataReader myReader;
                        myReader = cmdData.ExecuteReader();
                        MessageBox.Show("Paranız hesabınıza başarıyla yatırıldı.");
                        string query = "INSERT INTO Hareket (HesapNo,Aktarilan,Miktar,Ilk,Son,UserId) VALUES (@HesapNo,@Aktarilan,@Miktar,@Ilk,@Son,@UserId)";
                        SqlCommand command = new SqlCommand(query, sqlcon);
                        command.Parameters.AddWithValue("@HesapNo",HesapNo);
                        command.Parameters.AddWithValue("@Aktarilan","Kartın hesabına");
                        command.Parameters.AddWithValue("@Miktar",intBox);
                        command.Parameters.AddWithValue("@Ilk",bakiye);
                        command.Parameters.AddWithValue("@Son",bakiyeSon);
                        command.Parameters.AddWithValue("@UserId",userId);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Kayıt alındı.");

                    }
                    dataGridView1.DataSource = null;
                    griddoldur();
                }
            }
            else
            {
                MessageBox.Show("Lütfen para yatırmak istediğiniz hesabı seçiniz");
            }
        }
    }
}
