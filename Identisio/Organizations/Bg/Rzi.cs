using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Identisio.Organizations.Bg
{

    /// <summary>
    /// RZI (РЗИ) codes are identifiers for health institutions in Bulgaria
    /// </summary>
    public class Rzi : IdentifierBase
    {
        #region Props

        public override string Name => "Region Health Inspection Code";

        public override string NativeAbbreviation => "РЗИ";

        public override string NativeName => "РЗИ код";

        public override bool IsPrivateData => false;

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
