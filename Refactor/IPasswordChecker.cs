using System;

namespace Refactor
{
    public interface IPasswordChecker
    {
        Tuple<bool, string> Verify(string password, bool isAdmin);
    }
}
