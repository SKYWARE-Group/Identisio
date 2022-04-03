using System;
using System.Collections.Generic;
using System.Text;

namespace Identisio.Individuals.Bg
{

    /// <summary>
    /// UIN (УИН) are identifiers for doctors in bulgaria and are issued by BMA (БЛС)
    /// </summary>
    public class Uin : IdentifierBase
    {

        public override string Name => "Unique idenifier of a docotr";

        public override string NativeAbbreviation => "УИН";

        public override string NativeName => "Уникален идентификцаионен номер на лекар";

        public override bool IsPrivateData => false;

        //TODO: Implement Validate (Parse?)

    }

}
