﻿using System;
using System.Data.SqlClient;

namespace _02.VillianNames
{
    class Program
    {
        private static string connectionString = @"Server=DESKTOP-23ODP6D\SQLEXPRESS;"+
                                                  "Database=MinionsDB;"+
                                                  "Integrated Security=True;";
        private static SqlConnection connection = new SqlConnection(connectionString);
        static void Main(string[] args)
        {
            connection.Open();

            using(connection)
            {
                string queryText = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                       FROM Villains AS v 
                                       JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                       GROUP BY v.Id, v.Name 
                                       HAVING COUNT(mv.VillainId) > 3 
                                       ORDER BY COUNT(mv.VillainId)";
                SqlCommand command = new SqlCommand(queryText, connection);

                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while(reader.Read())
                    {
                        Console.WriteLine($"{reader["Name"]} - {reader["MinionsCount"]}");
                    }
                }
            }
        }
    }
}