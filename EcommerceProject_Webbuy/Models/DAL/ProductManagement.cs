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
    public class ProductManagement
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        public List<ProductDO> GetAllProducts()
        {
            SqlCommand cmd = new SqlCommand("select * from product", conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            SubCategoryManagement subCategoryManagement = new SubCategoryManagement();
            BrandManagement brandManagement = new BrandManagement();

            var query = from p in ds.Tables[0].AsEnumerable()
                        select new ProductDO
                        {
                            Product_ID = Convert.ToInt32(p[0]),
                            Product_Name = p[1].ToString(),
                            Price = Convert.ToInt32(p[2]),
                            SubCategory = subCategoryManagement.GetSubCategoryByID(Convert.ToInt32(p[3])),
                            Brand = brandManagement.GetBrandByID(Convert.ToInt32(p[4])),
                            Size = p[5].ToString(),
                            Color = p[6].ToString(),
                            Product_Image = p[7].ToString(),
                            Description = p[8].ToString(),
                            Quantity = Convert.ToInt32(p[9]),
                            //UpdatedDate = Convert.ToDateTime(p[10])
                        };
            return query.ToList();
        }

        public void InsertProduct(ProductDO dataModel)
        {
            SqlCommand cmd = new SqlCommand("insert into product values(@Product_Name, @Price, @SubCategory_ID, @Brand_ID, @Size, @Color, @Product_Image, @Description, @Quantity)", conn);
            cmd.Parameters.AddWithValue("@Product_Name", dataModel.Product_Name);
            cmd.Parameters.AddWithValue("@Price", dataModel.Price);
            cmd.Parameters.AddWithValue("@SubCategory_ID", dataModel.SubCategory_ID);
            cmd.Parameters.AddWithValue("@Brand_ID", dataModel.Brand_ID);
            cmd.Parameters.AddWithValue("@Size", dataModel.Size);
            cmd.Parameters.AddWithValue("@Color", dataModel.Color);
            cmd.Parameters.AddWithValue("@Product_Image", dataModel.Product_Image);
            cmd.Parameters.AddWithValue("@Description", dataModel.Description);
            cmd.Parameters.AddWithValue("@Quantity", dataModel.Quantity);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public ProductDO GetProductByID(int Product_ID)
        {
            SqlCommand cmd = new SqlCommand("Select * from Product where Product_ID = @Product_ID", conn);
            cmd.Parameters.AddWithValue("@Product_ID", Product_ID);
            SqlDataReader reader = null;

            ProductDO modelData = new ProductDO();
            SubCategoryManagement subCategoryManagement = new SubCategoryManagement();
            BrandManagement brandManagement = new BrandManagement();

            conn.Open();
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (reader.Read())
            {
                modelData.Product_ID = Convert.ToInt32(reader[0]);
                modelData.Product_Name = reader[1].ToString();
                modelData.Price = Convert.ToInt32(reader[2]);
                //modelData.Category_ID = Convert.ToInt32(reader[3]);
                modelData.SubCategory_ID = Convert.ToInt32(reader[3]);
                modelData.SubCategory = subCategoryManagement.GetSubCategoryByID(Convert.ToInt32(reader[3]));
                modelData.Brand_ID = Convert.ToInt32(reader[4]);
                modelData.Brand = brandManagement.GetBrandByID(Convert.ToInt32(reader[4]));
                modelData.Size = reader[5].ToString();
                modelData.Color = reader[6].ToString();
                modelData.Product_Image = reader[7].ToString();
                modelData.Description = reader[8].ToString();
                modelData.Quantity = Convert.ToInt32(reader[9]);
                //modelData.UpdatedDate = Convert.ToDateTime(reader[10]);
            }

           
            //  reader.Close();
            conn.Close();


            return modelData;
        }

        public void EditProduct(ProductDO dataModel)
        {
            SqlCommand cmd = new SqlCommand("update PRODUCT set PRODUCT_NAME = @PRODUCT_NAME, PRICE =@PRICE, SubCategory_ID = @SubCategory_ID, Brand_ID = @Brand_ID, Size = @Size, Color = @Color, Product_Image = @Product_Image, Description = @Description, QUANTITY =@QUANTITY where PRODUCT_ID = @PRODUCT_ID", conn);

            cmd.Parameters.AddWithValue("@Product_ID", dataModel.Product_ID);
            cmd.Parameters.AddWithValue("@PRODUCT_NAME", dataModel.Product_Name);
            cmd.Parameters.AddWithValue("@Price", dataModel.Price);
            cmd.Parameters.AddWithValue("@SubCategory_ID", dataModel.SubCategory_ID);
            cmd.Parameters.AddWithValue("@Brand_ID", dataModel.Brand_ID);
            cmd.Parameters.AddWithValue("@Size", dataModel.Size);
            cmd.Parameters.AddWithValue("@Color", dataModel.Color);
            cmd.Parameters.AddWithValue("@Product_Image", dataModel.Product_Image);
            cmd.Parameters.AddWithValue("@Description", dataModel.Description);
            cmd.Parameters.AddWithValue("@Quantity", dataModel.Quantity);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();


        }
    }
}