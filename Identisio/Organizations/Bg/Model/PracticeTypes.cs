using System.Collections.Generic;
using System.Xml.Serialization;

namespace Skyware.Identisio.Organizations.Bg.Model;

public class PracticeTypes
{
    [XmlElement("PracticeType")]
    public List<PracticeType> PracticeTypesCollection { get; set; }
}
