using System;
using System.Collections.Generic;
using System.Text;

namespace Identisio.Organizations.Bg
{

    /// <summary>
    /// VAT ncode of Bulgarian legal entities (compatable with EU VAT number)
    /// </summary>
    public class VatId : IdentifierBase
    {

        public override string Name => "VAT Identification Code";

        public override string NativeAbbreviation => "ИН по ДДС";

        public override string NativeName => "Идентификационен код по ЗДСС";

        public override bool IsPrivateData => false;

        //TODO: implement Validate ("BG" + Eik)

    }

}
