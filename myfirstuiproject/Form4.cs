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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            foreach (Produit p in getlistmanager())
            {
               richTextBox1.Text += $" \t{p.Getname()} {p.Getprice()}$\n";


            }
        }
        static string cnnString = ConfigurationManager.ConnectionStrings["myfirstuiproject.Properties.Settings.loginConnectionString"].ToString();

        public List<Produit>   getlistmanager()

        {
            List<Produit> produits = new List<Produit>();
            
            Clothes clothes = new Clothes();

           
            SqlConnection con = new SqlConnection(cnnString);
            con.Open();
            SqlCommand c = new SqlCommand("select * from [manager].[dbo].[basket]", con);
            SqlDataReader reader = c.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    Produit produit = new Clothes(reader.GetString(1), reader.GetDouble(2)) ;
                    produits.Add(produit);
                }
            }
            con.Close();
            return produits;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            deleteAll();
            this.Close();
        }
        public void deleteAll()
        {
            SqlConnection con = new SqlConnection(cnnString);

            con.Open();
            string request = "delete  FROM [manager].[dbo].[basket]  where id <> 0";

            SqlCommand c = new SqlCommand(request, con);

            c.ExecuteNonQuery();
            con.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
