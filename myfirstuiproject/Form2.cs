using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myfirstuiproject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f3 = new Form3();
            f3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form f4 = new Form4();
            f4.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form f5 = new Form5();
            f5.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form f6 = new Form6();
            f6.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form f7 = new Form7();
            f7.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form f8 = new Form8();
            f8.Show();
        }
    }
}
