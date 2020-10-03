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
    public class CategoryManagement
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        public List<CategoryDO> GetAllCategory()
        {
            SqlCommand cmd = new SqlCommand("select * from Category", conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            var query = from cat in ds.Tables[0].AsEnumerable()
                        select new CategoryDO
                        {
                            Category_ID = Convert.ToInt32(cat[0]),
                            Category_Name = cat[1].ToString(),
                            //UpdatedDate = Convert.ToDateTime(cat[2])
                        };
            return query.ToList();
        }

        public CategoryDO GetCategoryByID(int Category_ID)
        {
            SqlCommand cmd = new SqlCommand("select * from Category where Category_ID = @Category_ID", conn);
            cmd.Parameters.AddWithValue("Category_ID", Category_ID);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            var query = from cat in ds.Tables[0].AsEnumerable()
                        select new CategoryDO
                        {
                            Category_ID = Convert.ToInt32(cat[0]),
                            Category_Name = cat[1].ToString(),
                            //UpdatedDate = Convert.ToDateTime(cat[2])
                        };
            CategoryDO objCategory = query.FirstOrDefault();
            return objCategory;
        }
    }
}