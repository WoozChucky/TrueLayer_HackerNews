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
        public void Parse_With_NoArguments()
        {
            ICommandLine commandLine = new CommandLine();

            var args = new string[0];

            Assert.ThrowsException<ArgumentException>(() => { commandLine.Parse(args, obj => { }); },
                "Failed with no arguments expected");
        }
        
        [TestMethod]
        public void Parse_With_NullArguments()
        {
            ICommandLine commandLine = new CommandLine();

            Assert.ThrowsException<NullReferenceException>(() => { commandLine.Parse(null, obj => { }); },
                "Failed with null arguments expected");
        }
        
        [TestMethod]
        public void Parse_With_InvalidArgumentNumber()
        {
            ICommandLine commandLine = new CommandLine();

            var args = new[] {"a", "b", "c"};

            Assert.ThrowsException<ArgumentException>(() => { commandLine.Parse(args, obj => { }); },
                "Failed with invalid arguments number expected");
        }
        
        [TestMethod]
        public void Parse_With_NullCallback()
        {
            ICommandLine commandLine = new CommandLine();

            var args = new[] {"a", "b"};

            Assert.ThrowsException<NullReferenceException>(() => { commandLine.Parse(args, null); },
                "Failed with null callback expected");
        }
        
        [TestMethod]
        public void Parse_With_WrongParameterKey()
        {
            ICommandLine commandLine = new CommandLine();

            var args = new[] {"--pos", "10"};

            Assert.ThrowsException<ArgumentException>(() => { commandLine.Parse(args, obj => {}); },
                "Failed with invalid parameter key expected");
        }
        
        [TestMethod]
        public void Parse_With_NullParameterKey()
        {
            ICommandLine commandLine = new CommandLine();

            var args = new[] {null, "10"};

            Assert.ThrowsException<NullReferenceException>(() => { commandLine.Parse(args, obj => {}); },
                "Failed with null parameter key expected");
        }
        
        [TestMethod]
        public void Parse_With_NullParameterValue()
        {
            ICommandLine commandLine = new CommandLine();

            var args = new[] {"a", null};

            Assert.ThrowsException<NullReferenceException>(() => { commandLine.Parse(args, obj => {}); },
                "Failed with null parameter value expected");
        }
        
        [TestMethod]
        public void Parse_With_InvalidArgumentKey()
        {
            ICommandLine commandLine = new CommandLine();

            var args = new[] {"a", "a"};

            Assert.ThrowsException<ArgumentException>(() => { commandLine.Parse(args, obj => {}); },
                "Failed with invalid argument key expected");
        }
        
        [TestMethod]
        public void Parse_With_InvalidArgumentValue_Type()
        {
            ICommandLine commandLine = new CommandLine();

            var args = new[] {"--posts", "a"};

            Assert.ThrowsException<ArgumentException>(() => { commandLine.Parse(args, obj => {}); },
                "Failed with invalid argument value type expected");
        }
        
        [TestMethod]
        public void Parse_With_InvalidArgumentValue_Range()
        {
            ICommandLine commandLine = new CommandLine();

            var args = new[] {"--posts", "250"};

            Assert.ThrowsException<ArgumentException>(() => { commandLine.Parse(args, obj => {}); },
                "Failed with invalid argument value range expected");
        }
        
        [TestMethod]
        public void Parse_With_Valid_Input()
        {
            ICommandLine commandLine = new CommandLine();

            const int inputValue = 10;

            var args = new[] {"--posts", inputValue.ToString() };
            
            commandLine.Parse(args, value =>
            {
                Assert.AreEqual(inputValue, value, "Failed with callback value different from input value");
            });
        }
    }
}
