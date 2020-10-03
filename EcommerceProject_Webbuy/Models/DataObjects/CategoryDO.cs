using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceProject_Webbuy.Models.DataObjects
{
    public class CategoryDO
    {
        public int Category_ID { get; set; }
        public string Category_Name { get; set; }
        public List<SubCategoryDO> SubCategories { get; set; }
        //public DateTime UpdatedDate { get; set; }
    }
}