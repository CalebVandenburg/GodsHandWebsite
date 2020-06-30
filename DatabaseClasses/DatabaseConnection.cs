using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace GodsHandWebsite.DatabaseClasses
{
    public class DatabaseConnection
    {
        public void ConnectToDatabase()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(new SqlConnectionStringBuilder()
                {
                    DataSource = "DESKTOP-EHLGNHD\\SQLEXPRESS2016",
                    InitialCatalog = "GodsHandWebsiteDatabase",
                    UserID = "Admin",
                    Password = "@dmin"
                }.ConnectionString))
                {
                    conn.Open();
                    //access SQL Server and run your command
                    SqlCommand command = new SqlCommand("SELECT * FROM dbo.Resources");
                    command.Connection = conn;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            System.Diagnostics.Debug.WriteLine("{0} {1} {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //display error message
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}
