using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;

namespace myfirstuiproject
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
       static string cnnString = ConfigurationManager.ConnectionStrings["myfirstuiproject.Properties.Settings.loginConnectionString"].ToString();
        SqlConnection con = new SqlConnection(cnnString);
        private void button2_Click(object sender, EventArgs e)
        {
            string surname = textBox1.Text, name = textBox5.Text, renteditems = comboBox1.Text;
            DateTime leaseduration = DateTime.Parse(dateTimePicker1.Text);
            con.Open();
            string request = "insert into [manager].[dbo].[managertab] (surname,name,renteditems,leaseduration) values(@surname, @name, @renteditems, @leaseduration)";

            SqlCommand c = new SqlCommand(request, con);
            c.Parameters.AddWithValue("surname", surname);
            c.Parameters.AddWithValue("name", name);
            c.Parameters.AddWithValue("renteditems", renteditems);
            c.Parameters.AddWithValue("leaseduration", leaseduration);
            c.ExecuteNonQuery();
            MessageBox.Show("Insert complete"); 
            getlistmanager();
        }
        void getlistmanager()
        {
            SqlCommand c = new SqlCommand("select * from [manager].[dbo].[managertab]", con);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            getlistmanager();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            else
                MessageBox.Show("unable to delete content");
        }
    }
}

