using System;
using System.Linq;

namespace Skyware.Identisio.Banking;


/// <summary>
/// International Bank Account Number
/// </summary>
public class Iban : IdentifierBase
{

    public static string[] COUNTRY_CODES = { "BG" };

    public override string Name => "International Bank Account Number";

    public override string NativeAbbreviation => "IBAN";

    public override string NativeName => "International Bank Account Number";

    public override bool IsPrivateData => false;

    public new static bool Validate(string value)
    {
        if (string.IsNullOrEmpty(value)) return false;
        value = value.Replace(" ","");

        if (value.Length != 22) return false;

        string countryCode = value.Substring(0, 2);
        if (!COUNTRY_CODES.Contains(countryCode)) return false;

        string BICCodeCountryPart = value.Substring(3, 4);
        if (BICCodeCountryPart.Any(char.IsDigit)) return false;

        return true;
    }

    public static Iban Parse(string value)
    {
        if (!Validate(value)) throw new ArgumentException(nameof(value), $"Invalid {nameof(Iban)} format.");
        return new Iban()
        {
            Value = value,
        };
    }

    public static bool TryParse(string value, out Iban result)
    {
        try
        {
            result = Parse(value);
            return true;
        }
        catch (Exception)
        {
            result = null;
            return false;
        }
    }
}
