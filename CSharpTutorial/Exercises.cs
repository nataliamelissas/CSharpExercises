// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;
using System.Text;

namespace CSharpExercises
{
    public class Exercises
    {
        static void Main(string[] args)
        {

            YourName();
            DataTypes();
            Casting();
            ListPrint();
            GuessRandom();

            Console.WriteLine(ReverseWords("what a wonderful life"));
            Console.WriteLine(ReverseWords("   what    a    wonderful    life   "));
            Console.WriteLine(ReverseWords("what    a    wonderful    life"));
            Console.WriteLine(ReverseWords("what a wonderful life   "));
            Console.WriteLine(ReverseWords("   what   "));
            Console.WriteLine(ReverseWords("   "));

            PrintWhat();

            SetupDb();

            Palindrome();
        }

        static void PrintWhat() 
        {
            var numbers = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                numbers.Add(i);
            }

            var actions = new List<Action>();
            for (int i = 0; i < 4; i++)
            {
                actions.Add(() => Console.WriteLine(i));
            }

            foreach (int i in numbers)
            {
                Console.WriteLine(i);   
            }

            // Prints 4 4 4 4 because i was left off at the value of 4 and it's passed by reference into the Action, not by value
            foreach (var action in actions)
            {
                action();
            }
        }

        public static string ReverseWords(string s)
        {
            string[] words = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            StringBuilder builder = new();

            for (int i = words.Length - 1; i >= 0; i--)
            {
                string cleanWord = words[i].Trim();
                builder.Append(cleanWord);

                if (i != 0)
                {
                    builder.Append(" ");
                }
            }

            return builder.ToString();  
        }

        static void GuessRandom()
        {
            Random rnd = new Random();
            int secretNumber = rnd.Next(1,11);
            int numberGuessed = 0;
            Console.WriteLine("Random Num: ", secretNumber);

            do
            {
                Console.WriteLine("Enter a number between 1 and 10 :");
                numberGuessed = Convert.ToInt32(Console.ReadLine());
            } while (secretNumber != numberGuessed);

            Console.WriteLine("You got it!!!!!!!");
        }

        static void ListPrint()
        {
            string[] strings = { "abc", "def", "ghi" };
            var actions = new List<Action>();
            foreach (string str in strings)
            {
                actions.Add(() => {
                    Console.WriteLine(str);
                    }
                );
            }

            foreach (Action action in actions)
            {
                action();
            }
        }

        static void Casting()
        {
            bool boolFromStr = bool.Parse("true");
            double someDouble = 1.234;
            string strVal = someDouble.ToString();
            Console.WriteLine($"Data type: {strVal.GetType()}");

            // Explicit conversion - losing data when we do this
            double dblNum = 12.345;
            Console.WriteLine($"Integer : {(int)dblNum}");

            // Implicit conversion - when smaller type is converted to a larger data type
            int intNum = 12;
            long longNum = intNum;
        }

        static void DataTypes()
        {
            bool canIVote = true;
            // 32 or 64 bit
            Console.WriteLine("Biggest Integer : {0}", int.MaxValue);
            Console.WriteLine("Smallest Integer : {0}", int.MinValue);

            // 64 bit 
            Console.WriteLine("Biggest Long: {0}", long.MinValue);
            Console.WriteLine("Smallest Long: {0}", long.MinValue);

            decimal decPiVal = 3.1234567891234566789123234345456567678123234345456567678789M;
            decimal decBigNum = 3.000000000000000000000000000000000000000000000000000000000011M;
            Console.WriteLine("DEC : PI + bigNum = {0}",
                decPiVal + decBigNum);
        }

        static void YourName()
        {
            Console.Write("What's your name? ");
            string name = Console.ReadLine() ;
            Console.WriteLine($"Hello, {name}") ;
        }


        static void SetupDb()
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
        }

        static void Palindrome()
        {
            string test, rev;
            test = "Malayalam"; //.ToLower(); // bad, creates a second temporary string object
            char[] ch = test.ToCharArray();

            Array.Reverse(ch);
            rev = new string(ch);
            bool b = test.Equals(rev, StringComparison.OrdinalIgnoreCase);
            if (b)
            {
                Console.WriteLine("It's a palindrome!");
            }
            else
            {
                Console.WriteLine("Nope");
            }

            Console.Read();
        }
    }

}
