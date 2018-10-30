using Hackpro.LocatorsPerformance.RestClient.Commons;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace Hackpro.LocatorsPerformance.RestClient
{
    [ExcludeFromCodeCoverage]
    public class APISelenium : APIRestClient
    {
        private readonly Uri HostWebDriver;
        private const string DEFAULT_HOST_WEBDRIVER = "http://127.0.0.1:5555/wd/hub";
        
        public APISelenium(string uri)
        {
            HostWebDriver = new Uri(uri);
            _disposing = false;
        }

        public APISelenium()
        {
            HostWebDriver = new Uri(DEFAULT_HOST_WEBDRIVER);
            _disposing = false;
        }

        public async Task<HttpResponseMessage> NewSession(CapabilitiesDto capabilities)
        {
            return await Task.Run(() => Post(HostWebDriver, Commands.NEW_SESSION, new Dictionary<string, string>(), capabilities));
        }

        public async Task<HttpResponseMessage> DeleteSession(string idSession)
        {
            string resource = Commands.DELETE_SESSION.Replace(Commands.ID_SESSION, idSession);
            return await Task.Run(() => Delete(HostWebDriver, resource, new Dictionary<string, string>()));
        }

        #region IDisposable Support
        private bool _disposing;

        /// <summary>Releases the unmanaged resources used by <see cref="APISelenium"/> and optionally disposes of the managed resources.</summary>
        /// <param name="dispose"> <see langword="true"> to release both managed and unmanaged resources; <see langword="false"> to releases only unmanaged resources.</param>
        protected new virtual void Dispose(bool disposing)
        {
            if (_disposing) return;
            if (disposing)
            {
                // Unmanaged resources to Dispose
            }
            _disposing = true;
        }


        /// <summary>Releases the unmanaged resources and disposes of the managed resources used by the <see cref="APISelenium"/>.</summary>
        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            base.Dispose();
        }
        #endregion
    }
}