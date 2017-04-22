using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CATracy_FinalProject.Controllers;

namespace CATracy_FinalProject.Webforms
{
    public partial class Checkout : System.Web.UI.Page
    {

        List<CartObject> cartObj = new List<CartObject>();

        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            cartObj = (List<CartObject>) Session["Cart"]; // gets the list of objects from the session

            if (!IsPostBack)
            {
                foreach (CartObject c in cartObj) // loads each object into the list box
                {
                    productListBox.Items.Add(new ListItem(c.Object.Title + " - " + c.Object.Price + " - " + "Quantity: " + c.Quantity));
                }

                quantityChangeTB.Enabled = false;
            }
        }

        protected void productListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            quantityChangeTB.Enabled = true; // enables the textbox when an item is selected

            int selectedProduct = productListBox.SelectedIndex; 
            CartObject selectedCartObject = cartObj[selectedProduct];

            quantityChangeTB.Text = selectedCartObject.Quantity.ToString();
        }

        protected void acceptBtn_Click(object sender, EventArgs e)
        {
            if (quantityChangeTB.Text == "0")
            {
                string selectedItemName = productListBox.SelectedValue; //holds a string value of the selected product
                //int selectedProduct = productListBox.SelectedIndex; //holds an int value for the position of the selected item in the listbox  

                for (int n = productListBox.Items.Count - 1; n >= 0; n--) 
                {
                    if (productListBox.Items[n].ToString().Contains(selectedItemName)) //removes the selected item from the listbox and cartObj list
                    {
                        cartObj.RemoveAt(n);
                        productListBox.Items.RemoveAt(n);
                    }

                }
            }
            else if (String.IsNullOrEmpty(quantityChangeTB.Text))
            {
                //nothing is done if there is no text in the textbox
            }
            else
            {
                int newQuantity = int.Parse(quantityChangeTB.Text); //new value input by user

                int selectedProduct = productListBox.SelectedIndex; //holds an int value for the position of the selected item in the listbox
                CartObject selectedCartObject = cartObj[selectedProduct]; // uses selectedProduct to find the item's posisiton in the cart

                selectedCartObject.Quantity = newQuantity;

                productListBox.Items.Clear(); // clears listbox

                foreach (CartObject c in cartObj) // repopulates listbox from cartObj list with new values
                {
                    productListBox.Items.Add(new ListItem(c.Object.Title + " - " + c.Quantity));
                }
            }
        }

        protected void payBtn_Click(object sender, EventArgs e)
        {
            //int totalQuantity = 0;
            double totalPrice = 0;
            double totalDiscount = 0;
            double priceWithDiscount = 0;

            foreach (CartObject item in cartObj)
            {
                totalPrice += (item.Quantity*item.Object.Price);
                totalDiscount += item.Object.discountPercentage(item.Quantity);
                priceWithDiscount = totalPrice - totalDiscount;
            }

            totalLabel.Text = String.Format("Total amount to pay is {0}. You got a discount amount of {1}", priceWithDiscount, totalDiscount); //displays total price minus the discount. Also displays the discount amount

        }

        protected void exitBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Webforms/ExitPage.aspx");
        }
    }
}