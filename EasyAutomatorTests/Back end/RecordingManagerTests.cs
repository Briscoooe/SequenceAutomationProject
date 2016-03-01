using Microsoft.VisualStudio.TestTools.UnitTesting;
using SequenceAutomation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SequenceAutomation.Tests
{
    [TestClass()]
    public class RecordingManagerTests
    {
        RecordingManager recManager = new RecordingManager();
        string fullPath, rawJson, infoJson;

        [TestMethod()]
        public void validateJsonTest()
        {
            fullPath = "C:\\Users\\Brian\\Desktop\\invalid_format.json";
            Assert.IsFalse(recManager.validateJson(File.ReadAllText(fullPath)));

            fullPath = "C:\\Users\\Brian\\Desktop\\invalid_format_2.json";
            Assert.IsFalse(recManager.validateJson(File.ReadAllText(fullPath)));

            fullPath = "C:\\Users\\Brian\\Desktop\\invalid_key_at_start.json";
            Assert.IsFalse(recManager.validateJson(File.ReadAllText(fullPath)));

            fullPath = "C:\\Users\\Brian\\Desktop\\valid_key_at_start.json";
            Assert.IsTrue(recManager.validateJson(File.ReadAllText(fullPath)));

            fullPath = "C:\\Users\\Brian\\Desktop\\Helloworld_no_info.json";
            Assert.IsTrue(recManager.validateJson(File.ReadAllText(fullPath)));

            fullPath = "C:\\Users\\Brian\\Desktop\\valid_key_at_end.json";
            Assert.IsTrue(recManager.validateJson(File.ReadAllText(fullPath)));

            fullPath = "C:\\Users\\Brian\\Desktop\\invalid_key_at_end.json";
            Assert.IsTrue(recManager.validateJson(File.ReadAllText(fullPath)));

            fullPath = "C:\\Users\\Brian\\Desktop\\CharlieKellyexcited.json";
            Assert.IsTrue(recManager.validateJson(File.ReadAllText(fullPath)));

            fullPath = "C:\\Users\\Brian\\Desktop\\Helloworld.json";
            Assert.IsTrue(recManager.validateJson(File.ReadAllText(fullPath)));

            fullPath = "C:\\Users\\Brian\\Desktop\\Helloworld_no_info.json";
            Assert.IsTrue(recManager.validateJson(File.ReadAllText(fullPath)));

            fullPath = "C:\\Users\\Brian\\Desktop\\Spotify.json";
            Assert.IsTrue(recManager.validateJson(File.ReadAllText(fullPath)));
        }

        [TestMethod()]
        public void addInformationTest()
        {
            fullPath = "C:\\Users\\Brian\\Desktop\\Helloworld_no_info.json";
            rawJson = File.ReadAllText(fullPath);

            infoJson = recManager.addInformation(rawJson, "", "");
            Assert.IsTrue(recManager.validateJson(infoJson));

            infoJson = recManager.addInformation(rawJson, "test", "test");
            Assert.IsTrue(recManager.validateJson(infoJson));

            infoJson = recManager.addInformation(rawJson, "0", "0");
            Assert.IsTrue(recManager.validateJson(infoJson));

            string fullPath2 = "C:\\Users\\Brian\\Desktop\\Helloworld.json";
            string helloWorld = File.ReadAllText(fullPath2);

            infoJson = recManager.addInformation(rawJson, "Hello world", "Opens notepad, types \"Hello world!\"");
            Assert.IsTrue(recManager.validateJson(infoJson));

            Assert.AreEqual(helloWorld, infoJson);
        }
    }
}