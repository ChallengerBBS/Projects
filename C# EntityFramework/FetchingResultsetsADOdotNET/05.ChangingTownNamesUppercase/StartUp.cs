﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _05.ChangingTownNamesUppercase
{
    public class StartUp

    {
        private static string connectionString = @"Server=DESKTOP-23ODP6D\SQLEXPRESS;" +
                                                        "Database=MinionsDB;" +
                                                        "Integrated Security=True;";

        private static SqlConnection connection = new SqlConnection(connectionString);
        private static void Main()
        {
            string country = Console.ReadLine();

            using (connection)
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(Queries.EditTownNames, connection))
                {
                    command.Parameters.AddWithValue("@countryName", country);
                    int count = command.ExecuteNonQuery();

                    Console.WriteLine($"{count} town names were affected. ");
                }

                using (SqlCommand command = new SqlCommand(Queries.FindEditedTowns, connection))
                {
                    command.Parameters.AddWithValue("@countryName", country);

                    List<string> cities = new List<string>();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cities.Add((string)reader[0]);
                        }
                    }

                    if (cities.Count == 0)
                    {
                        Console.WriteLine("No town names were affected.");
                    }
                    else
                    {
                        Console.WriteLine($"[{string.Join(", ", cities)}]");
                    }
                }
            }
        }
    }
}
