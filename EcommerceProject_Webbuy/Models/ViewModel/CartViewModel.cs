using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceProject_Webbuy.Models.ViewModel
{
    public class CartViewModel
    {
        public int Cart_ID { get; set; }
        public string User_ID { get; set; }
    }

    public class CartAddViewModel
    {
        public int Cart_ID { get; set; }
        public string User_ID { get; set; }
    }
}