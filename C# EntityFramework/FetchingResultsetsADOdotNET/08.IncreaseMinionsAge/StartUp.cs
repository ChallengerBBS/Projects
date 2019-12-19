using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace _08.IncreaseMinionsAge
{
    class StartUp
    {
        private static string connectionString = @"Server=DESKTOP-23ODP6D\SQLEXPRESS;" +
                                         "Database=MinionsDB;" +
                                         "Integrated Security=True;";
        private static SqlConnection connection = new SqlConnection(connectionString);
        private static void Main()
        {
            List<int> ids = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            using (connection)
            {
                connection.Open();

                using (SqlCommand updateMinion = new SqlCommand(Queries.UpdateMinionInformation, connection))
                {
                    foreach (int id in ids)
                    {
                        updateMinion.Parameters.AddWithValue("@Id", id);
                        updateMinion.ExecuteNonQuery();
                        updateMinion.Parameters.Clear();
                    }
                }

                using (SqlCommand command = new SqlCommand(Queries.SelectMinionInformation, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string name = (string)reader[0];
                        int age = (int)reader[1];

                        Console.WriteLine($"{name} {age}");
                    }
                }
            }
        }
    }
}
