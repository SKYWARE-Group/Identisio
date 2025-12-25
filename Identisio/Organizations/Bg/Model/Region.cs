using System.Collections.Generic;
using System.Xml.Serialization;

namespace Skyware.Identisio.Organizations.Bg.Model;

/// <summary>
/// Represents a region (област) in Bulgaria.
/// </summary>
public class Region
{
    [XmlElement("Name")]
    public string Name { get; set; }

    [XmlElement("BMACode")]
    public string BMACode { get; set; }

    [XmlElement("Code")]
    public string Code { get; set; }

    [XmlElement("Municipality")]
    public List<Municipality> Municipalities { get; set; }
}
