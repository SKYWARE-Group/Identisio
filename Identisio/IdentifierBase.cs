using System;
using System.Collections.Generic;
using System.Text;

namespace Identisio
{

    public abstract class IdentifierBase
    {

        /// <summary>
        /// By design the IdentifierBase class and its ancesstors are not meant to be instantiated. They are immutable.
        /// </summary>
        protected IdentifierBase() { }

        /// <summary>
        /// Value of the identifier.
        /// </summary>
        public string Value { get; protected set; }

        /// <summary>
        /// Full identifier name in English.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Full identifier name in the language used by the country that uses it.
        /// </summary>
        public abstract string NativeShortName { get; }

        /// <summary>
        /// Short identifier name in the language used by the country that uses it.
        /// </summary>
        public abstract string NativeName { get; }

        /// <summary>
        /// Validate the identifier
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static bool Validate(string value) => throw new NotImplementedException();

    }

}
