using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CATracy_FinalProject.Controllers;
using CATracy_FinalProject.Model;

namespace CATracy_FinalProject.Webforms
{
    public partial class ShoppingPlazaForm : System.Web.UI.Page
    {
        List<CartObject>cart = new List<CartObject>();
        List<Product> allProducts = new List<Product>();

        //separate lists for books and DVDs
        List<Product> allBooks = new List<Product>();
        List<Product> allDVDs = new List<Product>();

        protected void Page_Load(object sender, EventArgs e)
        {
            BuildProduct bp = new BuildProduct(); //must be called to use the session

            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            allProducts = (List<Product>)Session["AllProducts"]; //calling session from Model/BuildProduct
            allBooks = (List<Product>) Session["AllBooks"];
            allDVDs = (List<Product>) Session["AllDVDs"];

            if (!IsPostBack)
            {
                foreach (Product product in allProducts) 
                {
                    if (product.ProductType == "Book") //populates dropdown list 
                    {
                        bookDropDown.Items.Add(product.Title);
                        //allBooks.Add(product);
                    }
                    else if (product.ProductType == "DVD") //populates dropdown list 
                    {
                        dvdDropDown.Items.Add(product.Title);
                        //allDVDs.Add(product);
                    }
                }
            }
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(bookQuantityTB.Text) || String.IsNullOrEmpty(dvdQuantityTB.Text)) //checks if user has entered a value into the textbox. If not, error message
            {
                errLabel.Text = "One of the quantities must be more than 0. Otherwise Please click Exit";
            }
            else //builds cart objects 
            {
                if (Session["Cart"] != null)
                {
                    cart = (List<CartObject>)Session["Cart"];
                }

                int bookQ = int.Parse(bookQuantityTB.Text);              
                int bookSelected = bookDropDown.SelectedIndex;
                Product selectedBook = allBooks[bookSelected]; //selects the correct book from the book list based on the dropdown list selection index

                int dvdQ = int.Parse(dvdQuantityTB.Text);
                int dvdSelected = dvdDropDown.SelectedIndex;
                Product selectedDVD = allDVDs[dvdSelected]; //selects the correct DVD from the DVD list based on the dropdown list selection index

                CartObject bookObj = new CartObject(bookQ, selectedBook); //creation of book and DVD cart objects
                CartObject dvdObj = new CartObject(dvdQ, selectedDVD);

                cart.Add(bookObj); 
                cart.Add(dvdObj);

                HttpContext.Current.Session.Add("Cart", cart);
            }
        }

        protected void bookDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            int bookSelected = bookDropDown.SelectedIndex; //int for dropdown menu. corresponds with allBooks list to return the product selected by the user
            Product selectedBook = allBooks[bookSelected];
            bookPriceLabel.Text = selectedBook.Price.ToString("c"); // displays price for the selected book
        }

        protected void dvdDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            int dvdSelected = dvdDropDown.SelectedIndex;
            Product selectedDVD = allDVDs[dvdSelected];
            dvdPriceLabel.Text = selectedDVD.Price.ToString("c");
        }

        protected void checkoutBtn_Click(object sender, EventArgs e) //makes sure something is in the cart before advancing to the next page
        {
            if (cart == null)
            {
                errLabel.Text = "One of the quantities must be more than 0. Otherwise, please click Exit";
            }
            else
            {
                
                Response.Redirect("~/Webforms/Checkout.aspx");
            }
        }

        protected void exitBtn_Click(object sender, EventArgs e) // takes user to exit screen
        {
            Response.Redirect("~/Webforms/ExitPage.aspx");
        }
    }
}