using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSolution
{
    internal class QuickClass
    {
        static string ReverseWords(string s)
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
}
