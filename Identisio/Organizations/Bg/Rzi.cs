using Skyware.Identisio.Individuals.Bg;
using Skyware.Identisio.Organizations.Bg.Base;
using Skyware.Identisio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using static Skyware.Identisio.Organizations.Bg.Rzi;

namespace Skyware.Identisio.Organizations.Bg
{

    /// <summary>
    /// RZI (РЗИ) codes are identifiers for health institutions in Bulgaria
    /// </summary>
    public class Rzi : RegionContainingCode
    {

        public override string Name => "Region Health Inspection Code";

        public override string NativeAbbreviation => "РЗИ";

        public override string NativeName => "РЗИ код";

        public override bool IsPrivateData => false;

        //TODO: implement Parse

        private Rzi(int region, int municipality, int practice, int serial)
            :base(region,practice,serial)
        {
            Municipality = municipality;
        }

        #region Props

        public int Municipality { get; set; }

        #endregion

        #region Validation

        public new static bool Validate(string value)
        {
            if (value?.Length != 10) return false;

            TryInitializePrerequisutes();

            string regionCode = value.Substring(0, 2);
            string municipaltyCode = value.Substring(2, 2);
            string practiceTypeCode = value.Substring(4, 3);
            string serialCode = value.Substring(7, 3);

            return ValidateRegion(regionCode)
                && ValidateMunicipality(regionCode, municipaltyCode)
                && ValidateType(practiceTypeCode)
                && ValidateSerialNumber(serialCode);
        }
        
        private static bool ValidateMunicipality(string regionCode, string municipalityCode)
        {
            if (municipalityCode?.Length != 2)
                return false;

            foreach (RegionModel region in _regions)
                if (region.Code == regionCode)
                    foreach (MunicipalityModel municipality in region.Municipalities)
                        if (municipality.Code == municipalityCode)
                            return true;

            return false;
        }

        #endregion

        #region Parse
        
        public static Rzi Parse(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(nameof(value));

            string regionCode = value.Substring(0, 2);
            string municipaltyCode = value.Substring(2, 2);
            string practiceTypeCode = value.Substring(4, 3);
            string serialCode = value.Substring(7, 3);

            TryInitializePrerequisutes();

            if (!ValidateRegion(regionCode)) throw new ArgumentException(nameof(value), $"Invalid {nameof(Rzi)} region code.");
            if (!ValidateMunicipality(regionCode, municipaltyCode)) throw new ArgumentException(nameof(value), $"Invalid {nameof(Rzi)} municipality code.");
            if (!ValidateType(practiceTypeCode)) throw new ArgumentException(nameof(value), $"Invalid {nameof(Rzi)} practice type code.");
            if (!ValidateRegion(serialCode)) throw new ArgumentException(nameof(value), $"Invalid {nameof(Rzi)} serial code.");

            return new Rzi(int.Parse(regionCode), int.Parse(municipaltyCode), int.Parse(practiceTypeCode), int.Parse(serialCode));
        }

        public static bool TryParse(string value, out Rzi result)
        {
            try
            {
                result = Parse(value);
                return true;
            }
            catch (Exception)
            {
                result = null;
                return false;
            }
        }

        #endregion

        // AABBCCCDDD
        // AA - Област, 01-28
        // BB - Община,
        // CCC - Вид ЛЗ
        // DDD - Пореден номер - 001 - 999

        //ResourcesBg.regions.xml
        //using (var rdrReg = embeddedProvider.GetFileInfo("EmbeddedResources.regions.xml").CreateReadStream())
        //_Regions = XmlUtils.GetObject<Region[]>(rdrReg);
    }

}
