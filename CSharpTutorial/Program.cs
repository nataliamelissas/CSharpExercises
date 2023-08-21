// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;
using System;

class Program
{
    static void Main(string[] args)
    {
        // Connect to Azure SQL Database
        try
        {
            SqlConnectionStringBuilder conn = new SqlConnectionStringBuilder();
            conn.DataSource = Environment.GetEnvironmentVariable("SERVER_NAME");
            conn.UserID = Environment.GetEnvironmentVariable("DB_USER");
            conn.Password = Environment.GetEnvironmentVariable("DB_PASSWORD");
            conn.InitialCatalog = "MSSQLTIPS";

            using SqlConnection connection = new SqlConnection(conn.ConnectionString);
            string sql = "SELECT name,costrate,availability from dbo.Location";
            using SqlCommand sqlcommand = new SqlCommand(sql, connection);
            connection.Open();
            using SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("\t{0}\t{1}\t{2}", reader.GetString(0), reader.GetDecimal(1), reader.GetDecimal(1));
            }
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.ToString());
        }

        // Palindrome 
        string test, rev;
        test = "Malayalam"; //.ToLower(); // bad, creates a second temporary string object
        char[] ch = test.ToCharArray();

        Array.Reverse(ch);
        rev = new string(ch);
        bool b = test.Equals(rev, StringComparison.OrdinalIgnoreCase);
        if (b)
        {
            Console.WriteLine("It's a palindrome!");
        } else
        {
            Console.WriteLine("Nope");
        }

        Console.Read();
    }
}
