using Skyware.Identisio.Bg;
using Skyware.Identisio.Organizations.Bg.Model;
using System;
using System.Linq;

// Ignore Spelling: rzi

namespace Skyware.Identisio.Organizations.Bg;


/// <summary>
/// RZI (РЗИ) code is an identifier of medical practices in Bulgaria. <br/>
/// Issuer: MoH (МЗ/РЗИ).
/// </summary>
/// <remarks>
/// Format: AABBCCCDDD, where <br/>
/// AA - Region (Област), 01-28 <br/>
/// BB - Municipality (Община) <br/>
/// CCC - Type of practice (Вид ЛЗ) <br/>
/// DDD - Sequential number (Пореден номер), 001 - 999 <br/>
/// </remarks>
public sealed class Rzi : PracticeIdentifier
{

    public override string Name => "Practice number (РЗИ код)";

    public override string NativeAbbreviation => "РЗИ";

    public override string NativeName => "РЗИ код";

    public override bool IsPrivateData => false;

    #region Validation

    public new static bool Validate(string value)
    {
        if (value?.Length != 10) return false;

        InitializeSets();

        string regionCode = value.Substring(0, 2);
        string municipaltyCode = value.Substring(2, 2);
        string practiceTypeCode = value.Substring(4, 3);
        string serialCode = value.Substring(7, 3);

        return ValidateRegion(regionCode)
            && ValidateMunicipality(regionCode, municipaltyCode)
            && ValidateType(practiceTypeCode)
            && ValidateSerialNumber(serialCode);
    }

    private static bool ValidateMunicipality(string regionCode, string municipalityCode)
    {
        if (municipalityCode?.Length != 2)
            return false;

        foreach (Region region in _regions.Values)
            if (region.Code == regionCode)
                foreach (Municipality municipality in region.Municipalities)
                    if (municipality.HRCode == municipalityCode)
                        return true;
        return SPECIAL_CODES.Contains(municipalityCode);
    }

    #endregion

    #region Parse

    public static Rzi Parse(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(nameof(value));

        string regionCode = value.Substring(0, 2);
        string municipaltyCode = value.Substring(2, 2);
        string practiceTypeCode = value.Substring(4, 3);
        string serialCode = value.Substring(7, 3);

        InitializeSets();

        if (!ValidateRegion(regionCode)) throw new ArgumentException(nameof(value), $"Invalid {nameof(Rzi)} region code.");
        if (!ValidateMunicipality(regionCode, municipaltyCode)) throw new ArgumentException(nameof(value), $"Invalid {nameof(Rzi)} municipality code.");
        if (!ValidateType(practiceTypeCode)) throw new ArgumentException(nameof(value), $"Invalid {nameof(Rzi)} practice type code.");
        if (!ValidateSerialNumber(serialCode)) throw new ArgumentException(nameof(value), $"Invalid {nameof(Rzi)} serial code.");

        return new Rzi()
        {
            RegionCode = regionCode,
            RegionName = _regions[regionCode].Name,

            MunicipalityOrSpecialCode = municipaltyCode,
            MunicipalityOrSpecialName = _regions[regionCode].Municipalities.FirstOrDefault(p => p.Code == municipaltyCode)?.Name ?? string.Empty,

            PracticeTypeCode = practiceTypeCode,
            Serial = int.Parse(serialCode),
            Value = value,
        };
    }

    public static bool TryParse(string value, out Rzi result)
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
