using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Skyware.Identisio.Model.Resources.Bg
{
    [Serializable()]
    [XmlRoot("PracticeTypes")]
    public class HealthInstitutions
    {
        [XmlElement(ElementName = "PracticeType")]
        public HealthInstitution[] Institutions;
    }

    public class HealthInstitution
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}