using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentShopLibrary
{
    [Serializable]
    public class Merchandise
    {
        public string Name { get; set; } //prop tab twice
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Sold { get; set; }
        public bool SellerShopPayed { get; set; } //Has the seller and the shop been payed?
        public Seller Merchant { get; set; }

        public string Display
        {
            get
            {
                return string.Format("{0} - ${1}", Name, Price);
            }
        }

    }
}
