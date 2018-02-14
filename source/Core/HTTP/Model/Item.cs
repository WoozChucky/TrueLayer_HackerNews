using System.Collections.Generic;

namespace Hackernews.Core.HTTP.Model
{
    public sealed class Item
    {
        public long Id
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string URL
        {
            get;
            set;
        }

        public string By
        {
            get;
            set;
        }

        public int Score
        {
            get;
            set;
        }

        public List<long> Kids
        {
            get;
            set;
        }
    }
}
