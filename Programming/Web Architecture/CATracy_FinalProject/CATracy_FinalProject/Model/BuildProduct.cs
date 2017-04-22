using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using CATracy_FinalProject.Controllers;

namespace CATracy_FinalProject.Model
{

    public class BuildProduct
    {
        List<Product> prod = new List<Product>();
        List<Product> bookProducts = new List<Product>();
        List<Product> dvdProducts = new List<Product>();


        public BuildProduct()
        {
            //Books
            prod.Add(new Product("Book", 101, "Big Data: A Revolution That Will Transform How We Live, Work, and Think", 50.55));
            prod.Add(new Product("Book", 102, "Distruptive Possibilities: How Big Data Changes Everything", 65.67));
            prod.Add(new Product("Book", 103, "Data Smart: Using Data Science to Transform Information into Insight", 32.78));
            prod.Add(new Product("Book", 104, "Big Data: Principles and Best Practices of Scalable Realtime Data Systems", 90.65));
            prod.Add(new Product("Book", 105, "Big Data: Science & Analytics: A Hands-on Approach", 15.25));

            //add to books list
            bookProducts.Add(new Product("Book", 101, "Big Data: A Revolution That Will Transform How We Live, Work, and Think", 50.55));
            bookProducts.Add(new Product("Book", 102, "Distruptive Possibilities: How Big Data Changes Everything", 65.67));
            bookProducts.Add(new Product("Book", 103, "Data Smart: Using Data Science to Transform Information into Insight", 32.78));
            bookProducts.Add(new Product("Book", 104, "Big Data: Principles and Best Practices of Scalable Realtime Data Systems", 90.65));
            bookProducts.Add(new Product("Book", 105, "Big Data: Science & Analytics: A Hands-on Approach", 15.25));

            //DVDs
            prod.Add(new Product("DVD", 201, "The Grand Tour Season 1", 10.00));
            prod.Add(new Product("DVD", 202, "Spectre", 11.99));
            prod.Add(new Product("DVD", 203, "Goliath Season 1", 12.99));
            prod.Add(new Product("DVD", 204, "The Hunger Games: Mockingjacy Part 2", 10.99));
            prod.Add(new Product("DVD", 205, "Good Girls Revolt", 11.99));

            dvdProducts.Add(new Product("DVD", 201, "The Grand Tour Season 1", 10.00));
            dvdProducts.Add(new Product("DVD", 202, "Spectre", 11.99));
            dvdProducts.Add(new Product("DVD", 203, "Goliath Season 1", 12.99));
            dvdProducts.Add(new Product("DVD", 204, "The Hunger Games: Mockingjacy Part 2", 10.99));
            dvdProducts.Add(new Product("DVD", 205, "Good Girls Revolt", 11.99));

            // HttpContext.Current.Session.Add("AllProducts", prod);
            HttpContext.Current.Session.Add("AllProducts", prod);
            HttpContext.Current.Session.Add("AllBooks", bookProducts);
            HttpContext.Current.Session.Add("AllDVDs", dvdProducts);
        }

    }
}