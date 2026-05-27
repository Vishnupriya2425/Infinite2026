using System;
using System.Data;
using System.Data.SqlClient;

public partial class OrderStats : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
            Response.Redirect("Login.aspx");

        if (!IsPostBack)
        {
            LoadStats();
        }
    }

    void LoadStats()
    {
        lblTotal.Text = Application["TotalUsers"].ToString();
        lblActive.Text = Application["ActiveUsers"].ToString();

        DataTable dt;

        if (Cache["FoodCategoryStats"] == null)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT Category, COUNT(*) AS TotalItems FROM MenuItems GROUP BY Category";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                dt = new DataTable();
                da.Fill(dt);

                Cache.Insert("FoodCategoryStats", dt, null,
                    DateTime.Now.AddMinutes(5), TimeSpan.Zero);
            }
        }
        else
        {
            dt = (DataTable)Cache["FoodCategoryStats"];
        }

        gvStats.DataSource = dt;
        gvStats.DataBind();
    }
}
