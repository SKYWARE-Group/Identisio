using Skyware.Identisio.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace Skyware.Identisio.Organizations.Bg.Base
{
    public abstract class RegionContainingCode : IdentifierBase
    {
        protected static IEnumerable<RegionModel> _regions;
        private static IEnumerable<PracticeTypeModel> _practiceTypes;

        protected RegionContainingCode(int region, int practice, int serial)
        {
            Region = region;
            PracticeType = practice;
            Serial = serial;
        }

        #region Props

        public int Region { get; private set; }

        public int PracticeType { get; private set; }

        public int Serial { get; private set; }

        #endregion

        protected static void TryInitializePrerequisutes()
        {
            if (_regions == null)
            {
                string regionsFile = Assembly.GetExecutingAssembly().GetManifestResourceNames().FirstOrDefault(p => p.EndsWith("regions.xml"));
                _regions = XmlUtils.GetObject<Regions>(Assembly.GetExecutingAssembly().GetManifestResourceStream(regionsFile))?.RegionsCollection;
            }
            if (_practiceTypes == null)
            {
                string practiceTypesFile = Assembly.GetExecutingAssembly().GetManifestResourceNames().FirstOrDefault(p => p.EndsWith("practice-types.xml"));
                _practiceTypes = XmlUtils.GetObject<PracticeTypes>(Assembly.GetExecutingAssembly().GetManifestResourceStream(practiceTypesFile))?.PracticeTypesCollection;
            }
        }

        #region Validate

        protected static bool ValidateRegion(string regionCode)
        {
            if (regionCode?.Length != 2)
                return false;

            foreach (RegionModel region in _regions)
                if (region.Code == regionCode)
                    return true;

            return false;
        }


        protected static bool ValidateType(string practiceTypeCode)
        {
            if (practiceTypeCode?.Length != 3)
                return false;

            foreach (PracticeTypeModel practiceType in _practiceTypes)
                if (practiceType.Code == practiceTypeCode)
                    return true;

            return false;
        }

        protected static bool ValidateSerialNumber(string serialNumber)
        {
            if (serialNumber?.Length != 3)
                return false;

            if (serialNumber == "000")
                return false;

            foreach (char ch in serialNumber)
                if (!char.IsDigit(ch))
                    return false;

            return true;
        }

        #endregion

        #region Models

        public class Regions
        {
            [XmlElement("Region")]
            public List<RegionModel> RegionsCollection { get; set; }
        }

        public class RegionModel
        {
            [XmlElement("Name")]
            public string Name { get; set; }

            [XmlElement("BMACode")]
            public string BMACode { get; set; }

            [XmlElement("Code")]
            public string Code { get; set; }

            [XmlElement("Municipality")]
            public List<MunicipalityModel> Municipalities { get; set; }
        }

        public class MunicipalityModel
        {
            [XmlElement("Name")]
            public string Name { get; set; }

            [XmlElement("Code")]
            public string Code { get; set; }

            [XmlElement("HRCode")]
            public string HRCode { get; set; }
        }

        public class PracticeTypes
        {
            [XmlElement("PracticeType")]
            public List<PracticeTypeModel> PracticeTypesCollection { get; set; }
        }

        public class PracticeTypeModel
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

        #endregion
    }
}
