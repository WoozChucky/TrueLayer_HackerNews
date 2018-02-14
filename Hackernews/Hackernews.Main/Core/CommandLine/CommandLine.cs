using System;

namespace Hackernews.Core.CommandLine
{
    public class CommandLine : ICommandLine
    {
        private const string PostsKey = "--posts";

        public void Parse(string[] args, Action<int> callback)
        {
            if (args == null)
            {
                throw new NullReferenceException("No arguments were provided");
            }
            
            if (args.Length != 2)
            {
                throw new ArgumentException("Invalid number of arguments.");   
            }
            
            if (callback == null)
            {
                throw new NullReferenceException(nameof(callback));
            }
                
            var argumentKey = args[0];
            var argumentValue = args[1];

            if (string.IsNullOrEmpty(argumentKey))
            {
                throw new NullReferenceException("Parameter is invalid.");
            }

            if (string.IsNullOrEmpty(argumentValue))
            {
                throw new NullReferenceException($"Argument value of parameter {argumentKey} is invalid.");
            }

            if(argumentKey != PostsKey)
            {
                throw new ArgumentException($"Parameter {argumentKey} is invalid.");
            }

            if (int.TryParse(argumentValue, out var postsNumber)) 
            {
                if(postsNumber <= 0 || postsNumber >= 100) 
                {
                    throw new ArgumentException($"Parameter argument {postsNumber} must be a positive integer up to 99.");
                }

                callback(postsNumber);
            } 
            else 
            {
                throw new ArgumentException($"Parameter argument {argumentValue} must be a positive integer up to 99.");
            }
        }

        public void ShowUsage()
        {
            Console.WriteLine("\nExample usage:");
            Console.WriteLine($"\t./hackernews {PostsKey} 5");
            Console.WriteLine("\t(Will display Top 5 stories in JSON format)");
        }
    }
}
