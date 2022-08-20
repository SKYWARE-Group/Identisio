using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Identisio.Organizations.Bg
{

    /// <summary>
    /// EIK (ЕИК) are registration codes for all the legal entities in Bulgaria
    /// </summary>
    public class Eik : IdentifierBase
    {
        public override string Name => "Unified Identification Code";

        public override string NativeAbbreviation => "ЕИК";

        public override string NativeName => "Единен идентификационен код";

        public override bool IsPrivateData => false;

        //TODO: implement Validate

    }

}
