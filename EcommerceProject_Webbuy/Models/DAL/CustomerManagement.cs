using EcommerceProject_Webbuy.Models.DataObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EcommerceProject_Webbuy.Models.DAL
{
    public class CustomerManagement
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        public void CreateUser(CustomerDO dataModel)
        {
            SqlCommand cmd = new SqlCommand("insert into Customer values(@FirstName, @LastName, @Contact, @City_ID, @User_ID)", conn);
            cmd.Parameters.AddWithValue("@FirstName", dataModel.FirstName);
            cmd.Parameters.AddWithValue("@LastName", dataModel.LastName);
            cmd.Parameters.AddWithValue("@Contact", dataModel.Contact);
            cmd.Parameters.AddWithValue("@City_ID", dataModel.City_ID);
            cmd.Parameters.AddWithValue("@User_ID", dataModel.User_ID);
            //cmd.Parameters.AddWithValue("@UpdatedDate", dataModel.UpdatedDate);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}