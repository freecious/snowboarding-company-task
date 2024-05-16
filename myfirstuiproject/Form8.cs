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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Snowboards snowboards = new Snowboards();
            snowboards.Name = "kingfisher yu";
            snowboards.Price = 25;
            MessageBox.Show("item added");
            insert(snowboards);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Snowboards snowboards = new Snowboards();
            snowboards.Name = "oxy ski";
            snowboards.Price = 32;
            MessageBox.Show("item added");
            insert(snowboards);
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
