using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Hackernews.Core.HTTP.Model;
using Newtonsoft.Json;

namespace Hackernews.Core.HTTP
{
    public class HackernewsAPI : IHackernewsAPI
    {
        private readonly HttpClient _client;

        private const string EndpointSuffix = ".json?print=pretty";

        private const string TopStoriesRoute = "topstories";
        private const string ItemRoute = "item/";

        public HackernewsAPI(string baseURL, string apiVersion)
        {
            //Validate URL
            BaseURL = GetValidURL(baseURL);
            APIVersion = apiVersion;

            _client = new HttpClient();
        }

        public string BaseURL { get; set; }

        public string APIVersion { get; set; }

        public Item GetPost(long id)
        {
            var fullUrl = BuildRequestURL(ItemRoute, new string[] { id.ToString() });

            return ExecuteRequest<Item>(fullUrl);
        }

        public async Task<Item> GetPostAsync(long id)
        {
            var fullUrl = BuildRequestURL(ItemRoute, new string[] { id.ToString() });

            return await ExecuteRequestAsync<Item>(fullUrl);
        }

        public IEnumerable<long> GetTopPostsIds()
        {
            var fullUrl = BuildRequestURL(TopStoriesRoute);

            return ExecuteRequest<IEnumerable<long>>(fullUrl);
        }

        public async Task<IEnumerable<long>> GetTopPostsIdsAsync()
        {
            var fullUrl = BuildRequestURL(TopStoriesRoute);

            return await ExecuteRequestAsync<IEnumerable<long>>(fullUrl);
        }

        /// <summary>
        /// Executes the request async.
        /// </summary>
        /// <returns>The request async.</returns>
        /// <param name="url">URL.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        private async Task<T> ExecuteRequestAsync<T>(string url)
        {
            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return default(T);

            var content = await response.Content.ReadAsStringAsync();

            return ConvertResponse<T>(content);
        }

        /// <summary>
        /// Executes the request.
        /// </summary>
        /// <returns>The request.</returns>
        /// <param name="url">URL.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        private T ExecuteRequest<T>(string url)
        {
            var response = _client.GetAsync(url).Result;

            if (!response.IsSuccessStatusCode)
                return default(T);

            var content = response.Content.ReadAsStringAsync().Result;

            return ConvertResponse<T>(content);
        }

        #region Helpers

        /// <summary>
        /// Gets the valid URL.
        /// </summary>
        /// <exception cref="Exception"> Thrown when url passed is invalid. </exception>
        /// <returns>The valid URL.</returns>
        /// <param name="baseUrl">Base URL.</param>
        private static string GetValidURL(string baseUrl) 
        {

            /* Since .NET Framework 4.5 the namespace System.Uri includes RFC-compliant URI support.
             * https://docs.microsoft.com/pt-pt/dotnet/framework/whats-new/index#v45
             * 
             * More information anx usage exmaples can be found here
             * https://docs.microsoft.com/pt-pt/dotnet/api/system.uri?view=netframework-4.5
             */

            if(!Uri.TryCreate(baseUrl, UriKind.RelativeOrAbsolute, out var uri))
            {
                throw new Exception($"{baseUrl} is not a valid Url.");
            }

            return uri.ToString();
        }

        /// <summary>
        /// Converts the response.
        /// </summary>
        /// <returns>The response.</returns>
        /// <param name="json">Json string.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        private T ConvertResponse<T>(string json) 
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// Builds the request URL.
        /// </summary>
        /// <returns>The request URL.</returns>
        /// <param name="route">Route.</param>
        private string BuildRequestURL(string route)
        {
            return BuildRequestURL(route, new string[0]);
        }

        /// <summary>
        /// Builds the request URL.
        /// </summary>
        /// <returns>The request URL.</returns>
        /// <param name="route">Route.</param>
        /// <param name="parameters">Parameters.</param>
        private string BuildRequestURL(string route, params string[] parameters)
        {
            string finalUrl = finalUrl = BaseURL + APIVersion + route;

            //Append parameters if any
            finalUrl = parameters.Aggregate(finalUrl, (current, param) => current + param);

            finalUrl += EndpointSuffix;

            return finalUrl;
        }
        #endregion
    }
}
