using System;
using Hackernews.Core.CommandLine;

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
            }
        }

        static void HandlePostArgument(int posts_count)
        {

        }
    }
}