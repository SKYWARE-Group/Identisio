using System;
using System.Collections.Generic;
using System.Text;

namespace Identisio.Personal.Bg
{

    public class Egn : IdentifierBase, IEncodesGender, IEncodesBirthdate, IParsable<Egn>
    {

        public override string Name => "Unified Personal Number";

        public override string NativeShortName => "ЕГН";

        public override string NativeName => "Единен граждански номер";

        public bool IsMale => throw new NotImplementedException();

        public DateTime Birthdate => throw new NotImplementedException();

        public Egn Parse(string value)
        {
            throw new NotImplementedException();
        }

        public bool TryParse(string value, out Egn result)
        {
            throw new NotImplementedException();
        }
    }

}
