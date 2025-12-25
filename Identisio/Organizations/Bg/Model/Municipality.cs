using System.Xml.Serialization;

namespace Skyware.Identisio.Organizations.Bg.Model;

/// <summary>
/// Represents a municipality (община) in Bulgaria.
/// </summary>
public class Municipality
{

    [XmlElement("Name")]
    public string Name { get; set; }

    [XmlElement("Code")]
    public string Code { get; set; }

    [XmlElement("HRCode")]
    public string HRCode { get; set; }

}
