using System;
using System.Data.SqlClient;

namespace _02_VillainNames
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=MinionsDB;Integrated Security=True";
            var connection = new SqlConnection(connectionString);

            connection.Open();
            using (connection)
            {
                string villianQuery = "SELECT v.[Name], COUNT(*) FROM Villains AS v " +
                                      "JOIN MinionsVillains AS mv " +
                                      "ON mv.VillainId = v.Id " +
                                      "GROUP BY v.[Name] " +
                                      "ORDER BY COUNT(*) DESC";

                var command = new SqlCommand(villianQuery, connection);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]} - {reader[1]}");
                }


                reader.Close();
            }
        }
    }
}