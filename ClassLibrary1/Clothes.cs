using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Clothes : Produit
    {
        public Clothes()
        {
        }

        public Clothes(string v1, double v2)
        {
            Name = v1;
            Price = v2;
        }

        public string Name { get; set; }
        public double Price { get; set; }
        public int V1 { get; }
        public string V2 { get; }

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
