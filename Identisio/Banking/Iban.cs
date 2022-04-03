using System;
using System.Collections.Generic;
using System.Text;

namespace Identisio.Banking
{

    public class Iban : IdentifierBase
    {
        public override string Name => "International Bank Account Number";

        public override string NativeAbbreviation => "IBAN";

        public override string NativeName => "International Bank Account Number";

        public override bool IsPrivateData => false;

        //TODO: implement validation (Parse?)

    }

}
