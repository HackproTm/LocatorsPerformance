using Hackpro.LocatorsPerformance.RestClient.Commons;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Hackpro.LocatorsPerformance.TestsLocators
{
    [ExcludeFromCodeCoverage]
    public class TestFixtureArgs: IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { Browsers.Chrome, 1 };
            yield return new object[] { Browsers.Firefox, 2 };
            yield return new object[] { Browsers.Opera, 3 };
            yield return new object[] { Browsers.InternetExplorer, 4 };
            yield return new object[] { Browsers.Edge, 5 };
        }
    }
}
