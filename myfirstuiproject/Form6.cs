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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("item added");
            Produit sleds = new Sleds("wooden sled", 10);
            insert(sleds);
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
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("item added");
            Sleds sleds = new Sleds("quesha sled",5) ;
            insert(sleds);
        }
    }
}
