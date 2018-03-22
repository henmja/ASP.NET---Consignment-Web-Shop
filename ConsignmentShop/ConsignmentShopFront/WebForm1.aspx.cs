using ConsignmentShopLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsignmentShopFront
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private Shop shop = new Shop();
        private List<Merchandise> shoppingCartItems = new List<Merchandise>();

        protected void Page_Load(object sender, EventArgs e)
        {
            shop.Name = "Norwegian Jewellery and Loan";

            shop.Sellers.Add(new Seller { FirstName = "Robert", LastName = "Ford" });
            shop.Sellers.Add(new Seller { FirstName = "Jesse", LastName = "James" });

            shop.Products.Add(new Merchandise
            {
                Name = "55 LED-TV Full HD",
                Description = " Full HD (1920 x 1080p), USB, Chromecast port," +
                    " Smaart-tv",
                Price = 3699.99M,
                Merchant = shop.Sellers[0]
            });

            shop.Products.Add(new Merchandise
            {
                Name = "Roof Lamp Milo",
                Description = " Roof lamp with bright pink glass. Height: 24 cm",
                Price = 529M,
                Merchant = shop.Sellers[0]
            });

            shop.Products.Add(new Merchandise
            {
                Name = "Pillow Nagano",
                Description = "Handcrafted decorative pillow in silk/linen.",
                Price = 949M,
                Merchant = shop.Sellers[1]
            });

            shop.Products.Add(new Merchandise
            {
                Name = "Cotton Carpet Cochin",
                Description = "Soft cotton carpet with fringes on the short sides. 200x300 cm.",
                Price = 879M,
                Merchant = shop.Sellers[1]
            });
            if (!IsPostBack)
            {
                ListBoxProducts.DataTextField = "Display";
                ListBoxProducts.DataValueField = "Display";

                ListBoxProducts.DataSource = shop.Products;
                ListBoxProducts.DataBind();

                ListBoxShoppingCart.DataTextField = "Display";
                ListBoxShoppingCart.DataValueField = "Display";

                ListBoxShoppingCart.DataSource = shoppingCartItems;
                ListBoxShoppingCart.DataBind();
            }

        }

        protected void ButtonAddToCart_Click(object sender, EventArgs e)
        {
            //get selected item from product list
            string selectedItem = ListBoxProducts.SelectedItem.Text;
            //Merchandise selectedItem = (Merchandise) ListBoxProducts.SelectedItem;
            foreach (Merchandise item in shop.Products)  {
                //ClientScript.RegisterStartupScript(this.GetType(), selectedItem, "alert('" + selectedItem + "');", true);
                if (selectedItem.Contains(item.Name)) {
                    Merchandise selectedValue = item;
                    ClientScript.RegisterStartupScript(this.GetType(), selectedValue.Name, "alert('" + selectedItem + "');", true);
                    //add selected item to cart
                    shoppingCartItems.Add(selectedValue);
                }
            }
            
            //remove item? no

        }
    }
}