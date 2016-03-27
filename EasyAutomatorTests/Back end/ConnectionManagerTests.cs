using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace SequenceAutomation.Tests
{
    [TestClass()]
    public class ConnectionManagerTests
    {
        ConnectionManager conn;

        [TestMethod()]
        public void connectionManagerTest()
        {
            conn = new ConnectionManager();

            // Assert that the variable can be instantiated
            Assert.IsNotNull(conn);
        }

        [TestMethod()]
        public void loginUserTest()
        {
            conn = new ConnectionManager();

            // Assert that login can be completed with valid credentials
            Assert.IsTrue(conn.loginUser("brianbriscoe", "brianbriscoe"));
            Assert.IsTrue(conn.loginUser("jackbrown", "jackbrown"));

            // Assert that login will not be successful with invalid credentials 
            // i.e. credentials that do not exist on the database
            Assert.IsFalse(conn.loginUser("username", "password"));
            Assert.IsFalse(conn.loginUser("random name", "random password"));
            Assert.IsFalse(conn.loginUser("", ""));
            Assert.IsFalse(conn.loginUser("0-20", "a!124"));
        }

        [TestMethod()]
        public void testConnectionTest()
        {
            conn = new ConnectionManager();

            // Assert the connection can be established
            Assert.IsTrue(conn.testConnection());
        }


        [TestMethod()]
        public void registerTest()
        {
            // REMINDER: Delete TESTUSER1 from database before executing

            conn = new ConnectionManager();
            string result;

            // Assert that valid user credentials can be added successfully
            List<string> userInfo = new List<string>();
            userInfo.Add("FNAME1"); // fname
            userInfo.Add("SNAME1"); // surname
            userInfo.Add("test@user.com"); // email 
            userInfo.Add("TESTUSER1"); // username
            userInfo.Add("USER1"); // pwd1
            userInfo.Add("USER1"); // pwd2

            result = conn.register(userInfo);
            Assert.AreEqual(result, "REGISTER_SUCCESSFUL");

            // Assert that an invalid email address will produce the appropriate output
            userInfo = new List<string>();
            userInfo.Add("FNAME2"); // fname
            userInfo.Add("SNAME2"); // surname
            userInfo.Add("testuser.com"); // email 
            userInfo.Add("TESTUSER2"); // username
            userInfo.Add("USER2"); // pwd1
            userInfo.Add("USER2"); // pwd2

            result = conn.register(userInfo);
            Assert.AreEqual(result, "EMAIL_INVALID");

            // Assert that an invalid email address will produce the appropriate output
            userInfo = new List<string>();
            userInfo.Add("FNAME3"); // fname
            userInfo.Add("SNAME3"); // surname
            userInfo.Add("testTEST"); // email 
            userInfo.Add("TESTUSER3"); // username
            userInfo.Add("USER3"); // pwd1
            userInfo.Add("USER3"); // pwd2

            result = conn.register(userInfo);
            Assert.AreEqual(result, "EMAIL_INVALID");

            // Assert that an existing email address cannot be registered again
            userInfo = new List<string>();
            userInfo.Add("FNAME4"); // fname
            userInfo.Add("SNAME4"); // surname
            userInfo.Add("test@user.com"); // email 
            userInfo.Add("TESTUSER4"); // username
            userInfo.Add("USER4"); // pwd1
            userInfo.Add("USER4"); // pwd2

            result = conn.register(userInfo);
            Assert.AreEqual(result, "EMAIL_EXISTS");

            // Assert that an existing username cannot be registered again
            userInfo = new List<string>();
            userInfo.Add("FNAME5"); // fname
            userInfo.Add("SNAME5"); // surname
            userInfo.Add("test@user5.com"); // email 
            userInfo.Add("TESTUSER1"); // username
            userInfo.Add("USER5"); // pwd1
            userInfo.Add("USER5"); // pwd2

            result = conn.register(userInfo);
            Console.WriteLine(result);
            Assert.AreEqual(result, "USERNAME_EXISTS");

            // Assert that both passwords must match
            userInfo = new List<string>();
            userInfo.Add("FNAME6"); // fname
            userInfo.Add("SNAME6"); // surname
            userInfo.Add("test@user5.com"); // email 
            userInfo.Add("TESTUSER1"); // username
            userInfo.Add("USER6"); // pwd1
            userInfo.Add("USER66666"); // pwd2

            result = conn.register(userInfo);
            Assert.AreEqual(result, "PASSWORD_NO_MATCH");

        }

        [TestMethod()]
        public void getRecordingsTest()
        {
            conn = new ConnectionManager();

            // Assert that the correct data type is returned
            List < RecordingManager > recList =  new List<RecordingManager>();
            foreach (RecordingManager rec in conn.getRecordings())
            {
                recList.Add(rec);
            }
            Assert.IsInstanceOfType(recList, typeof(List<RecordingManager>));

        }

        [TestMethod()]
        public void getRecInfoTest()
        {
            // NOTE: Throw exception in method
            conn = new ConnectionManager();

            // Assert that a valid recording will be returned by a valid ID
            string rec = conn.getRecInfo("f25987a2ca6a6f2ffce8a4f402c3a853fa4a0855110a49f709b10e934848f8e5");
            RecordingManager recording = new RecordingManager(rec);
            Assert.IsNotNull(recording.Author);
            Assert.IsNotNull(recording.Description);
            Assert.IsNotNull(recording.Id);
            Assert.IsNotNull(recording.Title);


            // Assert that a non existent recording name will raise an exception
            try
            {
                string rec2 = conn.getRecInfo("123456abcdef");
                Assert.Fail("No exception thrown");
            }
            catch (WebException ex)
            {
                Assert.IsTrue(ex is WebException);
            }

        }

        [TestMethod()]
        public void uploadRecordingTest()
        {
            conn = new ConnectionManager();

            // Upload a recording in the valid format
            string json = "{\"3464\":{\"LWin\":{\"value\":256}},\"3543\":{\"LWin\":{\"value\":257}},\"3906\":{\"N\":{\"value\":256}},\"4001\":{\"N\":{\"value\":257}},\"4048\":{\"O\":{\"value\":256}},\"4159\":{\"O\":{\"value\":257}},\"4188\":{\"T\":{\"value\":256}},\"4243\":{\"E\":{\"value\":256}},\"4322\":{\"T\":{\"value\":257}},\"4368\":{\"E\":{\"value\":257}},\"4449\":{\"P\":{\"value\":256}},\"4541\":{\"A\":{\"value\":256}},\"4559\":{\"P\":{\"value\":257}},\"4667\":{\"D\":{\"value\":256}},\"4705\":{\"A\":{\"value\":257}},\"4769\":{\"D\":{\"value\":257}},\"5090\":{\"Return\":{\"value\":256},\"Open windows\":{\"788720\":\"Easy Automator\",\"787150\":\"EasyAutomator (Running) - Microsoft Visual Studio\",\"4653890\":\"Recordings\",\"2949282\":\"Final Report_formatted_v2.docx - Word\",\"2427250\":\"Interim Report\",\"1704526\":\"Tools\",\"1638498\":\"History\",\"4523202\":\"Layers\",\"3016774\":\"Colors\",\"3933764\":\"Use_Case.PNG - paint.net 4.0.9\",\"4327206\":\"Snipping Tool\",\"5048204\":\"\u2022 Use case diagram_v10.mdj \u2014 StarUML (UNREGISTERED)\",\"1114226\":\"Violet UML Editor\",\"3736688\":\"Sequence_Download+Play.PNG - Windows Photo Viewer\",\"5244472\":\"Settings\",\"2034060\":\"Sequence_Create+Upload.PNG - Windows Photo Viewer\",\"5834602\":\"Calculator\",\"22481286\":\"Calculator\",\"5571430\":\"Settings\",\"131226\":\"Windows Shell Experience Host\",\"2491466\":\"Google Play Music Desktop Player\"}},\"5193\":{\"Return\":{\"value\":257}},\"5610\":{\"A\":{\"value\":256}},\"5721\":{\"A\":{\"value\":257}},\"5921\":{\"B\":{\"value\":256}},\"6015\":{\"B\":{\"value\":257}},\"6165\":{\"C\":{\"value\":256}},\"6252\":{\"C\":{\"value\":257}},\"6657\":{\"Capital\":{\"value\":256}},\"6744\":{\"Capital\":{\"value\":257}}," + 
                            "\"Name\":\"ABC\",\"Desc\":\"Opens the notepad, types ABC\",\"recId\":\"a47dddeffff233327a431186217c2c66d1c05bbb875f4c0324148b9a344a05cd\",\"AuthorFirstname\":\"Brian\",\"AuthorSurname\":\"Briscoe\",\"UserId\":\"b2ccb37d78e78182f80397edbc456f085778896427791cd4840bfc315f418451\"}";
            Assert.IsTrue(conn.uploadRecording(json));

            // Upload a recording with a null title
            json = "{\"3464\":{\"LWin\":{\"value\":256}},\"3543\":{\"LWin\":{\"value\":257}},\"3906\":{\"N\":{\"value\":256}},\"4001\":{\"N\":{\"value\":257}},\"4048\":{\"O\":{\"value\":256}},\"4159\":{\"O\":{\"value\":257}},\"4188\":{\"T\":{\"value\":256}},\"4243\":{\"E\":{\"value\":256}},\"4322\":{\"T\":{\"value\":257}},\"4368\":{\"E\":{\"value\":257}},\"4449\":{\"P\":{\"value\":256}},\"4541\":{\"A\":{\"value\":256}},\"4559\":{\"P\":{\"value\":257}},\"4667\":{\"D\":{\"value\":256}},\"4705\":{\"A\":{\"value\":257}},\"4769\":{\"D\":{\"value\":257}},\"5090\":{\"Return\":{\"value\":256},\"Open windows\":{\"788720\":\"Easy Automator\",\"787150\":\"EasyAutomator (Running) - Microsoft Visual Studio\",\"4653890\":\"Recordings\",\"2949282\":\"Final Report_formatted_v2.docx - Word\",\"2427250\":\"Interim Report\",\"1704526\":\"Tools\",\"1638498\":\"History\",\"4523202\":\"Layers\",\"3016774\":\"Colors\",\"3933764\":\"Use_Case.PNG - paint.net 4.0.9\",\"4327206\":\"Snipping Tool\",\"5048204\":\"\u2022 Use case diagram_v10.mdj \u2014 StarUML (UNREGISTERED)\",\"1114226\":\"Violet UML Editor\",\"3736688\":\"Sequence_Download+Play.PNG - Windows Photo Viewer\",\"5244472\":\"Settings\",\"2034060\":\"Sequence_Create+Upload.PNG - Windows Photo Viewer\",\"5834602\":\"Calculator\",\"22481286\":\"Calculator\",\"5571430\":\"Settings\",\"131226\":\"Windows Shell Experience Host\",\"2491466\":\"Google Play Music Desktop Player\"}},\"5193\":{\"Return\":{\"value\":257}},\"5610\":{\"A\":{\"value\":256}},\"5721\":{\"A\":{\"value\":257}},\"5921\":{\"B\":{\"value\":256}},\"6015\":{\"B\":{\"value\":257}},\"6165\":{\"C\":{\"value\":256}},\"6252\":{\"C\":{\"value\":257}},\"6657\":{\"Capital\":{\"value\":256}},\"6744\":{\"Capital\":{\"value\":257}}," +
                            "\"Name\":\"\",\"Desc\":\"Opens the notepad, types ABC\",\"recId\":\"a47dddeffff233327a431186217c2c66d1c05bbb875f4c0324148b9a344a05cd\",\"AuthorFirstname\":\"Brian\",\"AuthorSurname\":\"Briscoe\",\"UserId\":\"b2ccb37d78e78182f80397edbc456f085778896427791cd4840bfc315f418451\"}";
            Assert.IsFalse(conn.uploadRecording(json));

            // Upload a recording without a title key
            json = "{\"3464\":{\"LWin\":{\"value\":256}},\"3543\":{\"LWin\":{\"value\":257}},\"3906\":{\"N\":{\"value\":256}},\"4001\":{\"N\":{\"value\":257}},\"4048\":{\"O\":{\"value\":256}},\"4159\":{\"O\":{\"value\":257}},\"4188\":{\"T\":{\"value\":256}},\"4243\":{\"E\":{\"value\":256}},\"4322\":{\"T\":{\"value\":257}},\"4368\":{\"E\":{\"value\":257}},\"4449\":{\"P\":{\"value\":256}},\"4541\":{\"A\":{\"value\":256}},\"4559\":{\"P\":{\"value\":257}},\"4667\":{\"D\":{\"value\":256}},\"4705\":{\"A\":{\"value\":257}},\"4769\":{\"D\":{\"value\":257}},\"5090\":{\"Return\":{\"value\":256},\"Open windows\":{\"788720\":\"Easy Automator\",\"787150\":\"EasyAutomator (Running) - Microsoft Visual Studio\",\"4653890\":\"Recordings\",\"2949282\":\"Final Report_formatted_v2.docx - Word\",\"2427250\":\"Interim Report\",\"1704526\":\"Tools\",\"1638498\":\"History\",\"4523202\":\"Layers\",\"3016774\":\"Colors\",\"3933764\":\"Use_Case.PNG - paint.net 4.0.9\",\"4327206\":\"Snipping Tool\",\"5048204\":\"\u2022 Use case diagram_v10.mdj \u2014 StarUML (UNREGISTERED)\",\"1114226\":\"Violet UML Editor\",\"3736688\":\"Sequence_Download+Play.PNG - Windows Photo Viewer\",\"5244472\":\"Settings\",\"2034060\":\"Sequence_Create+Upload.PNG - Windows Photo Viewer\",\"5834602\":\"Calculator\",\"22481286\":\"Calculator\",\"5571430\":\"Settings\",\"131226\":\"Windows Shell Experience Host\",\"2491466\":\"Google Play Music Desktop Player\"}},\"5193\":{\"Return\":{\"value\":257}},\"5610\":{\"A\":{\"value\":256}},\"5721\":{\"A\":{\"value\":257}},\"5921\":{\"B\":{\"value\":256}},\"6015\":{\"B\":{\"value\":257}},\"6165\":{\"C\":{\"value\":256}},\"6252\":{\"C\":{\"value\":257}},\"6657\":{\"Capital\":{\"value\":256}},\"6744\":{\"Capital\":{\"value\":257}}," +
                            ",\"Desc\":\"Opens the notepad, types ABC\",\"recId\":\"a47dddeffff233327a431186217c2c66d1c05bbb875f4c0324148b9a344a05cd\",\"AuthorFirstname\":\"Brian\",\"AuthorSurname\":\"Briscoe\",\"UserId\":\"b2ccb37d78e78182f80397edbc456f085778896427791cd4840bfc315f418451\"}";
            Assert.IsFalse(conn.uploadRecording(json));

            // Upload a recording with a null description
            json = "{\"3464\":{\"LWin\":{\"value\":256}},\"3543\":{\"LWin\":{\"value\":257}},\"3906\":{\"N\":{\"value\":256}},\"4001\":{\"N\":{\"value\":257}},\"4048\":{\"O\":{\"value\":256}},\"4159\":{\"O\":{\"value\":257}},\"4188\":{\"T\":{\"value\":256}},\"4243\":{\"E\":{\"value\":256}},\"4322\":{\"T\":{\"value\":257}},\"4368\":{\"E\":{\"value\":257}},\"4449\":{\"P\":{\"value\":256}},\"4541\":{\"A\":{\"value\":256}},\"4559\":{\"P\":{\"value\":257}},\"4667\":{\"D\":{\"value\":256}},\"4705\":{\"A\":{\"value\":257}},\"4769\":{\"D\":{\"value\":257}},\"5090\":{\"Return\":{\"value\":256},\"Open windows\":{\"788720\":\"Easy Automator\",\"787150\":\"EasyAutomator (Running) - Microsoft Visual Studio\",\"4653890\":\"Recordings\",\"2949282\":\"Final Report_formatted_v2.docx - Word\",\"2427250\":\"Interim Report\",\"1704526\":\"Tools\",\"1638498\":\"History\",\"4523202\":\"Layers\",\"3016774\":\"Colors\",\"3933764\":\"Use_Case.PNG - paint.net 4.0.9\",\"4327206\":\"Snipping Tool\",\"5048204\":\"\u2022 Use case diagram_v10.mdj \u2014 StarUML (UNREGISTERED)\",\"1114226\":\"Violet UML Editor\",\"3736688\":\"Sequence_Download+Play.PNG - Windows Photo Viewer\",\"5244472\":\"Settings\",\"2034060\":\"Sequence_Create+Upload.PNG - Windows Photo Viewer\",\"5834602\":\"Calculator\",\"22481286\":\"Calculator\",\"5571430\":\"Settings\",\"131226\":\"Windows Shell Experience Host\",\"2491466\":\"Google Play Music Desktop Player\"}},\"5193\":{\"Return\":{\"value\":257}},\"5610\":{\"A\":{\"value\":256}},\"5721\":{\"A\":{\"value\":257}},\"5921\":{\"B\":{\"value\":256}},\"6015\":{\"B\":{\"value\":257}},\"6165\":{\"C\":{\"value\":256}},\"6252\":{\"C\":{\"value\":257}},\"6657\":{\"Capital\":{\"value\":256}},\"6744\":{\"Capital\":{\"value\":257}}," +
                            "\"Name\":\"ABC\",\"Desc\":\"\",\"recId\":\"a47dddeffff233327a431186217c2c66d1c05bbb875f4c0324148b9a344a05cd\",\"AuthorFirstname\":\"Brian\",\"AuthorSurname\":\"Briscoe\",\"UserId\":\"b2ccb37d78e78182f80397edbc456f085778896427791cd4840bfc315f418451\"}";
            Assert.IsFalse(conn.uploadRecording(json));

            // Upload a recording without a description object
            json = "{\"3464\":{\"LWin\":{\"value\":256}},\"3543\":{\"LWin\":{\"value\":257}},\"3906\":{\"N\":{\"value\":256}},\"4001\":{\"N\":{\"value\":257}},\"4048\":{\"O\":{\"value\":256}},\"4159\":{\"O\":{\"value\":257}},\"4188\":{\"T\":{\"value\":256}},\"4243\":{\"E\":{\"value\":256}},\"4322\":{\"T\":{\"value\":257}},\"4368\":{\"E\":{\"value\":257}},\"4449\":{\"P\":{\"value\":256}},\"4541\":{\"A\":{\"value\":256}},\"4559\":{\"P\":{\"value\":257}},\"4667\":{\"D\":{\"value\":256}},\"4705\":{\"A\":{\"value\":257}},\"4769\":{\"D\":{\"value\":257}},\"5090\":{\"Return\":{\"value\":256},\"Open windows\":{\"788720\":\"Easy Automator\",\"787150\":\"EasyAutomator (Running) - Microsoft Visual Studio\",\"4653890\":\"Recordings\",\"2949282\":\"Final Report_formatted_v2.docx - Word\",\"2427250\":\"Interim Report\",\"1704526\":\"Tools\",\"1638498\":\"History\",\"4523202\":\"Layers\",\"3016774\":\"Colors\",\"3933764\":\"Use_Case.PNG - paint.net 4.0.9\",\"4327206\":\"Snipping Tool\",\"5048204\":\"\u2022 Use case diagram_v10.mdj \u2014 StarUML (UNREGISTERED)\",\"1114226\":\"Violet UML Editor\",\"3736688\":\"Sequence_Download+Play.PNG - Windows Photo Viewer\",\"5244472\":\"Settings\",\"2034060\":\"Sequence_Create+Upload.PNG - Windows Photo Viewer\",\"5834602\":\"Calculator\",\"22481286\":\"Calculator\",\"5571430\":\"Settings\",\"131226\":\"Windows Shell Experience Host\",\"2491466\":\"Google Play Music Desktop Player\"}},\"5193\":{\"Return\":{\"value\":257}},\"5610\":{\"A\":{\"value\":256}},\"5721\":{\"A\":{\"value\":257}},\"5921\":{\"B\":{\"value\":256}},\"6015\":{\"B\":{\"value\":257}},\"6165\":{\"C\":{\"value\":256}},\"6252\":{\"C\":{\"value\":257}},\"6657\":{\"Capital\":{\"value\":256}},\"6744\":{\"Capital\":{\"value\":257}}," +
                            "\"Name\":\"ABC\",\"recId\":\"a47dddeffff233327a431186217c2c66d1c05bbb875f4c0324148b9a344a05cd\",\"AuthorFirstname\":\"Brian\",\"AuthorSurname\":\"Briscoe\",\"UserId\":\"b2ccb37d78e78182f80397edbc456f085778896427791cd4840bfc315f418451\"}";
            Assert.IsFalse(conn.uploadRecording(json));

            // Upload a recording with a null author firstname
            json = "{\"3464\":{\"LWin\":{\"value\":256}},\"3543\":{\"LWin\":{\"value\":257}},\"3906\":{\"N\":{\"value\":256}},\"4001\":{\"N\":{\"value\":257}},\"4048\":{\"O\":{\"value\":256}},\"4159\":{\"O\":{\"value\":257}},\"4188\":{\"T\":{\"value\":256}},\"4243\":{\"E\":{\"value\":256}},\"4322\":{\"T\":{\"value\":257}},\"4368\":{\"E\":{\"value\":257}},\"4449\":{\"P\":{\"value\":256}},\"4541\":{\"A\":{\"value\":256}},\"4559\":{\"P\":{\"value\":257}},\"4667\":{\"D\":{\"value\":256}},\"4705\":{\"A\":{\"value\":257}},\"4769\":{\"D\":{\"value\":257}},\"5090\":{\"Return\":{\"value\":256},\"Open windows\":{\"788720\":\"Easy Automator\",\"787150\":\"EasyAutomator (Running) - Microsoft Visual Studio\",\"4653890\":\"Recordings\",\"2949282\":\"Final Report_formatted_v2.docx - Word\",\"2427250\":\"Interim Report\",\"1704526\":\"Tools\",\"1638498\":\"History\",\"4523202\":\"Layers\",\"3016774\":\"Colors\",\"3933764\":\"Use_Case.PNG - paint.net 4.0.9\",\"4327206\":\"Snipping Tool\",\"5048204\":\"\u2022 Use case diagram_v10.mdj \u2014 StarUML (UNREGISTERED)\",\"1114226\":\"Violet UML Editor\",\"3736688\":\"Sequence_Download+Play.PNG - Windows Photo Viewer\",\"5244472\":\"Settings\",\"2034060\":\"Sequence_Create+Upload.PNG - Windows Photo Viewer\",\"5834602\":\"Calculator\",\"22481286\":\"Calculator\",\"5571430\":\"Settings\",\"131226\":\"Windows Shell Experience Host\",\"2491466\":\"Google Play Music Desktop Player\"}},\"5193\":{\"Return\":{\"value\":257}},\"5610\":{\"A\":{\"value\":256}},\"5721\":{\"A\":{\"value\":257}},\"5921\":{\"B\":{\"value\":256}},\"6015\":{\"B\":{\"value\":257}},\"6165\":{\"C\":{\"value\":256}},\"6252\":{\"C\":{\"value\":257}},\"6657\":{\"Capital\":{\"value\":256}},\"6744\":{\"Capital\":{\"value\":257}}," +
                            "\"Name\":\"ABC\",\"Desc\":\"Opens the notepad, types ABC\",\"recId\":\"a47dddeffff233327a431186217c2c66d1c05bbb875f4c0324148b9a344a05cd\",\"AuthorFirstname\":\"\",\"AuthorSurname\":\"Briscoe\",\"UserId\":\"b2ccb37d78e78182f80397edbc456f085778896427791cd4840bfc315f418451\"}";
            Assert.IsFalse(conn.uploadRecording(json));

            // Upload a recording without an author firstname key
            json = "{\"3464\":{\"LWin\":{\"value\":256}},\"3543\":{\"LWin\":{\"value\":257}},\"3906\":{\"N\":{\"value\":256}},\"4001\":{\"N\":{\"value\":257}},\"4048\":{\"O\":{\"value\":256}},\"4159\":{\"O\":{\"value\":257}},\"4188\":{\"T\":{\"value\":256}},\"4243\":{\"E\":{\"value\":256}},\"4322\":{\"T\":{\"value\":257}},\"4368\":{\"E\":{\"value\":257}},\"4449\":{\"P\":{\"value\":256}},\"4541\":{\"A\":{\"value\":256}},\"4559\":{\"P\":{\"value\":257}},\"4667\":{\"D\":{\"value\":256}},\"4705\":{\"A\":{\"value\":257}},\"4769\":{\"D\":{\"value\":257}},\"5090\":{\"Return\":{\"value\":256},\"Open windows\":{\"788720\":\"Easy Automator\",\"787150\":\"EasyAutomator (Running) - Microsoft Visual Studio\",\"4653890\":\"Recordings\",\"2949282\":\"Final Report_formatted_v2.docx - Word\",\"2427250\":\"Interim Report\",\"1704526\":\"Tools\",\"1638498\":\"History\",\"4523202\":\"Layers\",\"3016774\":\"Colors\",\"3933764\":\"Use_Case.PNG - paint.net 4.0.9\",\"4327206\":\"Snipping Tool\",\"5048204\":\"\u2022 Use case diagram_v10.mdj \u2014 StarUML (UNREGISTERED)\",\"1114226\":\"Violet UML Editor\",\"3736688\":\"Sequence_Download+Play.PNG - Windows Photo Viewer\",\"5244472\":\"Settings\",\"2034060\":\"Sequence_Create+Upload.PNG - Windows Photo Viewer\",\"5834602\":\"Calculator\",\"22481286\":\"Calculator\",\"5571430\":\"Settings\",\"131226\":\"Windows Shell Experience Host\",\"2491466\":\"Google Play Music Desktop Player\"}},\"5193\":{\"Return\":{\"value\":257}},\"5610\":{\"A\":{\"value\":256}},\"5721\":{\"A\":{\"value\":257}},\"5921\":{\"B\":{\"value\":256}},\"6015\":{\"B\":{\"value\":257}},\"6165\":{\"C\":{\"value\":256}},\"6252\":{\"C\":{\"value\":257}},\"6657\":{\"Capital\":{\"value\":256}},\"6744\":{\"Capital\":{\"value\":257}}," +
                            "\"Name\":\"ABC\",\"Desc\":\"Opens the notepad, types ABC\",\"recId\":\"a47dddeffff233327a431186217c2c66d1c05bbb875f4c0324148b9a344a05cd\",\"AuthorSurname\":\"Briscoe\",\"UserId\":\"b2ccb37d78e78182f80397edbc456f085778896427791cd4840bfc315f418451\"}";
            Assert.IsFalse(conn.uploadRecording(json));

            // Upload a recording with a null author surname
            json = "{\"3464\":{\"LWin\":{\"value\":256}},\"3543\":{\"LWin\":{\"value\":257}},\"3906\":{\"N\":{\"value\":256}},\"4001\":{\"N\":{\"value\":257}},\"4048\":{\"O\":{\"value\":256}},\"4159\":{\"O\":{\"value\":257}},\"4188\":{\"T\":{\"value\":256}},\"4243\":{\"E\":{\"value\":256}},\"4322\":{\"T\":{\"value\":257}},\"4368\":{\"E\":{\"value\":257}},\"4449\":{\"P\":{\"value\":256}},\"4541\":{\"A\":{\"value\":256}},\"4559\":{\"P\":{\"value\":257}},\"4667\":{\"D\":{\"value\":256}},\"4705\":{\"A\":{\"value\":257}},\"4769\":{\"D\":{\"value\":257}},\"5090\":{\"Return\":{\"value\":256},\"Open windows\":{\"788720\":\"Easy Automator\",\"787150\":\"EasyAutomator (Running) - Microsoft Visual Studio\",\"4653890\":\"Recordings\",\"2949282\":\"Final Report_formatted_v2.docx - Word\",\"2427250\":\"Interim Report\",\"1704526\":\"Tools\",\"1638498\":\"History\",\"4523202\":\"Layers\",\"3016774\":\"Colors\",\"3933764\":\"Use_Case.PNG - paint.net 4.0.9\",\"4327206\":\"Snipping Tool\",\"5048204\":\"\u2022 Use case diagram_v10.mdj \u2014 StarUML (UNREGISTERED)\",\"1114226\":\"Violet UML Editor\",\"3736688\":\"Sequence_Download+Play.PNG - Windows Photo Viewer\",\"5244472\":\"Settings\",\"2034060\":\"Sequence_Create+Upload.PNG - Windows Photo Viewer\",\"5834602\":\"Calculator\",\"22481286\":\"Calculator\",\"5571430\":\"Settings\",\"131226\":\"Windows Shell Experience Host\",\"2491466\":\"Google Play Music Desktop Player\"}},\"5193\":{\"Return\":{\"value\":257}},\"5610\":{\"A\":{\"value\":256}},\"5721\":{\"A\":{\"value\":257}},\"5921\":{\"B\":{\"value\":256}},\"6015\":{\"B\":{\"value\":257}},\"6165\":{\"C\":{\"value\":256}},\"6252\":{\"C\":{\"value\":257}},\"6657\":{\"Capital\":{\"value\":256}},\"6744\":{\"Capital\":{\"value\":257}}," +
                            "\"Name\":\"ABC\",\"Desc\":\"Opens the notepad, types ABC\",\"recId\":\"a47dddeffff233327a431186217c2c66d1c05bbb875f4c0324148b9a344a05cd\",\"AuthorFirstname\":\"Brian\",\"AuthorSurname\":\"\",\"UserId\":\"b2ccb37d78e78182f80397edbc456f085778896427791cd4840bfc315f418451\"}";
            Assert.IsFalse(conn.uploadRecording(json));

            // Upload a recording without an author surname key
            json = "{\"3464\":{\"LWin\":{\"value\":256}},\"3543\":{\"LWin\":{\"value\":257}},\"3906\":{\"N\":{\"value\":256}},\"4001\":{\"N\":{\"value\":257}},\"4048\":{\"O\":{\"value\":256}},\"4159\":{\"O\":{\"value\":257}},\"4188\":{\"T\":{\"value\":256}},\"4243\":{\"E\":{\"value\":256}},\"4322\":{\"T\":{\"value\":257}},\"4368\":{\"E\":{\"value\":257}},\"4449\":{\"P\":{\"value\":256}},\"4541\":{\"A\":{\"value\":256}},\"4559\":{\"P\":{\"value\":257}},\"4667\":{\"D\":{\"value\":256}},\"4705\":{\"A\":{\"value\":257}},\"4769\":{\"D\":{\"value\":257}},\"5090\":{\"Return\":{\"value\":256},\"Open windows\":{\"788720\":\"Easy Automator\",\"787150\":\"EasyAutomator (Running) - Microsoft Visual Studio\",\"4653890\":\"Recordings\",\"2949282\":\"Final Report_formatted_v2.docx - Word\",\"2427250\":\"Interim Report\",\"1704526\":\"Tools\",\"1638498\":\"History\",\"4523202\":\"Layers\",\"3016774\":\"Colors\",\"3933764\":\"Use_Case.PNG - paint.net 4.0.9\",\"4327206\":\"Snipping Tool\",\"5048204\":\"\u2022 Use case diagram_v10.mdj \u2014 StarUML (UNREGISTERED)\",\"1114226\":\"Violet UML Editor\",\"3736688\":\"Sequence_Download+Play.PNG - Windows Photo Viewer\",\"5244472\":\"Settings\",\"2034060\":\"Sequence_Create+Upload.PNG - Windows Photo Viewer\",\"5834602\":\"Calculator\",\"22481286\":\"Calculator\",\"5571430\":\"Settings\",\"131226\":\"Windows Shell Experience Host\",\"2491466\":\"Google Play Music Desktop Player\"}},\"5193\":{\"Return\":{\"value\":257}},\"5610\":{\"A\":{\"value\":256}},\"5721\":{\"A\":{\"value\":257}},\"5921\":{\"B\":{\"value\":256}},\"6015\":{\"B\":{\"value\":257}},\"6165\":{\"C\":{\"value\":256}},\"6252\":{\"C\":{\"value\":257}},\"6657\":{\"Capital\":{\"value\":256}},\"6744\":{\"Capital\":{\"value\":257}}," +
                            "\"Name\":\"ABC\",\"Desc\":\"Opens the notepad, types ABC\",\"recId\":\"a47dddeffff233327a431186217c2c66d1c05bbb875f4c0324148b9a344a05cd\",\"AuthorFirstname\":\"Brian\",\"UserId\":\"b2ccb37d78e78182f80397edbc456f085778896427791cd4840bfc315f418451\"}";
            Assert.IsFalse(conn.uploadRecording(json));

            // Upload a recording in an entirely incorrect format
            try
            {
                json = "{\"menu\": {\"id\": \"file\",\"value\": \"File\",\"popup\": {\"menuitem\": [{\"value\": \"New\", \"onclick\": \"CreateNewDoc()\"},{\"value\": \"Open\", \"onclick\": \"OpenDoc()\"},{\"value\": \"Close\", \"onclick\": \"CloseDoc}}}";
                Assert.IsFalse(conn.uploadRecording(json));
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is JsonReaderException);
            }
        }

        [TestMethod()]
        public void deleteRecordingTest()
        {
            string json = "{ \"593\":{ \"LWin\":{ \"value\":256} },\"683\":{ \"LWin\":{ \"value\":257} },\"1332\":{ \"T\":{ \"value\":256} },\"1402\":{ \"E\":{ \"value\":256} },\"1488\":{ \"T\":{ \"value\":257},\"E\":{ \"value\":257} },\"1582\":{ \"S\":{ \"value\":256} },\"1686\":{ \"T\":{ \"value\":256} },\"1766\":{ \"S\":{ \"value\":257},\"T\":{ \"value\":257} },\"Name\":\"test\",\"Desc\":\"test\",\"recId\":\"5fe03f40-b67f-4fc8-8c57-0a84fd4c9441\",\"userName\":\"test\"}";
            conn = new ConnectionManager();

            // Assert that a recording with a valid ID will be deleted
            Properties.Settings.Default.currentUser = "test";
            //Assert.IsTrue(conn.deleteRecording(json));

            // Assert that a recording with a valid ID cannot be deleted by a user who didn't create it
            json = "{ \"593\":{ \"LWin\":{ \"value\":256} },\"683\":{ \"LWin\":{ \"value\":257} },\"1332\":{ \"T\":{ \"value\":256} },\"1402\":{ \"E\":{ \"value\":256} },\"1488\":{ \"T\":{ \"value\":257},\"E\":{ \"value\":257} },\"1582\":{ \"S\":{ \"value\":256} },\"1686\":{ \"T\":{ \"value\":256} },\"1766\":{ \"S\":{ \"value\":257},\"T\":{ \"value\":257} },\"Name\":\"test\",\"Desc\":\"test\",\"recId\":\"6e78d018-e3c9-4f75-9b78-7a4f17f07e07\",\"userName\":\"test\"}";
            Properties.Settings.Default.currentUser = "INVALIDUSERNAME";
            Assert.IsFalse(conn.deleteRecording(json));

            // Assert that a recording not present on the server cannot be deleted
            // note, the ID is "1234"

            try
            {
                json = "{ \"593\":{ \"LWin\":{ \"value\":256} },\"683\":{ \"LWin\":{ \"value\":257} },\"1332\":{ \"T\":{ \"value\":256} },\"1402\":{ \"E\":{ \"value\":256} },\"1488\":{ \"T\":{ \"value\":257},\"E\":{ \"value\":257} },\"1582\":{ \"S\":{ \"value\":256} },\"1686\":{ \"T\":{ \"value\":256} },\"1766\":{ \"S\":{ \"value\":257},\"T\":{ \"value\":257} },\"Name\":\"test\",\"Desc\":\"test\",\"recId\":\"1234\",\"userName\":\"test\"}";
                Properties.Settings.Default.currentUser = "test";
                Assert.IsFalse(conn.deleteRecording(json));
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is WebException);
            }

        }
    }
}