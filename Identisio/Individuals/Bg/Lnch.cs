using System.Text.RegularExpressions;

// Ignore Spelling: lnch

namespace Skyware.Identisio.Individuals.Bg;


/// <summary>
/// LNCH (ЛНЧ) is the identification number of foreigners in Bulgaria, who have permanent residential rights. <br/>
/// Issuer MoI (МВР).
/// </summary>
/// <remarks>
/// Format: AAAAAAAAAC, where <br/>
/// A - digit <br/>
/// C - check digit <br/>
/// </remarks>
public class Lnch : IdentifierBase
{

    #region Fields

    private static readonly string _LnchRegex = @"^\d{10}$";
    private static readonly Regex _Regex = new(_LnchRegex);

    private static readonly int[] _Weights = [21, 19, 17, 13, 11, 9, 7, 3, 1];

    #endregion

    #region Props

    public override string Name => "Personal Identifier of a Foreigner";

    public override string NativeAbbreviation => "ЛНЧ";

    public override string NativeName => "Личен номер на чужденец";

    public override bool IsPrivateData => true;

    #endregion

    #region Actions

    // Validation

    public new static bool Validate(string inputLnch)
    {
        if (string.IsNullOrWhiteSpace(inputLnch)) return false;
        if (!_Regex.IsMatch(inputLnch.Trim())) return false;
        if (!IsCheckSumValid(inputLnch)) return false;
        return true;
    }

    private static bool IsCheckSumValid(string value)
    {
        int sum = 0;
        for (int i = 0; i <= 8; i++) sum += int.Parse(value.Substring(i, 1)) * _Weights[i];
        sum = sum % 10 % 10;
        return sum == int.Parse(value.Substring(9, 1));
    }

    #endregion

}
