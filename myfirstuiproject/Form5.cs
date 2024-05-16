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

namespace myfirstuiproject
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)

        {
            Clothes clothes = new Clothes();
            clothes.Name = "skiing pants";
            clothes.Price = 15;
            insert(clothes);
            MessageBox.Show("item added");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

            Clothes clothes = new Clothes("the north face bundle",10);
            MessageBox.Show("item added");
            insert(clothes);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Clothes clothes = new Clothes();
            clothes.Name = "skiing boots";
            clothes.Price = 20;
            insert(clothes);
            MessageBox.Show("item added");
        }
        static string cnnString = ConfigurationManager.ConnectionStrings["myfirstuiproject.Properties.Settings.loginConnectionString"].ToString();

        public void insert(Produit produit)
        {
            SqlConnection con = new SqlConnection(cnnString);

            con.Open();
            string request = "insert into [manager].[dbo].[basket] values( @name, @Price)";

            SqlCommand c = new SqlCommand(request, con);
            c.Parameters.AddWithValue("name", produit.Getname());
            c.Parameters.AddWithValue("Price", produit.Getprice());

            c.ExecuteNonQuery();
            MessageBox.Show("Insert complete");

        }
    }
}
