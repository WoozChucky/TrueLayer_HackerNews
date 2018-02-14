using System;
using System.Collections.Generic;
using Hackernews.Core;
using Hackernews.Core.CommandLine;
using Hackernews.Core.HTTP;
using Hackernews.Core.Model;

namespace Hackernews
{
    class Program
    {

        static void Main(string[] args)
        {
            ICommandLine commandLine = new CommandLine();

            try {
                commandLine.Parse(args, HandlePostArgument);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                commandLine.ShowUsage();
            }
            Console.ReadKey();
        }

        private static void HandlePostArgument(int postsCount)
        {

            if(!Utils.HasValidInternetConnection())
            {
                Console.WriteLine("No Internet connection was found. Aborting...");
                return;
            }

            IHackernewsAPI api = new HackernewsAPI("https://hacker-news.firebaseio.com/", "v0/");
            var validPostsCount = 0;
            var validPosts = new List<Post>();

            // Fetch top 500 post ids
            var postsIds = api.GetTopPostsIds();

            //Iterate each id and get the corresponding post details from api
            foreach (var id in postsIds) {

                var item = api.GetPost(id);

                //Validate que post information
                if(Utils.IsValidPost(item))
                {
                    validPosts.Add(item.ToPost(validPostsCount + 1));
                    validPostsCount++;
                }
                
                if (validPostsCount == postsCount) break;
            }

            //Convert the posts to a JSON readable format
            var output = Utils.ConvertToPrettyJSON(validPosts);

            Console.WriteLine(output);
        }


    }
}