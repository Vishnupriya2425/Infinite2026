using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace FoodOrderingSystem
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "admin" && txtPassword.Text == "food@123")
            {
                Session["Username"] = txtUsername.Text;
                Session["Role"] = "Admin";

                Response.Redirect("MenuList.aspx");
            }
            else
            {
                lblMsg.Text = "Invalid login. You are not authorized.";
            }
        }
    }
}