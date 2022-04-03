using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Identisio.Personal.Bg
{

    public class Egn : IdentifierBase, IEncodesGender, IEncodesBirthdate
    {

        #region Fields

        private static readonly string _EgnRegex = @"^\d{10}$";
        private static readonly Regex _Regex = new Regex(_EgnRegex);

        private static readonly int[] _Weights = new int[] { 2, 4, 8, 5, 10, 9, 7, 3, 6 };

        #endregion

        #region Constructors

        private Egn(string egnValue, bool isMaleValue, DateTime birthdateValue)
        {
            this.Value = egnValue;
            this.IsMale = isMaleValue;
            this.Birthdate = birthdateValue;
        }

        #endregion

        #region Props

        public override string Name => "Unified Personal Number";

        public override string NativeShortName => "ЕГН";

        public override string NativeName => "Единен граждански номер";

        public bool IsMale { get; private set; }

        public DateTime Birthdate { get; private set; }

        #endregion

        #region Actions

        // Creation

        public static Egn Parse(string inputEgn)
        {
            // Validity check
            if (string.IsNullOrWhiteSpace(inputEgn)) throw new ArgumentException(nameof(inputEgn));
            if (!_Regex.IsMatch(inputEgn.Trim())) throw new ArgumentException(nameof(inputEgn), $"Invalid {nameof(Egn)} format");
            if (!IsCheckSumValid(inputEgn)) throw new ArgumentException(nameof(inputEgn), $"Bad {nameof(Egn)} checksum");

            // Values extraction
            var dateOfBirth = ParseDob(inputEgn);
            var isMale = ParseIsMale(inputEgn);

            return new Egn(inputEgn, isMale, dateOfBirth);
        }

        public static bool TryParse(string inputEgn, out Egn result)
        {
            result = null;

            // Validity check
            if (string.IsNullOrWhiteSpace(inputEgn)) return false;
            if (!_Regex.IsMatch(inputEgn.Trim())) return false;
            if (!IsCheckSumValid(inputEgn)) return false;

            // Values extraction
            try
            {
                var dateOfBirth = ParseDob(inputEgn);
                var isMale = ParseIsMale(inputEgn);
                
                result = new Egn(inputEgn, isMale, dateOfBirth);
                return true;
            } 
            catch (Exception) { }
            
            return false;
        }

        // Validation

        public new static bool Validate(string iputEgn)
        {
            if (string.IsNullOrWhiteSpace(iputEgn)) return false;
            if (!_Regex.IsMatch(iputEgn.Trim())) return false;
            if (!IsCheckSumValid(iputEgn)) return false;
            return true;
        }

        private static bool IsCheckSumValid(string inputEgn)
        {
            int sum = 0;
            for (int i = 0; i <= 8; i++) sum += int.Parse(inputEgn.Substring(i, 1)) * _Weights[i];
            sum = sum % 11 % 10;
            return sum == int.Parse(inputEgn.Substring(9, 1));
        }

        // Data extraction methods

        private static bool ParseIsMale(string inputEgn) => int.Parse(inputEgn.Substring(8, 1)) % 2 == 0;

        private static DateTime ParseDob(string inputEgn)
        {
            int Month = int.Parse(inputEgn.Substring(2, 2));
            switch (Month)
            {
                case var @case when 1 <= @case && @case <= 12:
                    {
                        return new DateTime(1900 + int.Parse(inputEgn.Substring(0, 2)), Month, int.Parse(inputEgn.Substring(4, 2)));
                    }

                case var case1 when 21 <= case1 && case1 <= 32:
                    {
                        return new DateTime(1800 + int.Parse(inputEgn.Substring(0, 2)), Month - 20, int.Parse(inputEgn.Substring(4, 2)));
                    }

                case var case2 when 41 <= case2 && case2 <= 52:
                    {
                        return new DateTime(2000 + int.Parse(inputEgn.Substring(0, 2)), Month - 40, int.Parse(inputEgn.Substring(4, 2)));
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException(nameof(inputEgn), $"Invalid {nameof(Egn)} format (month).");
                    }
            }
        }

        #endregion

    }

}
