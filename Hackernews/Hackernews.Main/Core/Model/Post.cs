using Newtonsoft.Json;

namespace Hackernews.Core.Model
{
    public class Post
    {
        [JsonProperty(PropertyName = "title")]
        public string Title
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "uri")]
        public string URI
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "author")]
        public string Author
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "points")]
        public int Points
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "comments")]
        public int Comments
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "rank")]
        public int Rank
        {
            get;
            set;
        }
    }
}
