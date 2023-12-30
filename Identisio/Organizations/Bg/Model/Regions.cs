using System.Collections.Generic;
using System.Xml.Serialization;

namespace Skyware.Identisio.Organizations.Bg.Model;

public class Regions
{
    [XmlElement("Region")]
    public List<Region> RegionsCollection { get; set; }
}
