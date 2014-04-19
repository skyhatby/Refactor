using System;
using System.Linq;

namespace Refactor
{
    public class NotNullStrategy : IStrategyR
    {
        public Tuple<bool, string> VerifyRule(string password, bool isAdmin)
        {
            return string.IsNullOrEmpty(password) ? Tuple.Create(false, "null password arg") : Tuple.Create(true, String.Empty);
        }
    }

    public class LengthStrategy : IStrategyR
    {
        public Tuple<bool, string> VerifyRule(string password, bool isAdmin)
        {
            return password.Length <= 7 ? Tuple.Create(false, "Length too short") : Tuple.Create(true, String.Empty);
        }
    }

    public class LengthAdminStrategy : IStrategyR
    {
        public Tuple<bool, string> VerifyRule(string password, bool isAdmin)
        {
            return password.Length <= 10 && isAdmin ? Tuple.Create(false, "Length too short for Admin") : Tuple.Create(true, String.Empty);
        }
    }

    public class NoAlphanumericalCharsStrategy : IStrategyR
    {
        public Tuple<bool, string> VerifyRule(string password, bool isAdmin)
        {
            return password.Any(Char.IsLetter) ? Tuple.Create(true, String.Empty) : Tuple.Create(false, "No Alphanumerical chars");
        }
    }

    public class NoDigitsStrategy : IStrategyR
    {
        public Tuple<bool, string> VerifyRule(string password, bool isAdmin)
        {
            return password.Any(Char.IsNumber) ? Tuple.Create(true, String.Empty) : Tuple.Create(false, "No digits");
        }
    }

    public class IsAdminStrategy : IStrategyR
    {
        public Tuple<bool, string> VerifyRule(string password, bool isAdmin)
        {
            if (!isAdmin) return Tuple.Create(true, String.Empty);
            var hasSpecial = password.Any(t => !Char.IsLetterOrDigit(t) && !Char.IsWhiteSpace(t));
            return !hasSpecial ? Tuple.Create(false, "No special symbols for admin role") : Tuple.Create(true, String.Empty);
        }
    }
}
