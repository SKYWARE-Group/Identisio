using System;
using Skyware.Identisio.Bg;

namespace Skyware.Identisio.Organizations.Bg;


/// <summary>
/// NHIF (НЗОК) assigned identifiers for branches of medical practices in Bulgaria. <br/>
/// Issuer: NHIF (НЗОК).
/// </summary>
/// <remarks>
/// Format: AABBCCCDDD, where <br/>
/// AA - Region (Област), 01-28 <br/>
/// BB - NHIF assigned code (Служебен код), 80-82 <br/>
/// CCC - Type of practice (Вид ЛЗ) <br/>
/// DDD - Sequential number (Пореден номер), 001 - 999 <br/>
/// </remarks>
public class NhifCode : PracticeIdentifier
{

    public override string Name => "NHIF code (НЗОК номер)";

    public override string NativeAbbreviation => "НЗОК номер";

    public override string NativeName => "НЗОК номер";

    public override bool IsPrivateData => false;

    #region Props

    public int SpecialCode { get; private set; }

    #endregion

    #region Validation

    public new static bool Validate(string value)
    {
        if (value?.Length != 10) return false;

        InitializeSets();

        string regionCode = value.Substring(0, 2);
        string specialCode = value.Substring(2, 2);
        string practiceTypeCode = value.Substring(4, 3);
        string serialCode = value.Substring(7, 3);

        return ValidateRegion(regionCode)
            && ValidateSpecialCode(specialCode)
            && ValidateType(practiceTypeCode)
            && ValidateSerialNumber(serialCode);
    }

    private static bool ValidateSpecialCode(string specialCode)
    {
        if (specialCode?.Length != 2)
            return false;

        foreach (string validValue in SPECIAL_CODES)
            if (specialCode == validValue)
                return true;

        return false;
    }

    #endregion

    #region Parse

    public static NhifCode Parse(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(nameof(value));

        string regionCode = value.Substring(0, 2);
        string specialCode = value.Substring(2, 2);
        string practiceTypeCode = value.Substring(4, 3);
        string serialCode = value.Substring(7, 3);

        InitializeSets();

        if (!ValidateRegion(regionCode)) throw new ArgumentException(nameof(value), $"Invalid {nameof(Rzi)} region code.");
        if (!ValidateSpecialCode(specialCode)) throw new ArgumentException(nameof(value), $"Invalid {nameof(Rzi)} municipality code.");
        if (!ValidateType(practiceTypeCode)) throw new ArgumentException(nameof(value), $"Invalid {nameof(Rzi)} practice type code.");
        if (!ValidateRegion(serialCode)) throw new ArgumentException(nameof(value), $"Invalid {nameof(Rzi)} serial code.");

        return new NhifCode(); // TODO: Set properties
    }

    public static bool TryParse(string value, out NhifCode result)
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

    #endregion



}
