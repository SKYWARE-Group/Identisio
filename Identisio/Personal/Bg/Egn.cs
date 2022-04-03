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

        public override string NativeAbbreviation => "ЕГН";

        public override string NativeName => "Единен граждански номер";

        public bool IsMale { get; private set; }

        public DateTime Birthdate { get; private set; }

        public override bool IsPrivateData => true;

        #endregion

        #region Actions

        // Creation

        public static Egn Parse(string value)
        {
            // Validity check
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(nameof(value));
            if (!_Regex.IsMatch(value.Trim())) throw new ArgumentException(nameof(value), $"Invalid {nameof(Egn)} format");
            if (!IsCheckSumValid(value)) throw new ArgumentException(nameof(value), $"Bad {nameof(Egn)} checksum");

            // Values extraction
            var dateOfBirth = ParseDob(value);
            var isMale = ParseIsMale(value);

            return new Egn(value, isMale, dateOfBirth);
        }

        public static bool TryParse(string value, out Egn result)
        {
            try
            {
                result = Egn.Parse(value);
                return true;
            }
            catch (Exception)
            {
                result = null;
                return false;
            }
        }

        // Validation

        public new static bool Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            if (!_Regex.IsMatch(value.Trim())) return false;
            if (!IsCheckSumValid(value)) return false;
            return true;
        }

        private static bool IsCheckSumValid(string value)
        {
            int sum = 0;
            for (int i = 0; i <= 8; i++) sum += int.Parse(value.Substring(i, 1)) * _Weights[i];
            sum = sum % 11 % 10;
            return sum == int.Parse(value.Substring(9, 1));
        }

        // Data extraction methods

        private static bool ParseIsMale(string value) => int.Parse(value.Substring(8, 1)) % 2 == 0;

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
