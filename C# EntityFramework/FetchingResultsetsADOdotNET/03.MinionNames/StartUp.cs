using System;
using System.Data.SqlClient;

namespace _03.MinionNames
{
    class Program
    {
        private static string connectionString = @"Server=DESKTOP-23ODP6D\SQLEXPRESS;" +
                                                 "Database=MinionsDB;" +
                                                 "Integrated Security=True;";

        private static SqlConnection connection = new SqlConnection(connectionString);

        static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            using (connection)
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(Queries.VillainName, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    string villainName = (string)command.ExecuteScalar();

                    if (villainName == null)
                    {
                        Console.WriteLine($"No villain with ID {id} exists in the database.");
                        return;
                    }

                    Console.WriteLine($"Villain: {villainName}");
                }

                using (SqlCommand command = new SqlCommand(Queries.MinionNames, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("(no minions)");
                            return;
                        }

                        while (reader.Read())
                        {
                            long row = (long)reader[0];
                            string name = (string)reader[1];
                            int age = (int)reader[2];

                            Console.WriteLine($"{row}. {name} {age}");
                        }
                    }
                }
            }
        }
    }
}
