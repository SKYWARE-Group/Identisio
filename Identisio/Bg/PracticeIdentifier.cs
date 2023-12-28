using Skyware.Identisio.Organizations.Bg.Model;
using Skyware.Identisio.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

// Ignore Spelling: bg

namespace Skyware.Identisio.Bg;

public abstract class PracticeIdentifier : RegionalIdentifier
{

    /// <summary>
    /// These are applicable values instead of municipality code.
    /// </summary>
    protected static string[] SPECIAL_CODES = ["80", "81", "82", "90", "99"]; // Check if 81, 82 and 99 are valid

    private static IEnumerable<PracticeType> _practiceTypes;

    public string MunicipalityOrSpecialCode { get; private set; }

    public string MunicipalityOrSpecialName { get; private set; }

    public string PracticeTypeCode { get; private set; }

    public int Serial { get; private set; }


    protected static void InitializeSets()
    {
        InitializeRegions();
        if (_practiceTypes == null)
        {
            string practiceTypesFile = Assembly.GetExecutingAssembly().GetManifestResourceNames().FirstOrDefault(p => p.EndsWith("practice-types.xml"));
            _practiceTypes = XmlUtils.GetObject<PracticeTypes>(Assembly.GetExecutingAssembly().GetManifestResourceStream(practiceTypesFile))?.PracticeTypesCollection;
        }
    }

    #region Validate


    protected static bool ValidateType(string practiceTypeCode)
    {
        if (practiceTypeCode?.Length != 3)
            return false;

        foreach (PracticeType practiceType in _practiceTypes)
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

    #endregion

}
