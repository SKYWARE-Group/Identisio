using System;
using System.Collections.Generic;
using System.Text;

namespace Identisio
{

    public abstract class IdentifierBase
    {

        public string Value { get; private set; }

        public abstract string Name { get; }

        public abstract string NativeShortName { get; }

        public abstract string NativeName { get; }

        public static bool Validate(string value) => throw new NotImplementedException();

    }

}
