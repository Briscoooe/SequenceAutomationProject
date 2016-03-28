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
            // Valid JSON string
            json = "{\"3464\":{\"LWin\":{\"value\":256}},\"3543\":{\"LWin\":{\"value\":257}},\"3906\":{\"N\":{\"value\":256}},\"4001\":{\"N\":{\"value\":257}},\"4048\":{\"O\":{\"value\":256}},\"4159\":{\"O\":{\"value\":257}},\"4188\":{\"T\":{\"value\":256}},\"4243\":{\"E\":{\"value\":256}},\"4322\":{\"T\":{\"value\":257}},\"4368\":{\"E\":{\"value\":257}},\"4449\":{\"P\":{\"value\":256}},\"4541\":{\"A\":{\"value\":256}},\"4559\":{\"P\":{\"value\":257}},\"4667\":{\"D\":{\"value\":256}},\"4705\":{\"A\":{\"value\":257}},\"4769\":{\"D\":{\"value\":257}},\"5090\":{\"Return\":{\"value\":256},\"Open windows\":{\"788720\":\"Easy Automator\",\"787150\":\"EasyAutomator (Running) - Microsoft Visual Studio\",\"4653890\":\"Recordings\",\"2949282\":\"Final Report_formatted_v2.docx - Word\",\"2427250\":\"Interim Report\",\"1704526\":\"Tools\",\"1638498\":\"History\",\"4523202\":\"Layers\",\"3016774\":\"Colors\",\"3933764\":\"Use_Case.PNG - paint.net 4.0.9\",\"4327206\":\"Snipping Tool\",\"5048204\":\"\u2022 Use case diagram_v10.mdj \u2014 StarUML (UNREGISTERED)\",\"1114226\":\"Violet UML Editor\",\"3736688\":\"Sequence_Download+Play.PNG - Windows Photo Viewer\",\"5244472\":\"Settings\",\"2034060\":\"Sequence_Create+Upload.PNG - Windows Photo Viewer\",\"5834602\":\"Calculator\",\"22481286\":\"Calculator\",\"5571430\":\"Settings\",\"131226\":\"Windows Shell Experience Host\",\"2491466\":\"Google Play Music Desktop Player\"}},\"5193\":{\"Return\":{\"value\":257}},\"5610\":{\"A\":{\"value\":256}},\"5721\":{\"A\":{\"value\":257}},\"5921\":{\"B\":{\"value\":256}},\"6015\":{\"B\":{\"value\":257}},\"6165\":{\"C\":{\"value\":256}},\"6252\":{\"C\":{\"value\":257}},\"6657\":{\"Capital\":{\"value\":256}},\"6744\":{\"Capital\":{\"value\":257}}," +
                            "\"Name\":\"ABC\",\"Desc\":\"Opens the notepad, types ABC\",\"recId\":\"a47dddeffff233327a431186217c2c66d1c05bbb875f4c0324148b9a344a05cd\",\"AuthorFirstname\":\"Brian\",\"AuthorSurname\":\"Briscoe\",\"UserId\":\"b2ccb37d78e78182f80397edbc456f085778896427791cd4840bfc315f418451\"}";
            // Assert successful instantiation using a valid json string and time factor
            play = new PlayRecording(json, 1);
            Assert.IsNotNull(play);

            // Assert unsuccessful instantiation with a JSON string with no keys dictionary
            try
            {
                json = "{ \"\"Name\":\"ABC\",\"Desc\":\"Opens the notepad, types ABC\",\"recId\":\"a47dddeffff233327a431186217c2c66d1c05bbb875f4c0324148b9a344a05cd\",\"AuthorFirstname\":\"Brian\",\"AuthorSurname\":\"Briscoe\",\"UserId\":\"b2ccb37d78e78182f80397edbc456f085778896427791cd4840bfc315f418451\"}";
                play = new PlayRecording(json, 1);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.IsTrue(e is JsonReaderException);
            }


            // Assert unsuccessful instantiation with an invalid json string
            try
            {
                json = "{\"menu\": {\"id\": \"file\",\"value\": \"File\",\"popup\": {\"menuitem\": [{\"value\": \"New\", \"onclick\": \"CreateNewDoc()\"},{\"value\": \"Open\", \"onclick\": \"OpenDoc()\"},{\"value\": \"Close\", \"onclick\": \"CloseDoc}}}";
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