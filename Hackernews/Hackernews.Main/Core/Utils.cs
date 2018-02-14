using System;
using System.Net;
using Hackernews.Core.HTTP.Model;
using Newtonsoft.Json;

namespace Hackernews.Core
{
    /// <summary>
    /// Utility class that holds some helper methods
    /// </summary>
    internal static class Utils
    {
        
        /// <summary>
        /// Checks for a valid internet connection.
        /// 
        /// NOTE: There is absolutely no way you can reliably check if there is an internet connection or not.
        /// We can however,request resources that are virtually never offline, like pinging google.com or something similar.
        /// This probably won't work in China for example.
        /// </summary>
        /// <returns><c>true</c>, if valid internet connection was found, <c>false</c> otherwise.</returns>
        internal static bool HasValidInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (client.OpenRead("http://clients3.google.com/generate_204"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Converts an object in a formatted & idented JSON string
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when object passed is null. </exception>
        /// <returns>The formatted json.</returns>
        /// <param name="obj">Object to convert.</param>
        internal static string ConvertToPrettyJSON(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        /// <summary>
        /// Validates a post according to https://gist.github.com/lucamartinetti/01b2d3b05cd19a42e2d494202a951175#input-arguments rules.
        /// </summary>
        /// <returns><c>true</c>, if valid post, <c>false</c> otherwise.</returns>
        /// <param name="item">Item.</param>
        internal static bool IsValidPost(Item item)
        {
            //Title and Author are non empty string not longer than 256 characters
            //uri is a valid URI
            //points, comments and rank are integers => 0

            if (string.IsNullOrEmpty(item.Title) || string.IsNullOrEmpty(item.By) || string.IsNullOrEmpty(item.URL))
                return false;

            if (item.Title.Length > 256 || item.By.Length > 256)
                return false;

            if (!Uri.TryCreate(item.URL, UriKind.RelativeOrAbsolute, out var uri))
                return false;

            if (item.Score < 0 || (item.Kids == null || item.Kids.Count < 0))
                return false;

            return true;
        }
    }
}
