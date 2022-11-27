using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace thistask.Models
{
    public class thisclass
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-AU166TL\\SQLEXPRESS;Initial Catalog=ThisDB; Integrated Security=True");

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Id { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public int mobilenumber { get; set; }


        public string password { get; set; }


        public string Designation { get; set; }

        public string Department { get; set; }
        public string Address { get; set; }



        public ArrayList Idlist = new ArrayList();
        public ArrayList namelist = new ArrayList();
        public ArrayList mobilenumberlist = new ArrayList();
        public ArrayList emaillist = new ArrayList();
        public ArrayList paswordlist = new ArrayList();
        public ArrayList Designationlist = new ArrayList();
        public ArrayList Departmentlist = new ArrayList();
        public ArrayList Addresslist = new ArrayList();


        public void insertCategory()
        {
            string query = "insert into ProductCategory (CategoryName) values('" + CategoryName + "')";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();

        }
        public void UpdateCategory()
        {
            string query = "UPDATE ProductCategory SET CategoryName = '" + CategoryName + "' WHERE CategoryId = " + CategoryId;
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();

        }

        public void DeleteCategory()
        {
            string query = "DELETE FROM ProductCategory  WHERE CategoryId = " + CategoryId;
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();

        }
        public void insertProduct()
        {
            string query = "INSERT INTO Product (ProductName) VALUES ('" + ProductName + "')";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();

        }

        public void UpdateProduct()
        {
            string query = "UPDATE Product SET ProductName = '" + ProductName + "' WHERE ProductId = " + ProductId;
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();

        }

        public void DeleteProduct()
        {
            string query = "DELETE FROM Product WHERE ProductId = " + ProductId;
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();

        }


        public void idlist()
        {
            string query = "select ProductId from Product";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Idlist.Add(dr["ProductId"]);

                }

            }
            dr.Close();
            con.Close();
        }

        public void Categorylist()
        {
            string query = "SELECT CategoryId, CategoryName FROM ProductCategory";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            Idlist.Clear();
            namelist.Clear();
            SqlDataReader r = com.ExecuteReader();
            if (r.HasRows)
            {
                while (r.Read())
                {
                    Idlist.Add(r["CategoryId"]);
                    namelist.Add(r["CategoryName"]);
                }
            }
            r.Close();
            con.Close();
        }
        public void Productlist()
        {
            string query = "SELECT ProductId,ProductName FROM Product";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader r = com.ExecuteReader();
            Idlist.Clear();
            namelist.Clear();
            if (r.HasRows)
            {
                while (r.Read())
                {
                    Idlist.Add(r["ProductId"]);
                    namelist.Add(r["ProductName"]);
                }
            }
            r.Close();
            con.Close();
        }
        public void SelectCategoryDetails()
        {
            string query = "SELECT TOP 1 CategoryId, CategoryName FROM ProductCategory WHERE CategoryId=" + CategoryId;
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader dar = com.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    CategoryId = int.Parse(dar["CategoryId"].ToString());
                    CategoryName = dar["CategoryName"].ToString();
                }
            }
            dar.Close();
            con.Close();

        }

        public void SelectProductDetails()
        {
            string query = "SELECT TOP 1 ProductId, ProductName FROM Product WHERE ProductId=" + ProductId;
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader dar = com.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    ProductId = int.Parse(dar["ProductId"].ToString());
                    ProductName = dar["ProductName"].ToString();
                }
            }
            dar.Close();
            con.Close();

        }

    }
}