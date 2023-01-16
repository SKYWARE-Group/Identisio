using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Skyware.Identisio.Model.Resources.Bg
{
    [Serializable()]
    [XmlRoot("Regions")]
    public class HealthRegions
    {
        [XmlElement(ElementName = "Region")]
        public HealthRegion[] Regions;
    }

    public class HealthRegion
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}