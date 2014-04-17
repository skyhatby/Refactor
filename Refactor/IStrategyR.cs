using System;

namespace Refactor
{
    interface IStrategyR 
    {
        Tuple<bool, string> VerifyRule(string password, bool isAdmin);
    }
}
