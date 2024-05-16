using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace myfirstuiproject
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        static string cnnString = ConfigurationManager.ConnectionStrings["myfirstuiproject.Properties.Settings.loginConnectionString"].ToString();

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cnnString);
            Skis Skis = new Skis("head wc", 40);
            con.Open();
            string request = "insert into [manager].[dbo].[basket] (product name, price) values( @name, @price)";

            SqlCommand c = new SqlCommand(request, con);
            c.Parameters.AddWithValue("price", Skis.Price);
            c.Parameters.AddWithValue("name", Skis.Name);
            insert(Skis);
            MessageBox.Show("item added");
        }

        public void insert(Produit produit)
        {
            SqlConnection con = new SqlConnection(cnnString);
            
            con.Open();
            string request = "insert into [manager].[dbo].[basket] values( @name, @Price)";

            SqlCommand c = new SqlCommand(request, con);
            c.Parameters.AddWithValue("name", produit.Getname());
            c.Parameters.AddWithValue("Price", produit.Getprice()) ;
         
            c.ExecuteNonQuery();
            MessageBox.Show("Insert complete");

        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
   
            Produit Skis = new Skis("qesha ski", 25);
           
            insert(Skis);
            MessageBox.Show("item added");
        }
    }
}
