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
            fullJson = "{\"3464\":{\"LWin\":{\"value\":256}},\"3543\":{\"LWin\":{\"value\":257}},\"3906\":{\"N\":{\"value\":256}},\"4001\":{\"N\":{\"value\":257}},\"4048\":{\"O\":{\"value\":256}},\"4159\":{\"O\":{\"value\":257}},\"4188\":{\"T\":{\"value\":256}},\"4243\":{\"E\":{\"value\":256}},\"4322\":{\"T\":{\"value\":257}},\"4368\":{\"E\":{\"value\":257}},\"4449\":{\"P\":{\"value\":256}},\"4541\":{\"A\":{\"value\":256}},\"4559\":{\"P\":{\"value\":257}},\"4667\":{\"D\":{\"value\":256}},\"4705\":{\"A\":{\"value\":257}},\"4769\":{\"D\":{\"value\":257}},\"5090\":{\"Return\":{\"value\":256},\"Open windows\":{\"788720\":\"Easy Automator\",\"787150\":\"EasyAutomator (Running) - Microsoft Visual Studio\",\"4653890\":\"Recordings\",\"2949282\":\"Final Report_formatted_v2.docx - Word\",\"2427250\":\"Interim Report\",\"1704526\":\"Tools\",\"1638498\":\"History\",\"4523202\":\"Layers\",\"3016774\":\"Colors\",\"3933764\":\"Use_Case.PNG - paint.net 4.0.9\",\"4327206\":\"Snipping Tool\",\"5048204\":\"\u2022 Use case diagram_v10.mdj \u2014 StarUML (UNREGISTERED)\",\"1114226\":\"Violet UML Editor\",\"3736688\":\"Sequence_Download+Play.PNG - Windows Photo Viewer\",\"5244472\":\"Settings\",\"2034060\":\"Sequence_Create+Upload.PNG - Windows Photo Viewer\",\"5834602\":\"Calculator\",\"22481286\":\"Calculator\",\"5571430\":\"Settings\",\"131226\":\"Windows Shell Experience Host\",\"2491466\":\"Google Play Music Desktop Player\"}},\"5193\":{\"Return\":{\"value\":257}},\"5610\":{\"A\":{\"value\":256}},\"5721\":{\"A\":{\"value\":257}},\"5921\":{\"B\":{\"value\":256}},\"6015\":{\"B\":{\"value\":257}},\"6165\":{\"C\":{\"value\":256}},\"6252\":{\"C\":{\"value\":257}},\"6657\":{\"Capital\":{\"value\":256}},\"6744\":{\"Capital\":{\"value\":257}}," +
                            "\"Name\":\"ABC\",\"Desc\":\"Opens the notepad, types ABC\",\"recId\":\"a47dddeffff233327a431186217c2c66d1c05bbb875f4c0324148b9a344a05cd\",\"AuthorFirstname\":\"Brian\",\"AuthorSurname\":\"Briscoe\",\"UserId\":\"b2ccb37d78e78182f80397edbc456f085778896427791cd4840bfc315f418451\"}";
            rec = new RecordingManager(fullJson);
            Assert.IsNotNull(rec.Title);
            Assert.IsNotNull(rec.Id);
            Assert.IsNotNull(rec.Description);
            Assert.IsNotNull(rec.Author);

            // Assert that an invalid JSON string will raise an exception
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

            // Upload a recording in the valid format
            string json = "{\"3464\":{\"LWin\":{\"value\":256}},\"3543\":{\"LWin\":{\"value\":257}},\"3906\":{\"N\":{\"value\":256}},\"4001\":{\"N\":{\"value\":257}},\"4048\":{\"O\":{\"value\":256}},\"4159\":{\"O\":{\"value\":257}},\"4188\":{\"T\":{\"value\":256}},\"4243\":{\"E\":{\"value\":256}},\"4322\":{\"T\":{\"value\":257}},\"4368\":{\"E\":{\"value\":257}},\"4449\":{\"P\":{\"value\":256}},\"4541\":{\"A\":{\"value\":256}},\"4559\":{\"P\":{\"value\":257}},\"4667\":{\"D\":{\"value\":256}},\"4705\":{\"A\":{\"value\":257}},\"4769\":{\"D\":{\"value\":257}},\"5090\":{\"Return\":{\"value\":256},\"Open windows\":{\"788720\":\"Easy Automator\",\"787150\":\"EasyAutomator (Running) - Microsoft Visual Studio\",\"4653890\":\"Recordings\",\"2949282\":\"Final Report_formatted_v2.docx - Word\",\"2427250\":\"Interim Report\",\"1704526\":\"Tools\",\"1638498\":\"History\",\"4523202\":\"Layers\",\"3016774\":\"Colors\",\"3933764\":\"Use_Case.PNG - paint.net 4.0.9\",\"4327206\":\"Snipping Tool\",\"5048204\":\"\u2022 Use case diagram_v10.mdj \u2014 StarUML (UNREGISTERED)\",\"1114226\":\"Violet UML Editor\",\"3736688\":\"Sequence_Download+Play.PNG - Windows Photo Viewer\",\"5244472\":\"Settings\",\"2034060\":\"Sequence_Create+Upload.PNG - Windows Photo Viewer\",\"5834602\":\"Calculator\",\"22481286\":\"Calculator\",\"5571430\":\"Settings\",\"131226\":\"Windows Shell Experience Host\",\"2491466\":\"Google Play Music Desktop Player\"}},\"5193\":{\"Return\":{\"value\":257}},\"5610\":{\"A\":{\"value\":256}},\"5721\":{\"A\":{\"value\":257}},\"5921\":{\"B\":{\"value\":256}},\"6015\":{\"B\":{\"value\":257}},\"6165\":{\"C\":{\"value\":256}},\"6252\":{\"C\":{\"value\":257}},\"6657\":{\"Capital\":{\"value\":256}},\"6744\":{\"Capital\":{\"value\":257}}," +
                            "\"Name\":\"ABC\",\"Desc\":\"Opens the notepad, types ABC\",\"recId\":\"a47dddeffff233327a431186217c2c66d1c05bbb875f4c0324148b9a344a05cd\",\"AuthorFirstname\":\"Brian\",\"AuthorSurname\":\"Briscoe\",\"UserId\":\"b2ccb37d78e78182f80397edbc456f085778896427791cd4840bfc315f418451\"}";
            Assert.IsTrue(RecordingManager.validateJson(json));

            // Upload a recording with a null title
            json = "{\"3464\":{\"LWin\":{\"value\":256}},\"3543\":{\"LWin\":{\"value\":257}},\"3906\":{\"N\":{\"value\":256}},\"4001\":{\"N\":{\"value\":257}},\"4048\":{\"O\":{\"value\":256}},\"4159\":{\"O\":{\"value\":257}},\"4188\":{\"T\":{\"value\":256}},\"4243\":{\"E\":{\"value\":256}},\"4322\":{\"T\":{\"value\":257}},\"4368\":{\"E\":{\"value\":257}},\"4449\":{\"P\":{\"value\":256}},\"4541\":{\"A\":{\"value\":256}},\"4559\":{\"P\":{\"value\":257}},\"4667\":{\"D\":{\"value\":256}},\"4705\":{\"A\":{\"value\":257}},\"4769\":{\"D\":{\"value\":257}},\"5090\":{\"Return\":{\"value\":256},\"Open windows\":{\"788720\":\"Easy Automator\",\"787150\":\"EasyAutomator (Running) - Microsoft Visual Studio\",\"4653890\":\"Recordings\",\"2949282\":\"Final Report_formatted_v2.docx - Word\",\"2427250\":\"Interim Report\",\"1704526\":\"Tools\",\"1638498\":\"History\",\"4523202\":\"Layers\",\"3016774\":\"Colors\",\"3933764\":\"Use_Case.PNG - paint.net 4.0.9\",\"4327206\":\"Snipping Tool\",\"5048204\":\"\u2022 Use case diagram_v10.mdj \u2014 StarUML (UNREGISTERED)\",\"1114226\":\"Violet UML Editor\",\"3736688\":\"Sequence_Download+Play.PNG - Windows Photo Viewer\",\"5244472\":\"Settings\",\"2034060\":\"Sequence_Create+Upload.PNG - Windows Photo Viewer\",\"5834602\":\"Calculator\",\"22481286\":\"Calculator\",\"5571430\":\"Settings\",\"131226\":\"Windows Shell Experience Host\",\"2491466\":\"Google Play Music Desktop Player\"}},\"5193\":{\"Return\":{\"value\":257}},\"5610\":{\"A\":{\"value\":256}},\"5721\":{\"A\":{\"value\":257}},\"5921\":{\"B\":{\"value\":256}},\"6015\":{\"B\":{\"value\":257}},\"6165\":{\"C\":{\"value\":256}},\"6252\":{\"C\":{\"value\":257}},\"6657\":{\"Capital\":{\"value\":256}},\"6744\":{\"Capital\":{\"value\":257}}," +
                            "\"Name\":\"\",\"Desc\":\"Opens the notepad, types ABC\",\"recId\":\"a47dddeffff233327a431186217c2c66d1c05bbb875f4c0324148b9a344a05cd\",\"AuthorFirstname\":\"Brian\",\"AuthorSurname\":\"Briscoe\",\"UserId\":\"b2ccb37d78e78182f80397edbc456f085778896427791cd4840bfc315f418451\"}";
            Assert.IsFalse(RecordingManager.validateJson(json));

            // Upload a recording without a title key
            json = "{\"3464\":{\"LWin\":{\"value\":256}},\"3543\":{\"LWin\":{\"value\":257}},\"3906\":{\"N\":{\"value\":256}},\"4001\":{\"N\":{\"value\":257}},\"4048\":{\"O\":{\"value\":256}},\"4159\":{\"O\":{\"value\":257}},\"4188\":{\"T\":{\"value\":256}},\"4243\":{\"E\":{\"value\":256}},\"4322\":{\"T\":{\"value\":257}},\"4368\":{\"E\":{\"value\":257}},\"4449\":{\"P\":{\"value\":256}},\"4541\":{\"A\":{\"value\":256}},\"4559\":{\"P\":{\"value\":257}},\"4667\":{\"D\":{\"value\":256}},\"4705\":{\"A\":{\"value\":257}},\"4769\":{\"D\":{\"value\":257}},\"5090\":{\"Return\":{\"value\":256},\"Open windows\":{\"788720\":\"Easy Automator\",\"787150\":\"EasyAutomator (Running) - Microsoft Visual Studio\",\"4653890\":\"Recordings\",\"2949282\":\"Final Report_formatted_v2.docx - Word\",\"2427250\":\"Interim Report\",\"1704526\":\"Tools\",\"1638498\":\"History\",\"4523202\":\"Layers\",\"3016774\":\"Colors\",\"3933764\":\"Use_Case.PNG - paint.net 4.0.9\",\"4327206\":\"Snipping Tool\",\"5048204\":\"\u2022 Use case diagram_v10.mdj \u2014 StarUML (UNREGISTERED)\",\"1114226\":\"Violet UML Editor\",\"3736688\":\"Sequence_Download+Play.PNG - Windows Photo Viewer\",\"5244472\":\"Settings\",\"2034060\":\"Sequence_Create+Upload.PNG - Windows Photo Viewer\",\"5834602\":\"Calculator\",\"22481286\":\"Calculator\",\"5571430\":\"Settings\",\"131226\":\"Windows Shell Experience Host\",\"2491466\":\"Google Play Music Desktop Player\"}},\"5193\":{\"Return\":{\"value\":257}},\"5610\":{\"A\":{\"value\":256}},\"5721\":{\"A\":{\"value\":257}},\"5921\":{\"B\":{\"value\":256}},\"6015\":{\"B\":{\"value\":257}},\"6165\":{\"C\":{\"value\":256}},\"6252\":{\"C\":{\"value\":257}},\"6657\":{\"Capital\":{\"value\":256}},\"6744\":{\"Capital\":{\"value\":257}}," +
                            ",\"Desc\":\"Opens the notepad, types ABC\",\"recId\":\"a47dddeffff233327a431186217c2c66d1c05bbb875f4c0324148b9a344a05cd\",\"AuthorFirstname\":\"Brian\",\"AuthorSurname\":\"Briscoe\",\"UserId\":\"b2ccb37d78e78182f80397edbc456f085778896427791cd4840bfc315f418451\"}";
            Assert.IsFalse(RecordingManager.validateJson(json));

            // Upload a recording with a null description
            json = "{\"3464\":{\"LWin\":{\"value\":256}},\"3543\":{\"LWin\":{\"value\":257}},\"3906\":{\"N\":{\"value\":256}},\"4001\":{\"N\":{\"value\":257}},\"4048\":{\"O\":{\"value\":256}},\"4159\":{\"O\":{\"value\":257}},\"4188\":{\"T\":{\"value\":256}},\"4243\":{\"E\":{\"value\":256}},\"4322\":{\"T\":{\"value\":257}},\"4368\":{\"E\":{\"value\":257}},\"4449\":{\"P\":{\"value\":256}},\"4541\":{\"A\":{\"value\":256}},\"4559\":{\"P\":{\"value\":257}},\"4667\":{\"D\":{\"value\":256}},\"4705\":{\"A\":{\"value\":257}},\"4769\":{\"D\":{\"value\":257}},\"5090\":{\"Return\":{\"value\":256},\"Open windows\":{\"788720\":\"Easy Automator\",\"787150\":\"EasyAutomator (Running) - Microsoft Visual Studio\",\"4653890\":\"Recordings\",\"2949282\":\"Final Report_formatted_v2.docx - Word\",\"2427250\":\"Interim Report\",\"1704526\":\"Tools\",\"1638498\":\"History\",\"4523202\":\"Layers\",\"3016774\":\"Colors\",\"3933764\":\"Use_Case.PNG - paint.net 4.0.9\",\"4327206\":\"Snipping Tool\",\"5048204\":\"\u2022 Use case diagram_v10.mdj \u2014 StarUML (UNREGISTERED)\",\"1114226\":\"Violet UML Editor\",\"3736688\":\"Sequence_Download+Play.PNG - Windows Photo Viewer\",\"5244472\":\"Settings\",\"2034060\":\"Sequence_Create+Upload.PNG - Windows Photo Viewer\",\"5834602\":\"Calculator\",\"22481286\":\"Calculator\",\"5571430\":\"Settings\",\"131226\":\"Windows Shell Experience Host\",\"2491466\":\"Google Play Music Desktop Player\"}},\"5193\":{\"Return\":{\"value\":257}},\"5610\":{\"A\":{\"value\":256}},\"5721\":{\"A\":{\"value\":257}},\"5921\":{\"B\":{\"value\":256}},\"6015\":{\"B\":{\"value\":257}},\"6165\":{\"C\":{\"value\":256}},\"6252\":{\"C\":{\"value\":257}},\"6657\":{\"Capital\":{\"value\":256}},\"6744\":{\"Capital\":{\"value\":257}}," +
                            "\"Name\":\"ABC\",\"Desc\":\"\",\"recId\":\"a47dddeffff233327a431186217c2c66d1c05bbb875f4c0324148b9a344a05cd\",\"AuthorFirstname\":\"Brian\",\"AuthorSurname\":\"Briscoe\",\"UserId\":\"b2ccb37d78e78182f80397edbc456f085778896427791cd4840bfc315f418451\"}";
            Assert.IsFalse(RecordingManager.validateJson(json));

            // Upload a recording without a description object
            json = "{\"3464\":{\"LWin\":{\"value\":256}},\"3543\":{\"LWin\":{\"value\":257}},\"3906\":{\"N\":{\"value\":256}},\"4001\":{\"N\":{\"value\":257}},\"4048\":{\"O\":{\"value\":256}},\"4159\":{\"O\":{\"value\":257}},\"4188\":{\"T\":{\"value\":256}},\"4243\":{\"E\":{\"value\":256}},\"4322\":{\"T\":{\"value\":257}},\"4368\":{\"E\":{\"value\":257}},\"4449\":{\"P\":{\"value\":256}},\"4541\":{\"A\":{\"value\":256}},\"4559\":{\"P\":{\"value\":257}},\"4667\":{\"D\":{\"value\":256}},\"4705\":{\"A\":{\"value\":257}},\"4769\":{\"D\":{\"value\":257}},\"5090\":{\"Return\":{\"value\":256},\"Open windows\":{\"788720\":\"Easy Automator\",\"787150\":\"EasyAutomator (Running) - Microsoft Visual Studio\",\"4653890\":\"Recordings\",\"2949282\":\"Final Report_formatted_v2.docx - Word\",\"2427250\":\"Interim Report\",\"1704526\":\"Tools\",\"1638498\":\"History\",\"4523202\":\"Layers\",\"3016774\":\"Colors\",\"3933764\":\"Use_Case.PNG - paint.net 4.0.9\",\"4327206\":\"Snipping Tool\",\"5048204\":\"\u2022 Use case diagram_v10.mdj \u2014 StarUML (UNREGISTERED)\",\"1114226\":\"Violet UML Editor\",\"3736688\":\"Sequence_Download+Play.PNG - Windows Photo Viewer\",\"5244472\":\"Settings\",\"2034060\":\"Sequence_Create+Upload.PNG - Windows Photo Viewer\",\"5834602\":\"Calculator\",\"22481286\":\"Calculator\",\"5571430\":\"Settings\",\"131226\":\"Windows Shell Experience Host\",\"2491466\":\"Google Play Music Desktop Player\"}},\"5193\":{\"Return\":{\"value\":257}},\"5610\":{\"A\":{\"value\":256}},\"5721\":{\"A\":{\"value\":257}},\"5921\":{\"B\":{\"value\":256}},\"6015\":{\"B\":{\"value\":257}},\"6165\":{\"C\":{\"value\":256}},\"6252\":{\"C\":{\"value\":257}},\"6657\":{\"Capital\":{\"value\":256}},\"6744\":{\"Capital\":{\"value\":257}}," +
                            "\"Name\":\"ABC\",\"recId\":\"a47dddeffff233327a431186217c2c66d1c05bbb875f4c0324148b9a344a05cd\",\"AuthorFirstname\":\"Brian\",\"AuthorSurname\":\"Briscoe\",\"UserId\":\"b2ccb37d78e78182f80397edbc456f085778896427791cd4840bfc315f418451\"}";
            Assert.IsFalse(RecordingManager.validateJson(json));

            // Upload a recording in an entirely incorrect format
            try
            {
                json = "{\"menu\": {\"id\": \"file\",\"value\": \"File\",\"popup\": {\"menuitem\": [{\"value\": \"New\", \"onclick\": \"CreateNewDoc()\"},{\"value\": \"Open\", \"onclick\": \"OpenDoc()\"},{\"value\": \"Close\", \"onclick\": \"CloseDoc}}}";
                Assert.IsFalse(RecordingManager.validateJson(json));
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is JsonReaderException);
            }
        }

        [TestMethod()]
        public void addInformationTest()
        {
            fullJson = "{ \"593\":{ \"LWin\":{ \"value\":256} },\"683\":{ \"LWin\":{ \"value\":257} },\"1332\":{ \"T\":{ \"value\":256} },\"1402\":{ \"E\":{ \"value\":256} },\"1488\":{ \"T\":{ \"value\":257},\"E\":{ \"value\":257} },\"1582\":{ \"S\":{ \"value\":256} },\"1686\":{ \"T\":{ \"value\":256} },\"1766\":{ \"S\":{ \"value\":257},\"T\":{ \"value\":257} },\"Name\":\"test\",\"Desc\":\"test\",\"recId\":\"5fe03f40-b67f-4fc8-8c57-0a84fd4c9441\",\"userName\":\"test\"}";
            string rawJson = "{ \"593\":{ \"LWin\":{ \"value\":256} },\"683\":{ \"LWin\":{ \"value\":257} },\"1332\":{ \"T\":{ \"value\":256} },\"1402\":{ \"E\":{ \"value\":256} },\"1488\":{ \"T\":{ \"value\":257},\"E\":{ \"value\":257} },\"1582\":{ \"S\":{ \"value\":256} },\"1686\":{ \"T\":{ \"value\":256} },\"1766\":{ \"S\":{ \"value\":257},\"T\":{ \"value\":257} }}";
            string infoJson = "";
            rec = new RecordingManager(rawJson);
            Properties.Settings.Default.currentUser = "Test";

            // Assert that valid information can be added to a JSON string
            infoJson = rec.addInformation(rawJson, "title", "Description");
            Assert.IsTrue(RecordingManager.validateJson(infoJson));

            // Assert that blank information cannot be added to the JSON string
            infoJson = rec.addInformation(rawJson, "", "");
            Assert.IsFalse(RecordingManager.validateJson(infoJson));

            // Assert that a blank title will fail to add to the JSON string
            infoJson = rec.addInformation(rawJson, "", "Description");
            Assert.IsFalse(RecordingManager.validateJson(infoJson));

            // Assert that a blank description will fail to add to the JSON string
            infoJson = rec.addInformation(rawJson, "Title", "");
            Assert.IsFalse(RecordingManager.validateJson(infoJson));

        }
    }
}