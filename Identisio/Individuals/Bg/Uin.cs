using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Identisio.Individuals.Bg
{

    /// <summary>
    /// UIN (УИН) are identifiers for doctors in Bulgaria and are issued by BMA (БЛС)
    /// </summary>
    public class Uin : IdentifierBase
    {

        public override string Name => "Unique identifier of a doctor";

        public override string NativeAbbreviation => "УИН";

        public override string NativeName => "Уникален идентификационен номер на лекар";

        public override bool IsPrivateData => false;

        //TODO: Implement Validate (Parse?)

    }

}
