using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Api.Dto.OAuth;
using Newtonsoft.Json;

namespace Api.Services.Auth
{
    public abstract class AuthServiceBase
    {
        public string LastError { get; protected set; }
        public HttpStatusCode LastRequestStatus { get; protected set; }
        protected readonly HttpClient HttpClient;

        protected AuthServiceBase(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<TResult> GetApiResult<TResult>(
            HttpMethod httpMethod,
            string endPoint,
            OAuthClientSettings credentials = null,
            List<KeyValuePair<string, string>> post = null)
        {
            var request = credentials == default
                ? await GetHttpRequestMessage(httpMethod, endPoint, post)
                : await GetAuthenticatedHttpRequestMessage(httpMethod, endPoint, credentials, post);

            var apiResult = await HttpClient.SendAsync(request);
            ProcessHttpHeaders(apiResult);

            return await GetProcessedResult<TResult>(apiResult);
        }

        protected virtual async Task<HttpRequestMessage> GetHttpRequestMessage(
            HttpMethod httpMethod,
            string endPoint,
            List<KeyValuePair<string, string>> post = null)
        {
            return await Task.Run(() =>
            {
                var result = new HttpRequestMessage(httpMethod, endPoint);
                result.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (post != null)
                {
                    result.Content = new FormUrlEncodedContent(post);
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                }

                return result;
            });
        }

        protected async Task<HttpRequestMessage> GetAuthenticatedHttpRequestMessage(
            HttpMethod httpMethod,
            string endPoint,
            OAuthClientSettings credentials,
            List<KeyValuePair<string, string>> post = null)
        {
            var result = await GetHttpRequestMessage(httpMethod, endPoint, post);

            result.Headers.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes($"{credentials.Id}:{credentials.Secret}"))
            );

            return result;
        }

        /// <summary>
        /// Processes the HTTP headers.
        /// </summary>
        /// <param name="httpResponseMessage">The HTTP response message.</param>
        protected virtual void ProcessHttpHeaders(HttpResponseMessage httpResponseMessage)
        {
            LastRequestStatus = httpResponseMessage.StatusCode;
        }

        /// <summary>
        /// Gets the processed (deserialized) result.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="httpResponseMessage">The HTTP response message.</param>
        /// <returns></returns>
        protected async Task<TResult> GetProcessedResult<TResult>(HttpResponseMessage httpResponseMessage)
        {
            if (!httpResponseMessage.IsSuccessStatusCode)
                throw await GetHttpException(httpResponseMessage);

            return await GetDeserializedResponse<TResult>(httpResponseMessage);
        }

        /// <summary>
        /// Gets the HTTP exception.
        /// </summary>
        /// <param name="httpResponseMessage">The HTTP response message.</param>
        /// <returns></returns>
        protected async Task<Exception> GetHttpException(HttpResponseMessage httpResponseMessage)
        {
            // First set the error message so it can be retrieved
            LastError = await httpResponseMessage.Content.ReadAsStringAsync();

            // Throw exception with information
            try
            {
                httpResponseMessage.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                return e;
            }

            // This should not happen
            return new Exception($"HttpRequestException occured with message: '{LastError}'");
        }

        /// <summary>
        /// Gets the deserialized response from the API.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="httpResponseMessage">The HTTP response message.</param>
        /// <returns></returns>
        protected async Task<TResult> GetDeserializedResponse<TResult>(HttpResponseMessage httpResponseMessage)
        {
            var msgString = await httpResponseMessage.Content.ReadAsStringAsync();

            try
            {
                return JsonConvert.DeserializeObject<TResult>(msgString);
            }
            catch
            {
                return default;
            }
        }
    }
}