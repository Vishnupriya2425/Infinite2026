using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment7_ADO_
{
    internal class Insertion
    {
        public static SqlConnection conn = null;
        public static SqlCommand cmd = null;
        public static SqlDataReader dataReader = null;
        static void Main(string[] args)
        {

            {
                InsertData();
                SelectData();
                Console.Read();
            }

        }
        static void InsertData()
        {
            try
            {
                conn = getConnection();

                Console.WriteLine("Enter Employee Name, Salary, Type(F/P), DepartmentNo:");

                string ename = Console.ReadLine();
                decimal esal = Convert.ToDecimal(Console.ReadLine());
                string etype = Console.ReadLine();
                int deptid = Convert.ToInt32(Console.ReadLine());

                cmd = new SqlCommand("sp_AddEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ename", ename);
                cmd.Parameters.AddWithValue("@esal", esal);
                cmd.Parameters.AddWithValue("@etype", etype);
                cmd.Parameters.AddWithValue("@deptid", deptid);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                    Console.WriteLine("Record inserted successfully...");
                else
                    Console.WriteLine("Insert failed.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void SelectData()
        {
            try
            {
                conn = getConnection();
                cmd = new SqlCommand("select * from Employee_Details", conn);

                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Console.WriteLine(
                        dataReader["empno"] + " " +
                        dataReader["empname"] + " " +
                        dataReader["Empsal"] + " " +
                        dataReader["Emptype"] + " " +
                        dataReader["EmpDepId"]);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static SqlConnection getConnection()
        {
            conn = new SqlConnection("Data Source = ICS-LT-FDHKR24;Initial Catalog = EmployeeManagement;" +
                "Integrated Security = true ;");
            conn.Open();
            return conn;
        }
    }
}



