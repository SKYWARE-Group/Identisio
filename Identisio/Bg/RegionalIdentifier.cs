using Skyware.Identisio.Organizations.Bg.Model;
using Skyware.Identisio.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Skyware.Identisio.Bg;

public abstract class RegionalIdentifier : IdentifierBase 
{

    protected static IEnumerable<Region> _regions;

    // TODO: Implement it
    public string RegionCode { get; private set; }

    // TODO: Implement it
    public string RegionName { get; private set; }


    protected static void InitializeRegions()
    {
        if (_regions == null)
        {
            string regionsFile = Assembly.GetExecutingAssembly().GetManifestResourceNames().FirstOrDefault(p => p.EndsWith("regions.xml"));
            _regions = XmlUtils.GetObject<Regions>(Assembly.GetExecutingAssembly().GetManifestResourceStream(regionsFile))?.RegionsCollection;
        }
    }


    protected static bool ValidateRegion(string regionCode)
    {
        if (regionCode?.Length != 2)
            return false;

        foreach (Region region in _regions)
            if (region.Code == regionCode)
                return true;

        // TODO: Set RegionCode and RegionName if succeed.
        // Note that BMA (БЛС, в УИН) codes differs from these in MoH (МЗ, в РЦЗ и НЗОК номера, както и в здравен регион)

        return false;
    }


}
