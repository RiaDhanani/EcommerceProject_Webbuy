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
    public class BrandManagement
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public List<BrandDO> GetAllBrands()
        {
            SqlCommand cmd = new SqlCommand("select * from Brand", conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            var query = from b in ds.Tables[0].AsEnumerable()
                        select new BrandDO
                        {
                            Brand_ID = Convert.ToInt32(b[0]),
                            Brand_Name = b[1].ToString(),
                            //UpdatedDate = Convert.ToDateTime(b[2])
                        };
            return query.ToList();
        }

        public BrandDO GetBrandByID(int Brand_ID)
        {
            SqlCommand cmd = new SqlCommand("select * from Brand where Brand_ID = @Brand_ID", conn);
            cmd.Parameters.AddWithValue("Brand_ID", Brand_ID);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            var query = from b in ds.Tables[0].AsEnumerable()
                        select new BrandDO
                        {
                            Brand_ID = Convert.ToInt32(b[0]),
                            Brand_Name = b[1].ToString(),
                            //UpdatedDate = Convert.ToDateTime(b[2])
                        };

            BrandDO objBrand = query.FirstOrDefault();
            return objBrand;
        }
    }
}