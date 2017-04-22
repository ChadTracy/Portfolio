using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CATracy_FinalProject.Controllers
{
    public class Product
    {
        private string _productType;
        private int _productID;
        private string _title;
        private double _price;

        public string ProductType
        {
            get { return _productType; }
            set { _productType = value; }
        }
        public int ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public double discountPercentage(int quantity)
        {
            double discount = 0;

            if (quantity < 2)
            {
                discount = 0;
            }
            else if (quantity == 2 || quantity == 3 || quantity == 4)
            {
                discount = .02; //2%
            }
            else if (quantity >= 5)
            {
                discount = .05; //5%
            }
            return discount;
        }

        public Product(string type, int id, string title, double price)
        {
            ProductType = type;
            ProductID = id;
            Title = title;
            Price = price;
        }
    }
}