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
    public class CityManagement
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        public List<CityDO> GetAllCity()
        {
            SqlCommand cmd = new SqlCommand("select * from City", conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            var query = from city in ds.Tables[0].AsEnumerable()
                        select new CityDO
                        {
                            City_ID = Convert.ToInt32(city[0]),
                            City_Name = city[1].ToString(),
                            //UpdatedDate = Convert.ToDateTime(city[3])
                        };
            return query.ToList();
        }

        public CityDO GetCityByID(int City_ID)
        {
            SqlCommand cmd = new SqlCommand("select * from City where City_ID = @City_ID", conn);
            cmd.Parameters.AddWithValue("City_ID", City_ID);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            var query = from city in ds.Tables[0].AsEnumerable()
                        select new CityDO
                        {
                            City_ID = Convert.ToInt32(city[0]),
                            City_Name = city[1].ToString(),
                            //UpdatedDate = Convert.ToDateTime(b[2])
                        };

            CityDO objCity = query.FirstOrDefault();
            return objCity;
        }
    }
}