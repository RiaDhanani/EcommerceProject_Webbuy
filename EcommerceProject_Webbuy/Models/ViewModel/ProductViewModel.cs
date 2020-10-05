using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceProject_Webbuy.Models.ViewModel
{
    public class ProductListViewModel
    {
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public int Price { get; set; }
        public string SubCategory_Name { get; set; }
        public string Brand_Name { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Product_Image { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }   
        //public DateTime UpdatedDate { get; set; }
    }

    public class ProductCreateViewModel
    {
        public string Product_Name { get; set; }
        public int? Price { get; set; }
        public int SubCategory_ID { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> SubCategories { get; set; }
        public int Brand_ID { get; set; }
        public List<SelectListItem> Brands { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Product_Image { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }       
        
    }

    public class ProductEditViewModel
    {
        [Key]
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public int? Price { get; set; }
        public int Category_ID { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public int SubCategory_ID { get; set; }
        public List<SelectListItem> SubCategories { get; set; }
        public int Brand_ID { get; set; }
        public List<SelectListItem> Brands { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Product_Image  { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }
    }
}