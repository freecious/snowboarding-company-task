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
using ClassLibrary1;
using System.Configuration;


namespace myfirstuiproject
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            deleteAll();
            Application.Exit();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-DGKGMTV;" +
                "Initial Catalog=login;Integrated Security=True;TrustServerCertificate=true");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into login(name) values('"+ textBox1.Text+ "')", con);
                int i=cmd.ExecuteNonQuery();
            if (i == 0) 
            {
                MessageBox.Show("your data has been saved");
            }
            else
            {
                MessageBox.Show("your data has been saved");
            }
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("You need to input your surname.");
            }
          
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("You need to input your name.");
            }
            else
            {
               Form2 f2 = new Form2();
               f2.Show();
               this.Hide();
            }
            

        }
        static string cnnString = ConfigurationManager.ConnectionStrings["myfirstuiproject.Properties.Settings.loginConnectionString"].ToString();

        public void deleteAll()
        {
            SqlConnection con = new SqlConnection(cnnString);

            con.Open();
            string request = "delete  FROM [manager].[dbo].[basket]  where id <> 0";

            SqlCommand c = new SqlCommand(request, con);
     
            c.ExecuteNonQuery();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
