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

        private static readonly string _rziRegex = @"^(0[1-9]|1[0-9]|2[0-8])(\d{2})(\d{3})(\d{3})$";
        private static readonly Regex _regex = new Regex(_rziRegex);

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
            if (!_regex.IsMatch(inputRzi.Trim())) return false;
            if (!isValidRegion(_regex.Match(inputRzi.Trim()).Groups[2].Value, EmbeddedCollections.Instance)) return false;
            if (!IsValidInstitution(_regex.Match(inputRzi.Trim()).Groups[3].Value, EmbeddedCollections.Instance)) return false;
            return true;
        }

        private static bool IsValidInstitution(string value, EmbeddedCollections embedded)
        {
            return embedded.EmbeddedInstitutions.Institutions.Any(x => x.Code.Equals(value, StringComparison.CurrentCultureIgnoreCase));
        }

        private static bool isValidRegion(string value, EmbeddedCollections embedded)
        {
            return embedded.EmbeddedRegions.Regions.Any(x => x.Code.Equals(value, StringComparison.CurrentCultureIgnoreCase));
        }

        #endregion
    }

}
