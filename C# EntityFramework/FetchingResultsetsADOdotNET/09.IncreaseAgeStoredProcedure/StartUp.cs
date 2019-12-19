using System;
using System.Data;
using System.Data.SqlClient;

namespace _09.IncreaseAgeStoredProcedure
{
    public class StartUp
    {
        private static string connectionString = @"Server=DESKTOP-23ODP6D\SQLEXPRESS;" +
                                                     "Database=MinionsDB;" +
                                                     "Integrated Security=True;";

        private static SqlConnection connection = new SqlConnection(connectionString);
        private static void Main()
        {
            int id = int.Parse(Console.ReadLine());

            using (connection)
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(Queries.CreateProcedure, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (SqlCommand command = new SqlCommand("usp_GetOlder", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();
                }

                using (SqlCommand command = new SqlCommand(Queries.SelectMinion, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string name = (string)reader[0];
                        int age = (int)reader[1];

                        Console.WriteLine($"{name} – {age} years old");
                    }
                }
            }
        }
    }
}
