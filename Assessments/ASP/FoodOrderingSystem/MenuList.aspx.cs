using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class MenuList : System.Web.UI.Page
{

    string cs = @"Data Source=ICS-LT-FDHKR24;Initial Catalog=FOMSDB;Integrated Security=True";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
            Response.Redirect("Login.aspx");

        if (!IsPostBack)
            LoadData();
    }

    void LoadData()
    {
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM MenuItems", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvMenu.DataSource = dt;
            gvMenu.DataBind();
        }
    }

    protected void gvMenu_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        int rowIndex = Convert.ToInt32(e.CommandArgument);
        int id = Convert.ToInt32(gvMenu.DataKeys[rowIndex].Value);

        if (e.CommandName == "View")
            Response.Redirect("MenuDetails.aspx?MenuId=" + id);

        if (e.CommandName == "Edit")
            Response.Redirect("AddEditMenu.aspx?MenuId=" + id);

        if (e.CommandName == "Delete")
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM MenuItems WHERE MenuId=@id", con);
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadData();
        }
    }
}