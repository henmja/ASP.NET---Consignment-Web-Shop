using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentShopLibrary
{
    public class Seller
    {
        //prop - tab twice
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Fee { get; set; }

        public Seller() //ctor tab tab
        {
            Fee = 0.2;
        }
    }
}
