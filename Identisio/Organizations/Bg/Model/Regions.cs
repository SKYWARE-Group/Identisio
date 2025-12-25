using System.Collections.Generic;
using System.Xml.Serialization;

namespace Skyware.Identisio.Organizations.Bg.Model;

/// <summary>
/// Collection of regions (области) in Bulgaria.
/// </summary>
public class Regions
{
    [XmlElement("Region")]
    public List<Region> RegionsCollection { get; set; }
}
