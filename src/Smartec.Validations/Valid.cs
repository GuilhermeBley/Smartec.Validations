using System.Text.RegularExpressions;

namespace Smartec.Validations;

/// <summary>
/// Validation utils
/// </summary>
public static class Valid
{
    /// <summary>
    /// Avaliable brazilian uf's
    /// </summary>
    private static string[] AvaliableUfBrl
        = new string[]
        {
                "AC", "AL", "AP", "AM", "BA",
                "CE", "DF", "ES", "GO", "MA",
                "MT", "MS", "MG", "PA", "PB",
                "PR", "PE", "PI", "RJ", "RN",
                "RS", "RO", "RR", "SC", "SP",
                "SE", "TO"
        };

    /// <summary>
    /// Validates a Brazilian uf.
    /// </summary>
    /// <param name="uf">To valid</param>
    /// <param name="ufOut">If valid, returned the string to upper and trim. If don't valid, returns null</param>
    /// <returns>True: valid, false : invalid</returns>
    public static bool IsUfBrl(in string uf, out string? ufOut)
    {
        if (!string.IsNullOrEmpty(uf))
        {
            ufOut = uf.ToUpper().Trim();

            bool contains = AvaliableUfBrl.Contains(ufOut);

            if (contains)
                return true;
        }

        ufOut = null;
        return false;
    }

    /// <summary>
    /// Valids Vehicle plate
    /// </summary>
    /// <param name="plate">input plate</param>
    /// <param name="plateOut">Plate validate and corrected if valid, if don't valid, value is null</param>
    /// <returns>True : valid, False : invalid</returns>
    public static bool IsPlateBrl(in string plate, out string? plateOut)
    {
        plateOut = null;

        if (string.IsNullOrEmpty(plate))
        {
            return false;
        }

        plateOut = plate.Replace(" ", "").Replace("-", "").ToUpper();

        if (plateOut.Length != 7)
        {
            plateOut = null;
            return false;
        }
        var match = Regex.Match(plateOut, "^[A-Z]{3}[0-9]{1}[A-J0-9]{1}[0-9]{2}");

        if (!match.Success)
        {
            plateOut = null;
            return false;
        }

        plateOut = match.Value;
        return true;
    }

    /// <summary>
    /// Valids Renavam
    /// </summary>
    /// <param name="renavam">Input Renavam</param>
    /// <param name="renavamOut">If valid, renavam corrected, if invalid, renavam comes as null</param>
    /// <returns>True : valid, false : invalid renavam</returns>
    public static bool IsRenavamBrl(string renavam, out string? renavamOut, bool startWithZero = false)
    {
        if (string.IsNullOrEmpty(renavam))
        {
            renavamOut = null;
            return false;
        }

        renavamOut = renavam.Trim().TrimStart('0');

        if (renavam.Length > 11)
        {
            renavamOut = null;
            return false;
        }

        int[] d = new int[11];
        string sequencia = "3298765432";
        string SoNumero = Regex.Replace(renavam, "[^0-9]", string.Empty);

        if (string.IsNullOrEmpty(SoNumero))
        {
            renavamOut = null;
            return false;
        }

        if (new string(SoNumero[0], SoNumero.Length) == SoNumero)
        {
            renavamOut = null;
            return false;
        }

        SoNumero = Convert.ToInt64(SoNumero).ToString("00000000000");

        int v = 0;

        for (int i = 0; i < 11; i++)
            d[i] = Convert.ToInt32(SoNumero.Substring(i, 1));

        for (int i = 0; i < 10; i++)
            v += d[i] * Convert.ToInt32(sequencia.Substring(i, 1));

        v = (v * 10) % 11;

        v = (v != 10) ? v : 0;

        if (!(v == d[10]))
        {
            renavamOut = null;
            return false;
        }

        if (startWithZero)
            renavamOut = renavamOut.PadLeft(11, '0');

        return true;
    }
}
