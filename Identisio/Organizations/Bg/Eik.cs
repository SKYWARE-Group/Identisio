using System.Text.RegularExpressions;

// Ignore Spelling: eik

namespace Skyware.Identisio.Organizations.Bg;

/// <summary>
/// EIK (ЕИК) are registration codes for all the legal entities in Bulgaria. <br/>
/// Issuer: Registry Agency (Агенция по вписванията).
/// </summary>
public class Eik : IdentifierBase
{

    #region Fields

    private static readonly Regex _Regex = new(@"^\d{9}$|^\d{13}$");
    private static readonly int[] _First13DigitsSum = [2, 7, 3, 5];
    private static readonly int[] _Second13DigitsSum = [4, 9, 5, 7];

    #endregion


    #region Constructors

    private Eik(string eikValue) => Value = eikValue;

    #endregion

    #region Props

    public override string Name => "Organization Identification Code (ЕИК)";

    public override string NativeAbbreviation => "ЕИК";

    public override string NativeName => "Единен идентификационен код";

    public override bool IsPrivateData => false;

    #endregion

    #region Actions

    public new static bool Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;
        if (!_Regex.IsMatch(value.Trim()))
            return false;
        if (!Sum(value))
            return false;
        return true;

    }
    
    public static bool Sum(string value)
    {
        if (value.Length == 9)
            return SumNine(value);
        else
            return SumThirteen(value);


    }

    public static bool SumNine(string value)
    {
        int sum = 0;
        for (int i = 0; i < 8; i++)
        {
            sum += (i+1) * int.Parse(value[i].ToString());
        }
        if (sum % 11 != 10)
        {
            if (sum % 11 == int.Parse(value[8].ToString()))
                return true;
            else
                return false;
        }

        int secondSum = 0;
        for (int i = 0; i < 8; i++)
        {
            secondSum += (i+3) * int.Parse(value[i].ToString());
        }

        if (secondSum % 11 != 10)
        {
            if (secondSum % 11 == int.Parse(value[8].ToString()))
                return true;
            else
                return false;
        }
        else
        {
            if (int.Parse(value[8].ToString()) == 0)
                return true;
            else
                return false;
        }

    }

    public static bool SumThirteen(string value)
    {
        if (!SumNine(value))
            return false;

        int sum = 0;
        for (int i = 8, j = 0; i < 12; i++, j++)
        {
            sum += _First13DigitsSum[j] * int.Parse(value[i].ToString());
        }
        if (sum % 11 != 10)
        {
            if (sum % 11 == int.Parse(value[12].ToString()))
                return true;
            else
                return false;
        }

        int secondSum = 0;
        for (int i = 8, j = 0; i < 12; i++, j++)
        {
            secondSum += _Second13DigitsSum[j] * int.Parse(value[i].ToString());
        }
        if (secondSum % 11 != 10)
        {
            if (secondSum % 11 == int.Parse(value[12].ToString()))
                return true;
            else
                return false;
        }
        else
        {
            if (int.Parse(value[12].ToString()) == 0)
                return true;
            else
                return false;
        }
    }
    
    #endregion

}
