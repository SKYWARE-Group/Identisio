using Skyware.Identisio.Organizations.Bg.Model;
using Skyware.Identisio.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

// Ignore Spelling: bg

namespace Skyware.Identisio.Bg;

/// <summary>
/// Represents a Bulgarian Medical Practice Identifier issued to medical practices by the Bulgarian Ministry of Health.
/// </summary>
public abstract class PracticeIdentifier : RegionalIdentifier
{

    /// <summary>
    /// These are applicable values instead of municipality code.
    /// </summary>
    protected static string[] SPECIAL_CODES = ["80", "81", "82", "90", "99"]; // Check if 81, 82 and 99 are valid

    private static IDictionary<string, PracticeType> _practiceTypes;

    public string MunicipalityOrSpecialCode { get; protected set; }

    public string MunicipalityOrSpecialName { get; protected set; }

    public string PracticeTypeCode { get; protected set; }

    public int Serial { get; protected set; }


    protected static void InitializeSets()
    {
        InitializeRegions();
        if (_practiceTypes is null)
        {
            string practiceTypesFile = Assembly.GetExecutingAssembly().GetManifestResourceNames().FirstOrDefault(p => p.EndsWith("practice-types.xml"));
            _practiceTypes = XmlUtils.GetObject<PracticeTypes>(Assembly.GetExecutingAssembly().GetManifestResourceStream(practiceTypesFile))
                ?.PracticeTypesCollection.ToDictionary(p => p.Code);
        }
    }

    #region Validate


    protected static bool ValidateType(string practiceTypeCode)
    {
        if (practiceTypeCode?.Length != 3)
            return false;

        foreach (PracticeType practiceType in _practiceTypes.Values)
            if (practiceType.Code == practiceTypeCode)
                return true;

        return false;
    }

    protected static bool ValidateSerialNumber(string serialNumber)
    {
        if (serialNumber?.Length != 3)
            return false;

        if (serialNumber == "000")
            return false;

        foreach (char ch in serialNumber)
            if (!char.IsDigit(ch))
                return false;

        return true;
    }

    public static bool ValidateMunicipality(string regionCode, string municipalityCode)
    {
        if (municipalityCode?.Length != 2)
            return false;

        foreach (Region region in _regions.Values)
            if (region.Code == regionCode)
                foreach (Municipality municipality in region.Municipalities)
                    if (municipality.Code == municipalityCode)
                        return true;
        return SPECIAL_CODES.Contains(municipalityCode);
    }

    #endregion

}
