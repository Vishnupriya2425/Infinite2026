using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;

public class OrdersController : ApiController
{
    string connStr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

    [HttpGet]
    [Route("api/orders/employee5")]
    public IHttpActionResult GetOrders()
    {
        List<object> orders = new List<object>();

        using (SqlConnection con = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Orders WHERE EmployeeID = 5", con);
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                orders.Add(new
                {
                    OrderID = dr["OrderID"],
                    OrderDate = dr["OrderDate"]
                });
            }
        }

        return Ok(orders);
    }

    [HttpGet]
    [Route("api/orders/customers/{country}")]
    public IHttpActionResult GetCustomers(string country)
    {
        List<object> customers = new List<object>();

        using (SqlConnection con = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("GetCustomersByCountry", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Country", country);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                customers.Add(new
                {
                    CustomerID = dr["CustomerID"],
                    CompanyName = dr["CompanyName"],
                    Country = dr["Country"]
                });
            }
        }

        return Ok(customers);
    }
}
