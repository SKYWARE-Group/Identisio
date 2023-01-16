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
    /// Identifier for branches of health institutions in Bulgaria
    /// AABBCCCDDD
    /// AA - Област, 01-28
    /// НЕЩО СПЕЦИАЛНО 80-82
    /// CCC - Вид ЛЗ
    /// DDD - Пореден номер - 001 - 999
    /// </summary>
    public class NhifCode : IdentifierBase
    {
        private static readonly string _nhivRegex = @"^(0[1-9]|1[0-9]|2[0-8])(8[0-9]|90)(\d{3})(\d{3})$";
        private static readonly Regex _regex = new Regex(_nhivRegex);

        public override string Name => "Nhif code";

        public override string NativeAbbreviation => "НЗОК номер";

        public override string NativeName => "НЗОК номер";

        public override bool IsPrivateData => false;

        //TODO: implement Parse
        public static new bool Validate(string nhiv)
        {
            if (string.IsNullOrWhiteSpace(nhiv)) return false;
            if (!_regex.IsMatch(nhiv.Trim())) return false;
            if (!IsValidInstitution(_regex.Match(nhiv.Trim()).Groups[3].Value, EmbeddedCollections.Instance)) return false;
            return true;
        }

        private static bool IsValidInstitution(string value, EmbeddedCollections embedded)
        {
            return embedded.EmbeddedInstitutions.Institutions.Any(x => x.Code.Equals(value, StringComparison.CurrentCultureIgnoreCase));
        }
    }

}
