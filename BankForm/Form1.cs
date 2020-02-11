using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //var client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:57743/");
            //HttpResponseMessage response = await client.GetAsync("api/bank/1");
            //string result = await response.Content.ReadAsStringAsync();
            //label1.Text = result;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 objForm2 = new Form2();
            this.Hide();
            objForm2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 objFrm4 = new Form4();
            this.Hide();
            objFrm4.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
