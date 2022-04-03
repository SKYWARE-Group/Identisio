using System;
using System.Collections.Generic;
using System.Text;

namespace Identisio.Organizations.Bg
{

    public class VatId : IdentifierBase
    {
        public override string Name => "VAT Identification code";

        public override string NativeAbbreviation => "ИН по ДДС";

        public override string NativeName => "Идентификационен код по ЗДСС";

        public override bool IsPrivateData => false;

        //TODO: implement Validate ("BG" + Eik)

    }

}
