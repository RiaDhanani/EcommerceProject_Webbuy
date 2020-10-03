using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceProject_Webbuy.Models.DataObjects
{
    public class ProductDO
    {
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public int? Price { get; set; }
        //public int Category_ID { get; set; }
        //public CategoryDO MyProperty { get; set; }
        public int SubCategory_ID { get; set; }
        public SubCategoryDO SubCategory { get; set; }
        public int Brand_ID { get; set; }
        public BrandDO Brand { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Product_Image { get; set; }
        public string Description { get; set; }        
        public int? Quantity { get; set; }
        //public DateTime UpdatedDate { get; set; }
    }
}