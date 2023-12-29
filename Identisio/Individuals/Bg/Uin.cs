using Skyware.Identisio.Bg;
using Skyware.Identisio.Organizations.Bg.Model;
using System;
using System.Text.RegularExpressions;

// Ignore Spelling: uin

namespace Skyware.Identisio.Individuals.Bg;

/// <summary>
/// UIN (УИН) are identifiers for medical practitioners in Bulgaria.
/// Issuer: BMA (БЛС)
/// </summary>
/// <remarks>
/// Format: AABBBBBBBB, where <br/>
/// AA - Region (Област), 02-29 <br/>
/// BBBBBBBB - Sequential number (Пореден номер), 00000001 - 99999999 <br/>
/// </remarks>
public class Uin : RegionalIdentifier
{

    public override string Name => "Unique identifier number of a doctor";

    public override string NativeAbbreviation => "УИН";

    public override string NativeName => "Уникален идентификационен номер на лекар";

    public override bool IsPrivateData => false;


    public int SequentialNumber { get; private set; }


    // Parsing

    public static Uin Parse(string value)
    {
        if (!Validate(value)) throw new ArgumentException($"Invalid data for {nameof(Uin)}.");

        string regionCode = value.Substring(0, 2);
        string sequentialNumber = value.Substring(2);

        return new Uin()
        {
            RegionCode = regionCode,
            RegionName = _BMARegions[regionCode].Name,

            Value = value,
            SequentialNumber = int.Parse(sequentialNumber),
        };
    }

    public static bool TryParse(string value, out Uin result)
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

    // Validation

    public new static bool Validate(string value)
    {
        if (string.IsNullOrEmpty(value)) return false;

        string BMACode = value.Substring(0, 2);
        string sequentialNumber = value.Substring(2);

        if (BMACode?.Length != 2)
            return false;

        bool regionResult = false;
        foreach (Region region in _BMARegions.Values)
            if (region.BMACode == BMACode)
                regionResult = true;

        if (sequentialNumber.Length == 8) return regionResult;

        return false;
    }
}
