using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceProject_Webbuy.Models.DataObjects
{
    public class SubCategoryDO
    {
        public int SubCategory_ID { get; set; }
        public string SubCategory_Name { get; set; }
        public int Category_ID { get; set; }
        public CategoryDO Category { get; set; }
        //public List<ProductDO> Products { get; set; }
       // public DateTime UpdatedDate { get; set; }
    }
}