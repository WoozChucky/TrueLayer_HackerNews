using System;
using Hackernews.Core.CommandLine;

namespace Hackernews
{
    public class CommandLine : ICommandLine
    {
        private const string PostsKey = "--posts";

        public void Parse(string[] args, Action<int> callback)
        {
            if (args.Length != 2)
            {
                throw new Exception("Invalid number of arguments.");   
            }
                
            var argumentKey = args[0];
            var argumentValue = args[1];

            if(argumentKey != PostsKey)
            {
                throw new Exception($"Parameter {argumentKey} is invalid.");
            }

            if (int.TryParse(argumentValue, out var postsNumber)) 
            {
                if(postsNumber <= 0 || postsNumber >= 100) 
                {
                    throw new Exception($"Parameter {postsNumber} must be a positive integer up to 99.");
                }

                callback(postsNumber);
            } 
            else 
            {
                throw new Exception($"Parameter {argumentValue} must be a positive integer up to 99.");
            }
        }

        public void ShowUsage()
        {
            throw new NotImplementedException();
        }
    }
}
