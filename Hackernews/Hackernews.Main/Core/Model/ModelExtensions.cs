using System.Linq;
using Hackernews.Core.HTTP.Model;

namespace Hackernews.Core.Model
{
    public static class ModelExtensions
    {
        internal static Post ToPost(this Item item, int index)
        {
            return new Post
            {
                Title = item.Title,
                URI = item.URL,
                Author = item.By,
                Points = item.Score,
                Comments = item.Kids.ToList().Count,
                Rank = index
            };
        }
    }
}
