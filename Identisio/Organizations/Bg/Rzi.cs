using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace Skyware.Identisio.Organizations.Bg
{

    /// <summary>
    /// RZI (РЗИ) codes are identifiers for health institutions in Bulgaria
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
            if (!IsValidInstitution(_Regex.Match(inputRzi.Trim()).Groups[3].Value)) return false;
            return true;
        }

        private static bool IsValidInstitution(string value)
        {
            using (var reader = new StreamReader("../../../../Identisio/Resources/Bg/practice-types.xml"))
            {
                var docReg = new XmlDocument();
                docReg.Load(reader);
                var nodes = docReg.SelectNodes("/PracticeType/Code");
                foreach (XmlNode node in nodes)
                {
                    if (node.Value == value) return true;
                }
            }

            return false;
        }

        #endregion


        //TODO: implement Parse


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
