using System;
namespace Hackernews.Core.CommandLine
{
    public interface ICommandLine
    {
        void ShowUsage();

        void Parse(string[] args, Action<int> callback);
    }
}
