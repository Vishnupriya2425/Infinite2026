using System;
using System.Data;
using System.Data.SqlClient;

namespace ADO_Assessment7
{
    class Updation
    {
        public static SqlConnection conn = new SqlConnection(
            "Data Source=ICS-LT-FDHKR24;Initial Catalog=EmployeeManagement;Integrated Security=true");

        public static SqlCommand cmd = null;
        public static SqlDataReader dataReader = null;

        static void Main(string[] args)
        {
            UpdateSalary();
            DisplayEmployees();

            Console.Read();
        }

        public static void UpdateSalary()
        {
            try
            {
                conn.Open();

                Console.Write("Enter Employee ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                cmd = new SqlCommand("sp_updatesalary", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@eid", id);

                dataReader = cmd.ExecuteReader();

                Console.WriteLine("---- Updated Employee ----");

                while (dataReader.Read())
                {
                    Console.WriteLine(
                        dataReader["empno"] + " " +
                        dataReader["empname"] + " " +
                        dataReader["empsal"] + " " +
                        dataReader["emptype"] + " " +
                        dataReader["empdepid"]);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static void DisplayEmployees()
        {
            try
            {
                conn.Open();

                cmd = new SqlCommand("select * from employee_details", conn);

                dataReader = cmd.ExecuteReader();

                Console.WriteLine("----- employee details -----");

                while (dataReader.Read())
                {
                    Console.WriteLine(
                        dataReader["empno"] + " " +
                        dataReader["empname"] + " " +
                        dataReader["empsal"] + " " +
                        dataReader["emptype"] + " " +
                        dataReader["empdepid"]);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}