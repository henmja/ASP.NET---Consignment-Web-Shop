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
                
            }

        }

        protected void ButtonAddToCart_Click(object sender, EventArgs e)
        {
            bool addItem = true;

            //get selected item from product list
            string selectedItem = ListBoxProducts.SelectedItem.Text;
            foreach (Merchandise item in shop.Products)  {
                if (selectedItem.Contains(item.Name)) {
                    Merchandise selectedValue = item;
                    //ClientScript.RegisterStartupScript(this.GetType(), selectedValue.Name, "alert('" + selectedItem + "');", true);
                    if (ViewState["Shoppingcart"] == null) {
                        List<Merchandise> itemList = new List<Merchandise>();
                        
                        itemList.Add(selectedValue);
                            
                        
                        ViewState["Shoppingcart"] = itemList;
                    } else
                    {
                        List<Merchandise> itemList = (List<Merchandise>)ViewState["Shoppingcart"];
                        //loop through shopping cart checking for duplicates (becuse this is a consignment shop, there should only be one 
                        //of each product
                        foreach (Merchandise temp in itemList.ToList())
                        {
                            if (temp.Name.Equals(selectedValue.Name)) {
                                addItem = false;
                                
                            }
                        }
                        if (addItem==true)
                        {
                            itemList.Add(selectedValue); //Add to cart
                            addItem = false;
                        }
                            
                        
                        
                        
                    }
                    List<Merchandise> shoppingCartList = (List<Merchandise>)ViewState["Shoppingcart"];
                    
                    ListBoxShoppingCart.DataTextField = "Display";
                    ListBoxShoppingCart.DataValueField = "Display";

                    ListBoxShoppingCart.DataSource = shoppingCartList;
                    ListBoxShoppingCart.DataBind();
                    
                }
            }
            
        }

        protected void ButtonBuy_Click(object sender, EventArgs e)
        {
            if (ViewState["Shoppingcart"] != null)
            {
                List<Merchandise> shoppingCartList = (List<Merchandise>)ViewState["Shoppingcart"];

                foreach (Merchandise merch in shoppingCartList)
                {
                    merch.Sold = true;  
                }
            }
            ListBoxShoppingCart.Items.Clear();
            ViewState.Remove("Shoppingcart");
        }
    }
}