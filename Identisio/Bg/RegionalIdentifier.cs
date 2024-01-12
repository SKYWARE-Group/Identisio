using Skyware.Identisio.Organizations.Bg.Model;
using Skyware.Identisio.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Skyware.Identisio.Bg;

public abstract class RegionalIdentifier : IdentifierBase
{

    protected static IDictionary<string, Region> _regions;
    protected static IDictionary<string, Region> _bmaRegions;
    protected static IDictionary<string, Region> _Regions
    {
        get
        {
            if (_regions == null) InitializeRegions();
            return _regions;
        }
    }

    protected static IDictionary<string, Region> _BMARegions
    {
        get
        {
            if (_bmaRegions == null) InitializeRegions();
            return _bmaRegions;
        }
    }

    // TODO: Implement it
    public string RegionCode { get; protected set; }

    // TODO: Implement it
    public string RegionName { get; protected set; }


    protected static void InitializeRegions()
    {
        if (_regions == null)
        {
            string regionsFile = Assembly.GetExecutingAssembly().GetManifestResourceNames().FirstOrDefault(p => p.EndsWith("regions.xml"));
            var tempregions = XmlUtils.GetObject<Regions>(Assembly.GetExecutingAssembly().GetManifestResourceStream(regionsFile));
            _regions = tempregions?.RegionsCollection.ToDictionary(p => p.Code);
            _bmaRegions = tempregions?.RegionsCollection.ToDictionary(p => p.BMACode);
        }   
    }

    public static bool ValidateRegion(string regionCode)
    {
        if (regionCode?.Length != 2)
            return false;

        foreach (Region region in _Regions.Values)
            if (region.Code == regionCode)
                return true;

        return false;
    }
}
