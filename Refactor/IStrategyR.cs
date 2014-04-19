using System;

namespace Refactor
{
    public interface IStrategyR 
    {
        Tuple<bool, string> VerifyRule(string password, bool isAdmin);
    }
}
