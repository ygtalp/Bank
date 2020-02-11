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
    public partial class Form4 : Form

    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=BankClientDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        public Form4()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkUsername())
            {
                MessageBox.Show("Kullanıcı adı alınmıştır, başka bir kullanıcı adı deneyiniz");
            }
            else
            {
                if (txtUsername.Text == "" || txtPassword.Text == "")
                    MessageBox.Show("Alanları Doldurunuz");
                else if (txtPassword.Text != txtPasswordConfirm.Text)
                    MessageBox.Show("Şifreler Uyuşmuyor");
                else
                {
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("UserAdd", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Lastname", txtLname.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        MessageBox.Show("Kayıt Başarılı !");
                        Clear();
                    }
                }
            }
        }
        void Clear()
        {
            txtName.Text = txtLname.Text = txtPassword.Text = txtPasswordConfirm.Text = txtUsername.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 objFrm1 = new Form1();
            this.Hide();
            objFrm1.Show();
        }

        public Boolean checkUsername()
        {
            String username = txtUsername.Text;
            SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=BankClientDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            SqlCommand command = new SqlCommand("Select * from Client Where username = '" + txtUsername.Text.Trim() + "'");
            string query = "Select * from Client Where username = '" + txtUsername.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
