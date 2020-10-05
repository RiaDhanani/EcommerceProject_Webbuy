using EcommerceProject_Webbuy.Models.DAL;
using EcommerceProject_Webbuy.Models.DataObjects;
using EcommerceProject_Webbuy.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace EcommerceProject_Webbuy.Controllers
{
    public class ProductController : Controller
    {
        ProductManagement productManagement = new ProductManagement();
        // GET: Product
        public ActionResult Index()
        {
            List<ProductDO> products = productManagement.GetAllProducts();

            var query = from p in products
                        select new ProductListViewModel
                        {
                            Product_ID = p.Product_ID,
                            Product_Name = p.Product_Name,
                            Price = Convert.ToInt32(p.Price),
                            SubCategory_Name = p.SubCategory.SubCategory_Name,
                            Brand_Name = p.Brand.Brand_Name,
                            Size = p.Size,
                            Color = p.Color,
                            Product_Image = p.Product_Image, 
                            //ImageFile = "\\Images" + "\\" + p.Product_Image.ToString(),
                            Description = p.Description,
                            Quantity = Convert.ToInt32(p.Quantity),
                            //UpdatedDate = Convert.ToDateTime(p.UpdatedDate)
                        };

            return View(query.ToList());

        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        private List<SelectListItem> getBrandDropDownData()
        {
            BrandManagement brandManagement = new BrandManagement();

            var query = from b in brandManagement.GetAllBrands()
                        select new SelectListItem
                        {
                            Value = b.Brand_ID.ToString(),
                            Text = b.Brand_Name
                        };
            return query.ToList();
        }

        private List<SelectListItem> getSubCategoryDropDownData()
        {
            SubCategoryManagement subCategoryManagement = new SubCategoryManagement();

            var query = from cat in subCategoryManagement.GetAllSubCategory()
                        select new SelectListItem
                        {
                            Value = cat.SubCategory_ID.ToString(),
                            Text = cat.SubCategory_Name
                        };
            return query.ToList();
        }

        private List<SelectListItem> GetCategoryDropdownData()
        {
            CategoryManagement categoryManagement = new CategoryManagement();

            var query = from cat in categoryManagement.GetAllCategory()
                        select new SelectListItem
                        {
                            Value = cat.Category_ID.ToString(),
                            Text = cat.Category_Name
                        };

            return query.ToList();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ProductCreateViewModel model = new ProductCreateViewModel();
            model.Brands = getBrandDropDownData();
            model.Categories = GetCategoryDropdownData();

            model.SubCategories = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = "0",
                    Text = "-Select SubCategory"
                }
            };
            return View(model);
        }

        public ActionResult getSubCategory(int Category_ID)
        {
            SubCategoryManagement subCategoryManagement = new SubCategoryManagement();

            var query = from subCategory in subCategoryManagement.GetSubCategoryByCategoryID(Category_ID)
                        select new SelectListItem
                        {
                            Value = subCategory.SubCategory_ID.ToString(),
                            Text = subCategory.SubCategory_Name
                        };
            List<SelectListItem> SubCategories = query.ToList();

            return Json(SubCategories, JsonRequestBehavior.AllowGet);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductCreateViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                ProductDO dataModel = new ProductDO();
                dataModel.Product_Name = model.Product_Name;
                dataModel.Price = model.Price;
                dataModel.SubCategory_ID = model.SubCategory_ID;
                dataModel.Brand_ID = model.Brand_ID;
                dataModel.Size = model.Size;
                dataModel.Color = model.Color;

                //string FileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string FileName = Path.GetFileName(model.ImageFile.FileName);
                //string FileExtension = Path.GetExtension(model.ImageFile.FileName);
                string UploadPath = ConfigurationManager.AppSettings["ImagesPath"].ToString();
                model.Product_Image = UploadPath + FileName;
                model.ImageFile.SaveAs(Server.MapPath((model.Product_Image)));

                dataModel.Product_Image = model.Product_Image;
                //dataModel.ImageFile = model.ImageFile;
                dataModel.Description = model.Description;
                dataModel.Quantity = model.Quantity;
                
                
                ProductManagement productManagement = new ProductManagement();
                productManagement.InsertProduct(dataModel);


                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                model.Categories = GetCategoryDropdownData();
                return View(model);
            }
        }
        

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            ProductManagement productManagement = new ProductManagement();
            ProductDO modelData = productManagement.GetProductByID(id);

            ProductEditViewModel model = new ProductEditViewModel();
            model.Product_ID = modelData.Product_ID;
            model.Product_Name = modelData.Product_Name;
            model.Price = modelData.Price;

           // model.Category_ID = modelData.Category_ID;
            model.Categories = GetCategoryDropdownData();

            model.SubCategory_ID = modelData.SubCategory_ID;
            model.SubCategories = getSubCategoryDropDownData();

            model.Brand_ID = modelData.Brand_ID;
            model.Brands = getBrandDropDownData();

            model.Size = modelData.Size;
            model.Color = modelData.Color;
            model.Product_Image = modelData.Product_Image;
            model.Description = modelData.Description;
            model.Quantity = modelData.Quantity;

            TempData["ImagesPath"] = model.Product_Image;

            return View(model);
            
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,ProductEditViewModel model, HttpPostedFileBase ImageFile)
        {
            
            try
            {
                // TODO: Add update logic here
                ProductDO dataModel = new ProductDO();
                dataModel.Product_ID = model.Product_ID;
                dataModel.Product_Name = model.Product_Name;
                dataModel.Price = model.Price;      
                //dataModel.Category_ID = model.Category_ID;
                dataModel.SubCategory_ID = model.SubCategory_ID;
                dataModel.Brand_ID = model.Brand_ID;
                dataModel.Size = model.Size;
                dataModel.Color = model.Color;
                    

                if (ImageFile == model.ImageFile)
                {
                    dataModel.Product_Image = TempData["ImagesPath"].ToString();
                    //dataModel.Product_Image = model.Product_Image;
                    dataModel.Description = model.Description;
                    dataModel.Quantity = model.Quantity;

                    ProductManagement productManagement = new ProductManagement();
                    productManagement.EditProduct(dataModel);

                    return RedirectToAction("Index");
                }
                else
                {
                    string FileName = Path.GetFileName(model.ImageFile.FileName);
                    string UploadPath = ConfigurationManager.AppSettings["ImagesPath"].ToString();
                    model.Product_Image = UploadPath + FileName;
                    model.ImageFile.SaveAs(Server.MapPath((model.Product_Image)));
                    dataModel.Product_Image = model.Product_Image;
                    dataModel.Description = model.Description;
                    dataModel.Quantity = model.Quantity;

                    ProductManagement productManagement = new ProductManagement();
                    productManagement.EditProduct(dataModel);

                    return RedirectToAction("Index");
                }
                //dataModel.Product_Image = model.Product_Image;
                
                
            }
            catch(Exception e)
            {
                model.SubCategories = getSubCategoryDropDownData();
                model.Brands = getBrandDropDownData();
                return View(model);
                
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
