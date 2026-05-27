using System;
using System.Data.SqlClient;

public partial class MenuDetails : System.Web.UI.Page
{
    string cs = @"Data Source=ICS-LT-FDHKR24;Initial Catalog=FOMSDB;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
            Response.Redirect("Login.aspx");

        if (!IsPostBack)
        {
            if (Request.QueryString["MenuId"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["MenuId"]);
                LoadDetails(id);
            }
        }
    }

    void LoadDetails(int id)
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
                lblId.Text = dr["MenuId"].ToString();
                lblName.Text = dr["ItemName"].ToString();
                lblCategory.Text = dr["Category"].ToString();
                lblType.Text = dr["FoodType"].ToString();
                lblPrice.Text = dr["Price"].ToString();
                lblQty.Text = dr["AvailableQuantity"].ToString();
                lblAvailable.Text = dr["IsAvailable"].ToString();
            }
        }
    }
}
