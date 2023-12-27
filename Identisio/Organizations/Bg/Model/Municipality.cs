using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Skyware.Identisio.Organizations.Bg.Model;

public class Municipality
{
    [XmlElement("Name")]
    public string Name { get; set; }

    [XmlElement("Code")]
    public string Code { get; set; }

    [XmlElement("HRCode")]
    public string HRCode { get; set; }
}
