using System;
using System.Collections.Generic;
using System.Linq;

namespace Refactor
{
    class PasswordChecker
    {
        private readonly IRepository _repo;
        private readonly List<IStrategyR> _str;
        private bool _tp = true;
        private string _mess = String.Empty;

        public PasswordChecker(IRepository repo, List<IStrategyR> strategy)
        {
            _repo = repo;
            _str = strategy;
        }

        public Tuple<bool, string> Verify(string password, bool isAdmin = false)
        {
            CheckStrategies(password, isAdmin);
            if (_tp != true) return Tuple.Create(false, _mess);
            _repo.Create(password, isAdmin);
            return Tuple.Create(true, "Password is Ok. User was created");
        }

        private void CheckStrategies(string password, bool isAdmin)
        {
            foreach (var inneritem in _str.Select(item => item.VerifyRule(password, isAdmin)).Where(inneritem => !inneritem.Item1))
            {
                _mess = inneritem.Item2;
                _tp = false;
                break;
            }
        }
    }
}
