using EcommerceProject_Webbuy.Models.DataObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EcommerceProject_Webbuy.Models.DAL
{
    public class SubCategoryManagement
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        CategoryManagement categoryManagement = new CategoryManagement();
        public List<SubCategoryDO> GetAllSubCategory()
        {
            SqlCommand cmd = new SqlCommand("select * from SubCategory", conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            var query = from subCat in ds.Tables[0].AsEnumerable()
                        select new SubCategoryDO
                        {
                            SubCategory_ID = Convert.ToInt32(subCat[0]),
                            SubCategory_Name = subCat[1].ToString(),
                            Category = categoryManagement.GetCategoryByID(Convert.ToInt32(subCat[2])),
                            //UpdatedDate = Convert.ToDateTime(subCat[3])
                        };
            return query.ToList();
        }

        public SubCategoryDO GetSubCategoryByID(int SubCategory_ID)
        {
            SqlCommand cmd = new SqlCommand("select * from SubCategory where SubCategory_ID = @SubCategory_ID", conn);
            cmd.Parameters.AddWithValue("SubCategory_ID", SubCategory_ID);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            var query = from subCat in ds.Tables[0].AsEnumerable()
                        select new SubCategoryDO
                        {
                            SubCategory_ID = Convert.ToInt32(subCat[0]),
                            SubCategory_Name = subCat[1].ToString(),
                            Category_ID = Convert.ToInt32(subCat[2]),
                            //Category = categoryManagement.GetCategoryByID(Convert.ToInt32(subCat[2])),
                            //UpdatedDate = Convert.ToDateTime(subCat[3])
                        };

            SubCategoryDO objSubCategory = query.FirstOrDefault();
            return objSubCategory;
        }

        public List<SubCategoryDO> GetSubCategoryByCategoryID(int Category_ID)
        {
            SqlCommand cmd = new SqlCommand("Select * from SubCategory where Category_ID = @Category_ID", conn);
            cmd.Parameters.AddWithValue("@Category_ID", Category_ID);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            var query = from cat in ds.Tables[0].AsEnumerable()
                        select new SubCategoryDO
                        {
                            SubCategory_ID = Convert.ToInt32(cat[0]),
                            SubCategory_Name = cat[1].ToString()
                        };
            return query.ToList();
        }
    }
}