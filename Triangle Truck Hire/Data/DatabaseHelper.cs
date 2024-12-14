using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace Triangle_Truck_Hire.Data
{
        public static class DatabaseHelper
        {
            private static readonly string DatabasePath = "TriangleTruckHire.db";

            public static string ConnectionString => $"Data Source={DatabasePath};Version=3;";

            public static void InitializeDatabase()
            {
                if (!File.Exists(DatabasePath))
                {
                    SQLiteConnection.CreateFile(DatabasePath);
                    using (var connection = new SQLiteConnection(ConnectionString))
                    {
                        connection.Open();
                        string createTablesQuery = @"
                        CREATE TABLE IF NOT EXISTS Loads (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Description TEXT,
                            DriverId INTEGER,
                            TruckId INTEGER,
                            ScheduledDate TEXT
                        );
                        CREATE TABLE IF NOT EXISTS Drivers (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT
                        );
                        CREATE TABLE IF NOT EXISTS Trucks (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            RegistrationNumber TEXT
                        );";
                        var command = new SQLiteCommand(createTablesQuery, connection);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
