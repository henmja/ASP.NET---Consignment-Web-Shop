using ConsignmentShopLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ConsignmentShopFront
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private Shop shop = new Shop();
        List<String>[] Products = new List<String>[6];
        List<String>[] Sellers = new List<String>[5];
        private MySqlConnection cn = new MySqlConnection();



        //Select statement
        public List<string>[] SelectSellers()
        {
            string query = "SELECT * FROM seller";

            //Create a list to store the result
            List<string>[] list = new List<string>[5];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            list[4] = new List<string>();

            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, cn);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            //Read the data and store them in the list
            while (dataReader.Read())
            {
                list[0].Add(dataReader["SellerID"] + "");
                list[1].Add(dataReader["MerchandiseID"] + "");
                list[2].Add(dataReader["FirstName"] + "");
                list[3].Add(dataReader["LastName"] + "");
                list[4].Add(dataReader["Fee"] + "");
            }

            //close Data Reader
            dataReader.Close();
            
            //return list to be displayed
            return list;
            
        }


        //Select statement
        public List<string>[] SelectMerchandise()
        {
            string query = "SELECT * FROM merchandise";

            //Create a list to store the result
            List<string>[] list = new List<string>[6];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            list[4] = new List<string>();
            list[5] = new List<string>();
            cn.Open();
            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, cn);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            //Read the data and store them in the list
            while (dataReader.Read())
            {
                list[0].Add(dataReader["MerchandiseID"] + "");
                list[1].Add(dataReader["Navn"] + "");
                list[2].Add(dataReader["Description"] + "");
                list[3].Add(dataReader["Price"] + "");
                list[4].Add(dataReader["Sold"] + "");
                list[5].Add(dataReader["SellerShopPayed"] + "");
            }

            //close Data Reader
            dataReader.Close();
            

            //return list to be displayed
            return list;

        }

        //Method to mark items in the mysql database as sold.
        public void Update(String name)
        {
            string query = "UPDATE merchandise SET Sold=true WHERE Navn='"+name+"'";
            
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = cn;

                //Execute query
                cmd.ExecuteNonQuery();

                
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            shop.Name = "Norwegian Jewellery and Loan";

            string connectionString = @"Data Source=localhost; Database=asp_webshop_db; User ID=root; Password=''";
            using (cn = new MySqlConnection(connectionString))
            {
                cn.Open();
                //HttpContext.Current.Response.Write("Mysql Connection successful");
            }

            Products = SelectMerchandise();

            shop.Products.Add(new Merchandise
            {
                MerchandiseID = decimal.Parse(Products[0][0]),
                Name = Products[1][0],
                Description = Products[2][0],
                Price = decimal.Parse(Products[3][0])
            });

            shop.Products.Add(new Merchandise
            {
                MerchandiseID = decimal.Parse(Products[0][1]),
                Name = Products[1][1],
                Description = Products[2][1],
                Price = decimal.Parse(Products[3][1])
            });

            shop.Products.Add(new Merchandise
            {
                MerchandiseID = decimal.Parse(Products[0][2]),
                Name = Products[1][2],
                Description = Products[2][2],
                Price = decimal.Parse(Products[3][2])
            });

            shop.Products.Add(new Merchandise
            {
                MerchandiseID = decimal.Parse(Products[0][3]),
                Name = Products[1][3],
                Description = Products[2][3],
                Price = decimal.Parse(Products[3][3])
            });

            Sellers = SelectSellers();

            shop.Sellers.Add(new Seller { FirstName = Sellers[2][0], LastName = Sellers[3][0] });
            shop.Sellers.Add(new Seller { FirstName = Sellers[2][2], LastName = Sellers[3][2] });



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
                            if (temp.Name.Equals(selectedValue.Name)) { //temp.name selectedvalue.name
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

                //Mark bought items as sold:
                foreach (Merchandise merch in shoppingCartList)
                {
                    foreach (Merchandise prod in shop.Products) {
                        if (merch.Name==prod.Name)   {
                            prod.Sold = true;
                            Update(prod.Name);
                        }
                    }
                }
                //Mark bought items as sold in mysql database:

            }
            ListBoxShoppingCart.Items.Clear();
            ViewState.Remove("Shoppingcart");
        }
    }
}