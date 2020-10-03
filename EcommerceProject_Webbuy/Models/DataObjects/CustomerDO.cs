using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceProject_Webbuy.Models.DataObjects
{
    public class CustomerDO
    {
        public int Customer_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }
        public int City_ID { get; set; }
        public CityDO City { get; set; }
        public string User_ID { get; set; }
        //public DateTime UpdatedDate { get; set; }

    }
}