using System.Xml.Serialization;

namespace Skyware.Identisio.Organizations.Bg.Model;

public class PracticeType
{
    [XmlElement("Code")]
    public string Code { get; set; }

    [XmlElement("Name")]
    public string Name { get; set; }

    [XmlElement("IsIndividual")]
    public bool IsIndividual { get; set; }

    [XmlElement("CanPublish")]
    public bool CanPublish { get; set; }

    [XmlElement("CanConsume")]
    public bool CanConsume { get; set; }
}
