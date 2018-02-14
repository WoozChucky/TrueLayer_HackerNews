using System.Collections.Generic;
using System.Threading.Tasks;
using Hackernews.Core.HTTP.Model;

namespace Hackernews.Core.HTTP
{
    /// <summary>
    /// Hackernews API wrapper that hides all Http requests and responses boilerplate.
    /// </summary>
    public interface IHackernewsAPI
    {
        /// <summary>
        /// Gets the Hackernews API base URL.
        /// </summary>
        /// <value>The base URL.</value>
        string BaseURL { get; set; }

        /// <summary>
        /// Gets the Hackernews API Version.
        /// </summary>
        /// <value>The API Version.</value>
        string APIVersion { get; set; }

        /// <summary>
        /// Gets the top 500 posts identifiers.
        /// </summary>
        /// <returns>List of 500 posts identifiers.</returns>
        IEnumerable<long> GetTopPostsIds();

        /// <summary>
        /// Gets the top 500 posts identifiers asynchronously.
        /// </summary>
        /// <returns>The top 500 posts identifiers.</returns>
        Task<IEnumerable<long>> GetTopPostsIdsAsync();

        /// <summary>
        /// Gets a specific post from hackernews api.
        /// </summary>
        /// <returns>The post in case of success.</returns>
        /// <param name="id">The post identifier.</param>
        Item GetPost(long id);

        /// <summary>
        /// Gets a specific post from hackernews api asynchronously.
        /// </summary>
        /// <returns>The post in case of success.</returns>
        /// <param name="id">The post identifier.</param>
        Task<Item> GetPostAsync(long id);
    }
}
