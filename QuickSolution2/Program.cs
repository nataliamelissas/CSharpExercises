// See https://aka.ms/new-console-template for more information

using System.Text;

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