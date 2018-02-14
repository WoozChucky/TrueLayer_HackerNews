using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hackernews.UnitTests
{
    /// <summary>
    /// Assert helper methods.
    /// </summary>
    public static class AssertHelper
    {
        /// <summary>
        /// Doeses the not throw.
        /// </summary>
        /// <param name="fn">Function to execute.</param>
        /// <param name="message">Message to display when function throws exception.</param>
        /// <typeparam name="T">The 1st type parameter. Type of Exception to look for.</typeparam>
        public static void DoesNotThrow<T>(Action fn, string message = "")
            where T : Exception {
            try {
                fn.Invoke();
            } catch(T) {
                Assert.Fail(message);
            }
        }
        
        public static void DoesThrow<T>(Action fn, string message = "")
            where T : Exception {
            try {
                fn.Invoke();
            } catch(T) {
                Assert.Fail(message);
            }
        }
    }
}
