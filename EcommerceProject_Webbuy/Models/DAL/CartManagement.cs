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
    public class CartManagement
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public List<CartDO> GetAllRecordsInCart()
        {
            SqlCommand cmd = new SqlCommand("select * from cart", conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            var query = from p in ds.Tables[0].AsEnumerable()
                        select new CartDO
                        {
                            Cart_ID = Convert.ToInt32(p[0]),
                            User_ID = p[1].ToString()
                        };
            return query.ToList();
        }
            public void AddCartIDandUserIDInCart(CartDO dataModel)
        {
            SqlCommand cmd = new SqlCommand("insert into Cart values(@User_ID)", conn);
            cmd.Parameters.AddWithValue("@User_ID", dataModel.User_ID);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public CartDO GetCartByUserID(string User_ID)
        {
            SqlCommand cmd = new SqlCommand("Select * from Cart where User_ID = @User_ID", conn);
            cmd.Parameters.AddWithValue("@User_ID", User_ID);
            SqlDataReader reader = null;

            CartDO modelData = new CartDO();

            conn.Open();
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (reader.Read())
            {
                modelData.Cart_ID = Convert.ToInt32(reader[0]);
                modelData.User_ID = reader[1].ToString();
            }

            conn.Close();

            return modelData;
        }
    }
}