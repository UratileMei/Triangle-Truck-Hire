using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Triangle_Truck_Hire.Data
{
    

  
        public class SQLiteManager
        {
            public static void InsertLoad(string description, int driverId, int truckId, DateTime scheduledDate)
            {
                using (var connection = new SQLiteConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Loads (Description, DriverId, TruckId, ScheduledDate) VALUES (@Description, @DriverId, @TruckId, @ScheduledDate)";
                    var command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@DriverId", driverId);
                    command.Parameters.AddWithValue("@TruckId", truckId);
                    command.Parameters.AddWithValue("@ScheduledDate", scheduledDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.ExecuteNonQuery();
                }
            }

            public static List<string> GetAllLoads()
            {
                var loads = new List<string>();
                using (var connection = new SQLiteConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Loads";
                    var command = new SQLiteCommand(query, connection);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            loads.Add($"ID: {reader["Id"]}, Description: {reader["Description"]}");
                        }
                    }
                }
                return loads;
            }
        }
    }

