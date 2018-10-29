using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Hackpro.LocatorsPerformance.RestClient
{
    [ExcludeFromCodeCoverage]
    public class APIRestClient
    {
        private readonly HttpClient _httpClient;

        public APIRestClient()
        {
            _httpClient = new HttpClient();
            _disposing = false;
        }

        protected async Task<HttpResponseMessage> Get(Uri endpoint, string resource, Dictionary<string, string> headers, Dictionary<string, string> queryString)
        {
            List<string> listQueryString = queryString.Select(parameter => parameter.Key + "=" + parameter.Value).ToList();

            string joinQueryString = string.Join("&", listQueryString);

            if (!string.IsNullOrWhiteSpace(joinQueryString))
            {
                resource = resource + "?" + joinQueryString;
            }

            _httpClient.BaseAddress = endpoint;
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            foreach (var header in headers)
            {
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
            }
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(resource);
                return response;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }


        protected HttpResponseMessage Post(Uri endpoint, string resource, Dictionary<string, string> headers, object body)
        {
            _httpClient.BaseAddress = endpoint;
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            foreach (var header in headers)
            {
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
            }
            try
            {
                HttpResponseMessage response = _httpClient.PostAsJsonAsync(resource, body).Result;
                return response;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }

        protected HttpResponseMessage Delete(Uri endpoint, string resource, Dictionary<string, string> headers)
        {
            _httpClient.BaseAddress = endpoint;
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            foreach (var header in headers)
            {
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
            }
            try
            {
                HttpResponseMessage response = _httpClient.DeleteAsync(resource).Result;
                return response;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }

        #region IDisposable Support
        private bool _disposing;

        /// <summary>Releases the unmanaged resources used by <see cref="APIRestClient"/> and optionally disposes of the managed resources.</summary>
        /// <param name="dispose"> <see langword="true"> to release both managed and unmanaged resources; <see langword="false"> to releases only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposing) return;
            if (disposing)
            {
                _httpClient.Dispose();
            }
            _disposing = true;
        }


        /// <summary>Releases the unmanaged resources and disposes of the managed resources used by the <see cref="APIRestClient"/>.</summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}