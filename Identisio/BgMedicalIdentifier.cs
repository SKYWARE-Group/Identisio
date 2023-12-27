using Skyware.Identisio.Organizations.Bg.Model;
using Skyware.Identisio.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

// Ignore Spelling: bg

namespace Skyware.Identisio;

public abstract class BgMedicalIdentifier : IdentifierBase
{
    protected static IEnumerable<Region> _regions;
    private static IEnumerable<PracticeType> _practiceTypes;

    protected BgMedicalIdentifier(int region, int practice, int serial)
    {
        Region = region;
        PracticeType = practice;
        Serial = serial;
    }

    #region Props

    public int Region { get; private set; }

    public int PracticeType { get; private set; }

    public int Serial { get; private set; }

    #endregion

    protected static void TryInitializePrerequisites()
    {
        if (_regions == null)
        {
            string regionsFile = Assembly.GetExecutingAssembly().GetManifestResourceNames().FirstOrDefault(p => p.EndsWith("regions.xml"));
            _regions = XmlUtils.GetObject<Regions>(Assembly.GetExecutingAssembly().GetManifestResourceStream(regionsFile))?.RegionsCollection;
        }
        if (_practiceTypes == null)
        {
            string practiceTypesFile = Assembly.GetExecutingAssembly().GetManifestResourceNames().FirstOrDefault(p => p.EndsWith("practice-types.xml"));
            _practiceTypes = XmlUtils.GetObject<PracticeTypes>(Assembly.GetExecutingAssembly().GetManifestResourceStream(practiceTypesFile))?.PracticeTypesCollection;
        }
    }

    #region Validate

    protected static bool ValidateRegion(string regionCode)
    {
        if (regionCode?.Length != 2)
            return false;

        foreach (Region region in _regions)
            if (region.Code == regionCode)
                return true;

        return false;
    }


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
