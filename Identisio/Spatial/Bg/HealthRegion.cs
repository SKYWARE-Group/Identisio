using Skyware.Identisio.Bg;
using Skyware.Identisio.Organizations.Bg.Model;
using System;
using System.Globalization;
using System.Linq;

namespace Skyware.Identisio.Spatial.Bg;

/// <summary>
/// Spatially encodes location of a residence of a patient or place of a medical service.<br/>
/// Note that this class assumes "canonical" form, i.e. with dot as a delimiter.<br/>
/// WARNING: All municipalities in Sofia city region ("22") has health region "01".<br/>
/// Issuer: MoH (МЗ)
/// </summary>
/// <remarks>
/// Format: AA.BB, where:<br/>
/// AA - Region (Област), 01-28<br/>
/// BB - Health region (Здравен район)<br/>
/// </remarks>
public class HealthRegion : RegionalIdentifier
{

    public string MunicipalityCode { get; private set; }

    public string MunicipalityName { get; private set; }

    public override string Name => "Health region";

    public override string NativeAbbreviation => "Здр. р-н";

    public override string NativeName => "Здравен район";

    public override bool IsPrivateData => false;

    // Parsing

    public static HealthRegion Parse(string value)
    {
        if (!Validate(value)) throw new ArgumentException($"Invalid data for {nameof(HealthRegion)}.");

        string[] codes = value.Split('.');
        string regionCode = codes[0];
        string healthRegionCode = codes[1];

        return new HealthRegion()
        {
            RegionCode = regionCode,
            RegionName = _Regions[regionCode].Name,

            MunicipalityCode = healthRegionCode,
            MunicipalityName = _Regions[regionCode].Municipalities.FirstOrDefault(p => p.HRCode == healthRegionCode).Name,

            Value = value
        };
    }

    public static bool TryParse(string value, out HealthRegion result)
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

    public new static bool Validate(string value)
    {
        if (string.IsNullOrEmpty(value)) return false;
        if (value.Length != 5) return false;

        string[] codes = value.Split('.');
        string regionCode = codes[0];
        string healthRegionCode = codes[1];

        if (regionCode?.Length != 2)
            return false;

        foreach (Region region in _Regions.Values)
            if (region.Code == regionCode)
                foreach (Municipality municipality in region.Municipalities)
                    if (municipality.HRCode == healthRegionCode)
                        return true;

        return false;
    }
}
