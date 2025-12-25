using System.Collections.Generic;
using System.Xml.Serialization;

namespace Skyware.Identisio.Organizations.Bg.Model;

/// <summary>
/// A collection of medical practice types in Bulgaria.
/// </summary>
public class PracticeTypes
{

    [XmlElement("PracticeType")]
    public List<PracticeType> PracticeTypesCollection { get; set; }

}
