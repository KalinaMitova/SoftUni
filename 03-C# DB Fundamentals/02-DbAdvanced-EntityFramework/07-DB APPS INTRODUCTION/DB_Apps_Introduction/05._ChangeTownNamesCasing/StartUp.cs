using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _05._ChangeTownNamesCasing
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string country = Console.ReadLine();

            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=MinionsDb;Integrated Security=True";
            var connection = new SqlConnection(connectionString);

            connection.Open();
            using (connection)
            {
                string getCountryId = "SELECT * FROM Countries WHERE [Name] = @country";
                var cmd = new SqlCommand(getCountryId, connection);
                cmd.Parameters.AddWithValue("@country", country);
                var countryId = cmd.ExecuteScalar();

                if(countryId == null)
                {
                    Console.WriteLine("No town names were affected.");
                    return;
                }

                string updateTownsQuery = "UPDATE Towns SET[Name] = UPPER([Name]) WHERE CountryId = @countryId";
                cmd = new SqlCommand(updateTownsQuery, connection);
                cmd.Parameters.AddWithValue("@countryId", countryId);
                int updatedTownsCount = cmd.ExecuteNonQuery();
                
                if (updatedTownsCount > 0)
                {
                    string selectTownsQuery = "SELECT * FROM Towns WHERE CountryId = @countryId";
                    cmd = new SqlCommand(selectTownsQuery, connection);
                    cmd.Parameters.AddWithValue("@countryId", countryId);

                    List<string> towns = new List<string>();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            towns.Add(reader[1].ToString());
                        }
                    }

                    Console.WriteLine($"{updatedTownsCount} town names were affected.");
                    Console.WriteLine($"[{string.Join(", ", towns)}]");
                }
                else
                {
                    Console.WriteLine("No town names were affected.");
                }
            }
        }
    }
}
