using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Snowboards : Produit
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Getname()
        {
            return Name;
        }

        public double Getprice()
        {
            return Price;
        }
    }
}

