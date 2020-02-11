using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankForm
{
    public partial class Form2 : Form
    {
        public static string userID;
        public string kullaniciID;
        public string idid;
        public static string id2;
        private SqlCommand sqlCommand;
        private Form5 objFrm5;

        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void buttonGrs_Click(object sender, EventArgs e)
        {
            
            SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=BankClientDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            string query = "Select * from Client Where username = '" + txtUsername.Text.Trim() + "' and password = '" + txtPassword.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            sqlcon.Open();
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);


            sqlCommand = new SqlCommand("SELECT Id FROM Client WHERE username='" + txtUsername.Text.Trim() + "'");
            sqlCommand.Connection = sqlcon;
            idid = sqlCommand.ExecuteScalar().ToString();
            id2 = idid;
            MessageBox.Show(idid);
            objFrm5 = new Form5();
           


            if (dtbl.Rows.Count == 1)
            {


                Form3 objFrm3 = new Form3();
                this.Hide();
                objFrm3.Show();
                logid.UserID = txtUsername.Text;
                MessageBox.Show(logid.UserID);
            }
            else
            {
                MessageBox.Show("Kullanıcı bilgileri doğru değil.");
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Form1 objFrm1 = new Form1();
            this.Hide();
            objFrm1.Show();
        }
        public string id
        {
            get
            {
                return userID;
            }
        }

        public void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
