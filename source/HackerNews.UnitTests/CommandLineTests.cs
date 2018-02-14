using System;
using Hackernews.Core.CommandLine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Hackernews.UnitTests.AssertHelper;

namespace Hackernews.UnitTests
{
    [TestClass]
    public class CommandLineTests
    {
        [TestMethod]
        public void Parse_NoArguments()
        {
            ICommandLine commandLine = new CommandLine();

            string[] args = new string[0];

            DoesNotThrow<ArgumentException>(new Action(() => {
                commandLine.Parse(args, (obj) => { });
            }), "Failed parsing with no arguments");

        }
    }
}
