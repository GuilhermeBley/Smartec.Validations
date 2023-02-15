namespace Smartec.Validations.Extensions.Text;

public static class StringExtension
{
    public const string BETWEEN_UNTIL_END = "";

    /// <summary>
    /// Get value in text between first and last
    /// </summary>
    /// <param name="text">Text to find</param>
    /// <param name="first">First pattern</param>
    /// <param name="last">End pattern</param>
    /// <returns>Value found, if didn't find, returns string empty</returns>
    public static string GetBetween(this string text, string first, string last = BETWEEN_UNTIL_END)
    {
        if (string.IsNullOrEmpty(first) ||
            last is null)
            return string.Empty;
        
        int pos1 = text.IndexOf(first);

        if (pos1 == -1)
            return string.Empty;

        pos1 += first.Length;

        int pos2;

        if (last == string.Empty)
            pos2 = text.Length;
        else 
        {
            pos2 = text.Substring(pos1, text.Length - pos1).IndexOf(last);

            if (pos2 == -1)
                return string.Empty;

            pos2 += pos1;
        }

        return text.Substring(pos1, pos2 - pos1);
    }
}