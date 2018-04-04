using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentShopLibrary
{
    public class Shop
    {
        public string Name { get; set; } //prop tab tab
        public List<Merchandise> Products { get; set; }
        public List<Seller> Sellers { get; set; }
         

        public Shop() //ctor tab tab
        {
            Products = new List<Merchandise>();
            Sellers = new List<Seller>();
        }
    }
}
