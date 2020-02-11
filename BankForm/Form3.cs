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
    public partial class Form3 : Form
    {
        public static string name;

        public Form3()
        {
            InitializeComponent();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 objFrm2 = new Form2();
            Form5 objFrm5 = new Form5();

            this.Hide();
            objFrm5.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Form6 objFrm6 = new Form6();
            this.Hide();
            objFrm6.Show();
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label2.Text = logid.UserID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 objFrm7 = new Form7();
            this.Hide();
            objFrm7.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form8 objFrm8 = new Form8();
            this.Hide();
            objFrm8.Show();
        }


    }
}
