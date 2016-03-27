using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;

namespace SequenceAutomation.Tests
{
    [TestClass()]
    public class PlayRecordingTests
    {
        PlayRecording play;
        string json;

        [TestMethod()]
        public void PlayRecordingTest()
        {
            json = "{ \"593\":{ \"LWin\":{ \"value\":256} },\"683\":{ \"LWin\":{ \"value\":257} },\"1332\":{ \"T\":{ \"value\":256} },\"1402\":{ \"E\":{ \"value\":256} },\"1488\":{ \"T\":{ \"value\":257},\"E\":{ \"value\":257} },\"1582\":{ \"S\":{ \"value\":256} },\"1686\":{ \"T\":{ \"value\":256} },\"1766\":{ \"S\":{ \"value\":257},\"T\":{ \"value\":257} },\"Name\":\"test\",\"Desc\":\"test\",\"recId\":\"5fe03f40-b67f-4fc8-8c57-0a84fd4c9441\",\"userName\":\"test\"}";

            // Assert successful instantiation using a valid json string and time factor
            play = new PlayRecording(json, 1);
            Assert.IsNotNull(play);

            json = "{\"menu\": {\"id\": \"file\",\"value\": \"File\",\"popup\": {\"menuitem\": [{\"value\": \"New\", \"onclick\": \"CreateNewDoc()\"},{\"value\": \"Open\", \"onclick\": \"OpenDoc()\"},{\"value\": \"Close\", \"onclick\": \"CloseDoc}}}";
            // Assert unsuccessful instantiation with an invalid json string
            try
            {
                play = new PlayRecording(json, 1);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.IsTrue(e is JsonReaderException);
            }
        }

        [TestMethod()]
        public void StartTest()
        {
            json = "{ \"593\":{ \"LWin\":{ \"value\":256} },\"683\":{ \"LWin\":{ \"value\":257} },\"1332\":{ \"T\":{ \"value\":256} },\"1402\":{ \"E\":{ \"value\":256} },\"1488\":{ \"T\":{ \"value\":257},\"E\":{ \"value\":257} },\"1582\":{ \"S\":{ \"value\":256} },\"1686\":{ \"T\":{ \"value\":256} },\"1766\":{ \"S\":{ \"value\":257},\"T\":{ \"value\":257} },\"Name\":\"test\",\"Desc\":\"test\",\"recId\":\"5fe03f40-b67f-4fc8-8c57-0a84fd4c9441\",\"userName\":\"test\"}";

            play = new PlayRecording(json, 1);

            Assert.AreEqual(play.Start(), 0);
        }

        [TestMethod()]
        public void StopTest()
        {
            json = "{ \"593\":{ \"LWin\":{ \"value\":256} },\"683\":{ \"LWin\":{ \"value\":257} },\"1332\":{ \"T\":{ \"value\":256} },\"1402\":{ \"E\":{ \"value\":256} },\"1488\":{ \"T\":{ \"value\":257},\"E\":{ \"value\":257} },\"1582\":{ \"S\":{ \"value\":256} },\"1686\":{ \"T\":{ \"value\":256} },\"1766\":{ \"S\":{ \"value\":257},\"T\":{ \"value\":257} },\"Name\":\"test\",\"Desc\":\"test\",\"recId\":\"5fe03f40-b67f-4fc8-8c57-0a84fd4c9441\",\"userName\":\"test\"}";

            play = new PlayRecording(json, 1);

            Assert.IsTrue(play.Stop());
        }
    }
}