using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace LGU_SV_Asset_Management_Sytem
{

    class DatabaseConnection
    {
        string connectionString = "Data Source=TOZEN\\SQLEXPRESS;Initial Catalog=LGU_AMS_DB;Integrated Security=True;";
        public void UploadToDatabase(string query, Dictionary<string, object> parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                        }

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
 
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        public DataTable ReadFromDatabase(string query, Dictionary<string, object> parameters)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return dataTable;
        }
    }

}
