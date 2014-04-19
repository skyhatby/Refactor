using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactor;
using Rhino.Mocks;

namespace PasswordCheckerUnitTests
{
    [TestClass]
    public class PasswordCheckerUnitTest
    {
        static readonly List<IStrategyR> St = new List<IStrategyR>
            {
                new NotNullStrategy(),
                new IsAdminStrategy(),
                new LengthAdminStrategy(),
                new LengthStrategy(),
                new NoAlphanumericalCharsStrategy(),
                new NoDigitsStrategy()
            };

        [TestMethod]
        public void PswrdChekerTest()
        {
            var mock = new MockRepository();
            var mockRepository = mock.DynamicMock<IRepository>();
            const string pass = "asdfqwea1%";

            using (mock.Record())
            {
                mockRepository.Expect(x => x.Create(pass,false));
            }

            using (mock.Playback())
            {
                var pcheker = new PasswordChecker(mockRepository, St);
                pcheker.Verify(pass, false);
            }
        }
    }
}
