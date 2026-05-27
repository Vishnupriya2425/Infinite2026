using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Data.SqlClient;

namespace FoodOrderingSystem
{


    public partial class AddEditMenu : System.Web.UI.Page
    {
        string cs = "Data Source=;Initial Catalog=FoodOrderDB;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
                Response.Redirect("Login.aspx");

            if (!IsPostBack)
            {
                if (Request.QueryString["MenuId"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["MenuId"]);
                    LoadItem(id);
                }
            }
        }

        void LoadItem(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM MenuItems WHERE MenuId=@id", con);

                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtName.Text = dr["ItemName"].ToString();
                    txtCategory.Text = dr["Category"].ToString();
                    ddlType.SelectedValue = dr["FoodType"].ToString();
                    txtPrice.Text = dr["Price"].ToString();
                    txtQty.Text = dr["AvailableQuantity"].ToString();
                    chkAvailable.Checked = Convert.ToBoolean(dr["IsAvailable"]);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query;

               
                if (Request.QueryString["MenuId"] != null)
                {
                    query = @"UPDATE MenuItems SET 
                          ItemName=@n, Category=@c, FoodType=@t,
                          Price=@p, AvailableQuantity=@q, IsAvailable=@a
                          WHERE MenuId=@id";
                }
                else
                {
                  
                    query = @"INSERT INTO MenuItems
                          (ItemName, Category, FoodType, Price, AvailableQuantity, IsAvailable)
                          VALUES (@n,@c,@t,@p,@q,@a)";
                }

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@n", txtName.Text);
                cmd.Parameters.AddWithValue("@c", txtCategory.Text);
                cmd.Parameters.AddWithValue("@t", ddlType.SelectedValue);
                cmd.Parameters.AddWithValue("@p", txtPrice.Text);
                cmd.Parameters.AddWithValue("@q", txtQty.Text);
                cmd.Parameters.AddWithValue("@a", chkAvailable.Checked);

                if (Request.QueryString["MenuId"] != null)
                {
                    cmd.Parameters.AddWithValue("@id",
                        Request.QueryString["MenuId"]);
                }

                con.Open();
                cmd.ExecuteNonQuery();
            }

            Response.Redirect("MenuList.aspx");
        }
    }
}