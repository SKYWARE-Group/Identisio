using Microsoft.Extensions.FileProviders;
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
using static System.Net.Mime.MediaTypeNames;

namespace Skyware.Identisio.Organizations.Bg
{

    /// <summary>
    /// RZI (РЗИ) codes are identifiers for health institutions in Bulgaria
    /// AABBCCCDDD
    /// AA - Област, 01-28 
    /// BB - Община,
    /// CCC - Вид ЛЗ 
    /// DDD - Пореден номер - 001 - 999 
    /// </summary>
    public class Rzi : IdentifierBase
    {
        #region Fields

        private static readonly string _rziRegex = @"^(0[1-9]|1[0-9]|2[0-8])(\d{2})(\d{3})(\d{3})$";
        private static readonly Regex _regex = new Regex(_rziRegex);

        #endregion

        #region Constructors

        public Rzi(int region, int muncipality, int insitutionType, int insitutionNumber)
        {
            this.Region = region;
            this.Municipality = muncipality;
            this.InstitutionType = insitutionType;
            this.InstitutionNumber = insitutionNumber;
        }

        #endregion


        #region Props

        public override string Name => "Region Health Inspection Code";

        public override string NativeAbbreviation => "РЗИ";

        public override string NativeName => "РЗИ код";

        public override bool IsPrivateData => false;
        
        public int Region { get; set; }

        public int Municipality { get; set; }

        public int InstitutionType { get; set; }
        
        public int InstitutionNumber { get; set; }

        #endregion

        #region Actions

        public static Rzi Parse(string value)
        {
            if (!Validate(value)) throw new ArgumentException(nameof(value), $"Invalid {nameof(Rzi)} format");

            var match = _regex.Match(value.Trim());
            
            var region = int.Parse(match.Groups[1].Value);
            var healthRegion = int.Parse(match.Groups[2].Value);
            var institutionType = int.Parse(match.Groups[3].Value);
            var institutionNumber = int.Parse(match.Groups[4].Value);

            return new Rzi(region, healthRegion, institutionType, institutionNumber);
        }

        public static new bool Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            if (!_regex.IsMatch(value.Trim())) return false;
            if (!isValidMunicipality(_regex.Match(value.Trim()).Groups[2].Value, EmbeddedCollections.Instance)) return false;
            if (!IsValidInstitution(_regex.Match(value.Trim()).Groups[3].Value, EmbeddedCollections.Instance)) return false;
            return true;
        }

        private static bool IsValidInstitution(string value, EmbeddedCollections embedded)
        {
            return embedded
                .EmbeddedInstitutions
                .Institutions
                .Any(x => x.Code.Equals(value, StringComparison.CurrentCultureIgnoreCase));
        }

        private static bool isValidMunicipality(string value, EmbeddedCollections embedded)
        {
            return embedded
                .EmbeddedRegions
                .Regions
                .Any(x => x.Municipality.Code.Equals(value, StringComparison.CurrentCultureIgnoreCase));
        }

        #endregion
    }

}
