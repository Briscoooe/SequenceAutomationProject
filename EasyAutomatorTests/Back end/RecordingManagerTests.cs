using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Newtonsoft.Json;

namespace SequenceAutomation.Tests
{
    [TestClass()]
    public class RecordingManagerTests
    {
        RecordingManager rec;
        string fullJson;

        [TestMethod()]
        public void RecordingManagerTest_String()
        {
            // Assert that a valid JSON string will instantiate the recManager variable successfully
            fullJson = "{ \"593\":{ \"LWin\":{ \"value\":256} },\"683\":{ \"LWin\":{ \"value\":257} },\"1332\":{ \"T\":{ \"value\":256} },\"1402\":{ \"E\":{ \"value\":256} },\"1488\":{ \"T\":{ \"value\":257},\"E\":{ \"value\":257} },\"1582\":{ \"S\":{ \"value\":256} },\"1686\":{ \"T\":{ \"value\":256} },\"1766\":{ \"S\":{ \"value\":257},\"T\":{ \"value\":257} },\"Name\":\"test\",\"Desc\":\"test\",\"recId\":\"5fe03f40-b67f-4fc8-8c57-0a84fd4c9441\",\"userName\":\"test\"}";
            rec = new RecordingManager(fullJson);
            Assert.IsNotNull(rec.Title);
            Assert.IsNotNull(rec.Id);
            Assert.IsNotNull(rec.Description);
            Assert.IsNotNull(rec.Username);

            // Assert that am invalid JSON string will raise an exception
            try
            {
                fullJson = "{\"menu\": {\"id\": \"file\",\"value\": \"File\",\"popup\": {\"menuitem\": [{\"value\": \"New\", \"onclick\": \"CreateNewDoc()\"},{\"value\": \"Open\", \"onclick\": \"OpenDoc()\"},{\"value\": \"Close\", \"onclick\": \"CloseDoc}}}";
                rec = new RecordingManager(fullJson);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is JsonReaderException);
            }
        }


        [TestMethod()]
        public void validateJsonTest()
        {
            rec = new RecordingManager();

            // Assert that a valid JSON string will return true
            fullJson = "{ \"593\":{ \"LWin\":{ \"value\":256} },\"683\":{ \"LWin\":{ \"value\":257} },\"1332\":{ \"T\":{ \"value\":256} },\"1402\":{ \"E\":{ \"value\":256} },\"1488\":{ \"T\":{ \"value\":257},\"E\":{ \"value\":257} },\"1582\":{ \"S\":{ \"value\":256} },\"1686\":{ \"T\":{ \"value\":256} },\"1766\":{ \"S\":{ \"value\":257},\"T\":{ \"value\":257} },\"Name\":\"test\",\"Desc\":\"test\",\"recId\":\"5fe03f40-b67f-4fc8-8c57-0a84fd4c9441\",\"userName\":\"test\"}";
            Assert.IsTrue(rec.validateJson(fullJson));

            // Assert that a completely invalid JSON string will return false
            fullJson = "{\"menu\": {\"id\": \"file\",\"value\": \"File\",\"popup\": {\"menuitem\": [{\"value\": \"New\", \"onclick\": \"CreateNewDoc()\"},{\"value\": \"Open\", \"onclick\": \"OpenDoc()\"},{\"value\": \"Close\", \"onclick\": \"CloseDoc}}}";
            Assert.IsFalse(rec.validateJson(fullJson));

            // Assert that a JSON string without a username tag will return false;
            fullJson = "{ \"593\":{ \"LWin\":{ \"value\":256} },\"683\":{ \"LWin\":{ \"value\":257} },\"1332\":{ \"T\":{ \"value\":256} },\"1402\":{ \"E\":{ \"value\":256} },\"1488\":{ \"T\":{ \"value\":257},\"E\":{ \"value\":257} },\"1582\":{ \"S\":{ \"value\":256} },\"1686\":{ \"T\":{ \"value\":256} },\"1766\":{ \"S\":{ \"value\":257},\"T\":{ \"value\":257} },\"Name\":\"test\",\"Desc\":\"test\",\"recId\":\"5fe03f40-b67f-4fc8-8c57-0a84fd4c9441\"}";
            Assert.IsFalse(rec.validateJson(fullJson));

            // Assert that a JSON string without a null username value will return false;
            fullJson = "{ \"593\":{ \"LWin\":{ \"value\":256} },\"683\":{ \"LWin\":{ \"value\":257} },\"1332\":{ \"T\":{ \"value\":256} },\"1402\":{ \"E\":{ \"value\":256} },\"1488\":{ \"T\":{ \"value\":257},\"E\":{ \"value\":257} },\"1582\":{ \"S\":{ \"value\":256} },\"1686\":{ \"T\":{ \"value\":256} },\"1766\":{ \"S\":{ \"value\":257},\"T\":{ \"value\":257} },\"Name\":\"test\",\"Desc\":\"test\",\"recId\":\"5fe03f40-b67f-4fc8-8c57-0a84fd4c9441\",\"userName\":\"\"}";
            Assert.IsFalse(rec.validateJson(fullJson));

            // Assert that a JSON string without a title tag will return false;
            fullJson = "{ \"593\":{ \"LWin\":{ \"value\":256} },\"683\":{ \"LWin\":{ \"value\":257} },\"1332\":{ \"T\":{ \"value\":256} },\"1402\":{ \"E\":{ \"value\":256} },\"1488\":{ \"T\":{ \"value\":257},\"E\":{ \"value\":257} },\"1582\":{ \"S\":{ \"value\":256} },\"1686\":{ \"T\":{ \"value\":256} },\"1766\":{ \"S\":{ \"value\":257},\"T\":{ \"value\":257} },\"Desc\":\"test\",\"recId\":\"5fe03f40-b67f-4fc8-8c57-0a84fd4c9441\",\"userName\":\"test\"}";
            Assert.IsFalse(rec.validateJson(fullJson));

            // Assert that a JSON string without a null title value will return false;
            fullJson = "{ \"593\":{ \"LWin\":{ \"value\":256} },\"683\":{ \"LWin\":{ \"value\":257} },\"1332\":{ \"T\":{ \"value\":256} },\"1402\":{ \"E\":{ \"value\":256} },\"1488\":{ \"T\":{ \"value\":257},\"E\":{ \"value\":257} },\"1582\":{ \"S\":{ \"value\":256} },\"1686\":{ \"T\":{ \"value\":256} },\"1766\":{ \"S\":{ \"value\":257},\"T\":{ \"value\":257} },\"Name\":\"\",\"Desc\":\"test\",\"recId\":\"5fe03f40-b67f-4fc8-8c57-0a84fd4c9441\",\"userName\":\"test\"}";
            Assert.IsFalse(rec.validateJson(fullJson));

            // Assert that a JSON string without an ID tag will return false;
            fullJson = "{ \"593\":{ \"LWin\":{ \"value\":256} },\"683\":{ \"LWin\":{ \"value\":257} },\"1332\":{ \"T\":{ \"value\":256} },\"1402\":{ \"E\":{ \"value\":256} },\"1488\":{ \"T\":{ \"value\":257},\"E\":{ \"value\":257} },\"1582\":{ \"S\":{ \"value\":256} },\"1686\":{ \"T\":{ \"value\":256} },\"1766\":{ \"S\":{ \"value\":257},\"T\":{ \"value\":257} },\"Name\":\"test\",\"Desc\":\"test\",\"userName\":\"test\"}";
            Assert.IsFalse(rec.validateJson(fullJson));

            // Assert that a JSON string without a null ID value will return false;
            fullJson = "{ \"593\":{ \"LWin\":{ \"value\":256} },\"683\":{ \"LWin\":{ \"value\":257} },\"1332\":{ \"T\":{ \"value\":256} },\"1402\":{ \"E\":{ \"value\":256} },\"1488\":{ \"T\":{ \"value\":257},\"E\":{ \"value\":257} },\"1582\":{ \"S\":{ \"value\":256} },\"1686\":{ \"T\":{ \"value\":256} },\"1766\":{ \"S\":{ \"value\":257},\"T\":{ \"value\":257} },\"Name\":\"test\",\"Desc\":\"test\",\"recId\":\"\",\"userName\":\"test\"}";
            Assert.IsFalse(rec.validateJson(fullJson));

            // Assert that a JSON string without a description tag will return false;
            fullJson = "{ \"593\":{ \"LWin\":{ \"value\":256} },\"683\":{ \"LWin\":{ \"value\":257} },\"1332\":{ \"T\":{ \"value\":256} },\"1402\":{ \"E\":{ \"value\":256} },\"1488\":{ \"T\":{ \"value\":257},\"E\":{ \"value\":257} },\"1582\":{ \"S\":{ \"value\":256} },\"1686\":{ \"T\":{ \"value\":256} },\"1766\":{ \"S\":{ \"value\":257},\"T\":{ \"value\":257} },\"Name\":\"test\",\"recId\":\"5fe03f40-b67f-4fc8-8c57-0a84fd4c9441\",\"userName\":\"test\"}";
            Assert.IsFalse(rec.validateJson(fullJson));

            // Assert that a JSON string without a null description value will return false;
            fullJson = "{ \"593\":{ \"LWin\":{ \"value\":256} },\"683\":{ \"LWin\":{ \"value\":257} },\"1332\":{ \"T\":{ \"value\":256} },\"1402\":{ \"E\":{ \"value\":256} },\"1488\":{ \"T\":{ \"value\":257},\"E\":{ \"value\":257} },\"1582\":{ \"S\":{ \"value\":256} },\"1686\":{ \"T\":{ \"value\":256} },\"1766\":{ \"S\":{ \"value\":257},\"T\":{ \"value\":257} },\"Name\":\"test\",\"Desc\":\"\",\"recId\":\"5fe03f40-b67f-4fc8-8c57-0a84fd4c9441\",\"userName\":\"test\"}";
            Assert.IsFalse(rec.validateJson(fullJson));
        }

        [TestMethod()]
        public void addInformationTest()
        {
            rec = new RecordingManager();
            fullJson = "{ \"593\":{ \"LWin\":{ \"value\":256} },\"683\":{ \"LWin\":{ \"value\":257} },\"1332\":{ \"T\":{ \"value\":256} },\"1402\":{ \"E\":{ \"value\":256} },\"1488\":{ \"T\":{ \"value\":257},\"E\":{ \"value\":257} },\"1582\":{ \"S\":{ \"value\":256} },\"1686\":{ \"T\":{ \"value\":256} },\"1766\":{ \"S\":{ \"value\":257},\"T\":{ \"value\":257} },\"Name\":\"test\",\"Desc\":\"test\",\"recId\":\"5fe03f40-b67f-4fc8-8c57-0a84fd4c9441\",\"userName\":\"test\"}";
            string rawJson = "{ \"593\":{ \"LWin\":{ \"value\":256} },\"683\":{ \"LWin\":{ \"value\":257} },\"1332\":{ \"T\":{ \"value\":256} },\"1402\":{ \"E\":{ \"value\":256} },\"1488\":{ \"T\":{ \"value\":257},\"E\":{ \"value\":257} },\"1582\":{ \"S\":{ \"value\":256} },\"1686\":{ \"T\":{ \"value\":256} },\"1766\":{ \"S\":{ \"value\":257},\"T\":{ \"value\":257} }}";
            string infoJson = "";
            Properties.Settings.Default.currentUser = "Test";

            // Assert that valid information can be added to a JSON string
            infoJson = rec.addInformation(rawJson, "title", "Description");
            Assert.IsTrue(rec.validateJson(infoJson));

            // Assert that blank information cannot be added to the JSON string
            infoJson = rec.addInformation(rawJson, "", "");
            Assert.IsFalse(rec.validateJson(infoJson));

            // Assert that a blank title will fail to add to the JSON string
            infoJson = rec.addInformation(rawJson, "", "Description");
            Assert.IsFalse(rec.validateJson(infoJson));

            // Assert that a blank description will fail to add to the JSON string
            infoJson = rec.addInformation(rawJson, "Title", "");
            Assert.IsFalse(rec.validateJson(infoJson));

        }
    }
}