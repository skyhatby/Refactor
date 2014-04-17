using System;
using System.Collections.Generic;

namespace Refactor
{
    class Program
    {
        static void Main()
        {
            var st = new List<IStrategyR>()
            {
                new NotNullStrategy(),
                new IsAdminStrategy(),
                new LengthAdminStrategy(),
                new LengthStrategy(),
                new NoAlphanumericalCharsStrategy(),
                new NoDigitsStrategy()
            };
            try
            {
                var pc = new PasswordChecker(new SqlRepository(), st);
                var tp = pc.Verify("asdfqwea1%%",true);
                Console.WriteLine(tp.Item2);
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine("create");
            }
            Console.ReadKey();
        }
    }
}
