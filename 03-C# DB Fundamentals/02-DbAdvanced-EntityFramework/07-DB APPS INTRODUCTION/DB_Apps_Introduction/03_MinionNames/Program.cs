using System;
using System.Data.SqlClient;

namespace _03_MinionNames
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=MinionsDB;Integrated Security=True";
            var connection = new SqlConnection(connectionString);

            var villainId = int.Parse(Console.ReadLine());

            connection.Open();
            using (connection)
            {
                string villainQuery = "SELECT [Name] FROM Villains WHERE Id = @villianId";
                var villianCommand = new SqlCommand(villainQuery, connection);

                villianCommand.Parameters.AddWithValue("@villianId", villainId);

                var reader = villianCommand.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Villain: {reader[0]}");
                }
                reader.Dispose();

                string minionsQuery = "SELECT [Name], Age FROM Minions AS m " +
                                      "JOIN MinionsVillains AS mv " +
                                      "ON mv.MinionId = m.Id " +
                                      "WHERE mv.VillainId = @villianId";

                var minionsCommand = new SqlCommand(minionsQuery, connection);

                minionsCommand.Parameters.AddWithValue("@villianId", villainId);

                reader = minionsCommand.ExecuteReader();

                int counter = 1;
                while (reader.Read())
                {
                    Console.WriteLine($"{counter}. {reader[0]} {reader[1]}");
                    counter++;
                }
                reader.Dispose();
            }
        }
    }
}