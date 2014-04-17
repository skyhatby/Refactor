using System;
using System.Linq;

namespace Refactor
{
    class NotNullStrategy : IStrategyR
    {
        public Tuple<bool, string> VerifyRule(string password, bool isAdmin)
        {
            return string.IsNullOrEmpty(password) ? Tuple.Create(false, "null password arg") : Tuple.Create(true, password);
        }
    }

    class LengthStrategy : IStrategyR
    {
        public Tuple<bool, string> VerifyRule(string password, bool isAdmin)
        {
            return password.Length <= 7 ? Tuple.Create(false, "Length too short") : Tuple.Create(true, password);
        }
    }

    class LengthAdminStrategy : IStrategyR
    {
        public Tuple<bool, string> VerifyRule(string password, bool isAdmin)
        {
            if (password.Length <= 10 && isAdmin)
                return Tuple.Create(false, "Length too short for Admin");
            return Tuple.Create(true, password);
        }
    }

    class NoAlphanumericalCharsStrategy : IStrategyR
    {
        public Tuple<bool, string> VerifyRule(string password, bool isAdmin)
        {
            return password.Any(Char.IsLetter) ? Tuple.Create(true, password) : Tuple.Create(false, "No Alphanumerical chars");
        }
    }

    class NoDigitsStrategy : IStrategyR
    {
        public Tuple<bool, string> VerifyRule(string password, bool isAdmin)
        {
            return password.Any(Char.IsNumber) ? Tuple.Create(true, password) : Tuple.Create(false, "No digits");
        }
    }

    class IsAdminStrategy : IStrategyR
    {
        public Tuple<bool, string> VerifyRule(string password, bool isAdmin)
        {
            if (!isAdmin) return Tuple.Create(true, password);
            var hasSpecial = password.Any(t => !Char.IsLetterOrDigit(t) && !Char.IsWhiteSpace(t));
            return !hasSpecial ? Tuple.Create(false, "No special symbols for admin role") : Tuple.Create(true, password);
        }
    }
}
