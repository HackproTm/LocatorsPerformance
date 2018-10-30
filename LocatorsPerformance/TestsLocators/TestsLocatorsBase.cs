using Hackpro.LocatorsPerformance.RestClient;
using Hackpro.LocatorsPerformance.RestClient.Commons;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hackpro.LocatorsPerformance.TestsLocators
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    [TestFixtureSource(sourceType: typeof(TestFixtureArgs))]
    public class TestsLocatorsBase : IDisposable
    {
        private APISelenium _apiSelenium;
        private HttpResponseMessage _response;
        private string _idSession;
        private Browsers _browserName;
        private int _number;

        public TestsLocatorsBase(Browsers browserName, int number)
        {
            _browserName = browserName;
            _number = number;
            _disposing = false;
        }

        [SetUp]
        public async Task StartTests(string uri)
        {
            _apiSelenium = new APISelenium(uri);
            _response = await _apiSelenium.NewSession(CapabilitiesDto.GetDefaultCapabilities(_browserName));

        }

        [Test]
        public async Task GetLocator()
        {
            _response = await _apiSelenium.DeleteSession(_idSession);
        }

        [TearDown]
        public async Task FinishTests()
        {
            _response = await _apiSelenium.DeleteSession(_idSession);
            _apiSelenium.Dispose();
        }

        #region IDisposable Support
        private bool _disposing;

        /// <summary>Releases the unmanaged resources used by <see cref="TestsLocatorsBase"/> and optionally disposes of the managed resources.</summary>
        /// <param name="dispose"> <see langword="true"> to release both managed and unmanaged resources; <see langword="false"> to releases only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposing) return;
            if (disposing)
            {
                _apiSelenium.Dispose();
            }
            _disposing = true;
        }


        /// <summary>Releases the unmanaged resources and disposes of the managed resources used by the <see cref="TestsLocatorsBase"/>.</summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
