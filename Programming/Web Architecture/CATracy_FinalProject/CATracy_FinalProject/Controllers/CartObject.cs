using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CATracy_FinalProject.Controllers
{
    public class CartObject
    {
        private int _quantity;
        private Product _obj;

        public int Quantity
        {
            get { return _quantity;}
            set { _quantity = value; }
        }
        public Product Object
        {
            get { return _obj; }
            set { _obj = value; }
        }

        public CartObject(int quantity, Product obj)
        {
            Quantity = quantity;
            Object = obj;
        }
    }
}