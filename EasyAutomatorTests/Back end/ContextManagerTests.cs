﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SequenceAutomation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceAutomation.Tests
{
    [TestClass()]
    public class ContextManagerTests
    {
        ContextManager context;
        Dictionary<long, Dictionary<string, Dictionary<IntPtr, string>>> contextDict;

        [TestMethod()]
        public void ContextManagerTest()
        {
            // Assert that the class can be successfully instantiated
            context = new ContextManager();
            Assert.IsNotNull(context);
        }

        [TestMethod()]
        public void getContextTest()
        {
            context = new ContextManager();
            contextDict = new Dictionary<long, Dictionary<string, Dictionary<IntPtr, string>>>();

            // Assert that each key and value in the dictionary has been assigned a value
            contextDict = context.getContext(5);
            foreach (KeyValuePair<long, Dictionary<string, Dictionary<IntPtr, string>>> kvp in contextDict)
                foreach (KeyValuePair<string, Dictionary<IntPtr, string>> kvp2 in kvp.Value)
                    foreach (KeyValuePair<IntPtr, string> kvp3 in kvp2.Value)
                    {
                        Assert.IsNotNull(kvp.Key);
                        Assert.IsNotNull(kvp.Value);
                        Assert.IsNotNull(kvp2.Key);
                        Assert.IsNotNull(kvp2.Value);
                        Assert.IsNotNull(kvp3.Key);
                        Assert.IsNotNull(kvp3.Value);
                    }
        }

        [TestMethod()]
        public void checkContextTest()
        {
            context = new ContextManager();
            contextDict = new Dictionary<long, Dictionary<string, Dictionary<IntPtr, string>>>();

            // Assert that two contexts can be compared successfully
            contextDict = context.getContext(5);
            Assert.IsTrue(context.checkContext(5, contextDict));


            // Assert that adding a new window title will result in a failure of the context check
            Dictionary<long, Dictionary<string, Dictionary<IntPtr, string>>> contextDict2 = new Dictionary<long, Dictionary<string, Dictionary<IntPtr, string>>>();
            contextDict2 = contextDict;

            foreach (KeyValuePair<long, Dictionary<string, Dictionary<IntPtr, string>>> kvp in contextDict2)
            {
                IntPtr x = new IntPtr(1024 * 1000);
                contextDict[kvp.Key]["Open windows"].Add(x, "Random window title");
            }

            Assert.IsFalse(context.checkContext(5, contextDict));
        }

        [TestMethod()]
        public void GetOpenWindowsTest()
        {
            context = new ContextManager();
            Dictionary<IntPtr, string> windows = new Dictionary<IntPtr, string>();

            // Assert that the list of open windows can be successfully obtained
            windows = context.GetOpenWindows();

            foreach(KeyValuePair<IntPtr, string> kvp in windows)
            {
                Assert.IsNotNull(kvp.Key);
                Assert.IsNotNull(kvp.Value);
            }
        }
    }
}