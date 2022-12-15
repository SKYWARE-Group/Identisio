using Skyware.Identisio.Model.Resources.Bg;
using Skyware.Identisio.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Skyware.Identisio.Organizations.Bg
{

    /// <summary>
    /// RZI (РЗИ) codes are identifiers for health institutions in Bulgaria
    /// AABBCCCDDD
    /// AA - Област, 01-28 
    /// BB - Община,
    /// CCC - Вид ЛЗ - done
    /// DDD - Пореден номер - 001 - 999 
    /// </summary>
    public class Rzi : IdentifierBase
    {
        #region Fields

        private static readonly string _RziRegex = @"^(0[1-9]|1[0-9]|2[0-8])(\d{2})(\d{3})(\d{3})$";
        private static readonly Regex _Regex = new Regex(_RziRegex);

        #endregion

        #region Props

        public override string Name => "Region Health Inspection Code";

        public override string NativeAbbreviation => "РЗИ";

        public override string NativeName => "РЗИ код";

        public override bool IsPrivateData => false;

        #endregion

        #region Actions

        public static new bool Validate(string inputRzi)
        {
            if (string.IsNullOrWhiteSpace(inputRzi)) return false;
            if (!_Regex.IsMatch(inputRzi.Trim())) return false;
            if (!isValidRegion(_Regex.Match(inputRzi.Trim()).Groups[2].Value)) return false;
            if (!IsValidInstitution(_Regex.Match(inputRzi.Trim()).Groups[3].Value)) return false;
            return true;
        }

        private static bool IsValidInstitution(string value)
        {
            if ((!File.Exists("../../../../Identisio/Resources/Bg/practice-Types.xml")))
                throw new ArgumentException();
            using (var fileContent = File.OpenRead("../../../../Identisio/Resources/Bg/practice-types.xml"))
            {
                var institutions = XmlUtils.GetObject<HealthInstitutions>(fileContent);
                return institutions.Institutions.Any(x => x.Code.Equals(value, StringComparison.CurrentCultureIgnoreCase));
            }
        }

        private static bool isValidRegion(string value)
        {
            if ((!File.Exists("../../../../Identisio/Resources/Bg/regions.xml")))
                throw new ArgumentException();
            using (var fileContent = File.OpenRead("../../../../Identisio/Resources/Bg/regions.xml"))
            {
                var regions = XmlUtils.GetObject<HealthRegions>(fileContent);
                return regions.Regions.Any(x => x.Code.Equals(value, StringComparison.CurrentCultureIgnoreCase));
            }
        }

        #endregion
    }

}
