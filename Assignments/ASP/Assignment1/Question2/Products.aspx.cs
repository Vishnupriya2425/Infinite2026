using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment1_product_
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string[] products = { "Laptop", "Mobile", "Headphones" };
        string[] images =
        {
            "~/images/laptop.jpg",
            "~/images/mobile.jpg",
            "~/images/headphones.jpg"
        };
        int[] prices = { 50000, 20000, 3000 };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlProducts.DataSource = products;
                ddlProducts.DataBind();

               
                imgProduct.ImageUrl = images[0];
            }
        }
        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ddlProducts.SelectedIndex;
            imgProduct.ImageUrl = images[index];
        }
        protected void btnPrice_Click(object sender, EventArgs e)
        {
            int index = ddlProducts.SelectedIndex;
            lblPrice.Text = "Price: ₹ " + prices[index];
        }
    }
}

