using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace _07.PrintMinionNames
{
    class StartUp
    {
        private const string TakeAllMinionsNames = "SELECT Name FROM Minions";

        private static string connectionString = @"Server=DESKTOP-23ODP6D\SQLEXPRESS;" +
                                                     "Database=MinionsDB;" +
                                                     "Integrated Security=True;";

        private static SqlConnection connection = new SqlConnection(connectionString);

        private static void Main()
        {
            List<string> names = new List<string>();

            using (connection)
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(TakeAllMinionsNames, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        names.Add((string)reader[0]);
                    }
                }
            }

            Console.WriteLine($"Original Order:\n{string.Join(Environment.NewLine, names)}");
            Console.WriteLine("New Order:");

            while (names.Count != 0)
            {
                Console.WriteLine(names[0]);
                names.RemoveAt(0);

                if (names.Count == 0)
                {
                    break;
                }

                Console.WriteLine(names.Last());
                names.RemoveAt(names.Count - 1);
            }
        }
    }
}
