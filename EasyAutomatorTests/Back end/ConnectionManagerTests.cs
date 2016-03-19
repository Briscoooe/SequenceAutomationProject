using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using SequenceAutomation;

namespace SequenceAutomation.Tests
{
    [TestClass()]
    public class ConnectionManagerTests
    {
        ConnectionManager conn;

        [TestMethod()]
        public void ConnectionManagerTest()
        {
            conn = new ConnectionManager();

            // Assert that the class variables are not null
            Assert.IsNotNull(conn.recordingUrl);
            Assert.IsNotNull(conn.usersUrl);
            Assert.IsNotNull(conn.domain);

            // Assert that the class variables are assigned correctly
            Assert.AreEqual(conn.recordingUrl, "http://finalyearproject.cloudapp.net/easyAutomator/app/index.php/recordings");
            Assert.AreEqual(conn.usersUrl, "http://finalyearproject.cloudapp.net/easyAutomator/app/index.php/users");
            Assert.AreEqual(conn.domain, "finalyearproject.cloudapp.net");

            // Assert that the class variables are not equal to incorrect values
            Assert.AreNotEqual(conn.recordingUrl, "http://www.facebook.com/recordings");
            Assert.AreNotEqual(conn.usersUrl, "http://www.facebook.com/users");
            Assert.AreNotEqual(conn.recordingUrl, "facebook.com");
        }

        [TestMethod()]
        public void loginUserTest()
        {
            conn = new ConnectionManager();

            // Assert that login can be completed with valid credentials
            Assert.IsTrue(conn.loginUser("123", "123"));
            Assert.IsTrue(conn.loginUser("tommyb123", "tommyb123"));

            // Assert that login will not be successful with invalid credentials 
            // i.e. credentials that do not exist on the database
            Assert.IsFalse(conn.loginUser("username", "password"));
            Assert.IsFalse(conn.loginUser("test", "test"));
            Assert.IsFalse(conn.loginUser("", ""));
            Assert.IsFalse(conn.loginUser("aaa", "aaa"));
        }

        [TestMethod()]
        public void testConnectionTest()
        {
            conn = new ConnectionManager();

            // Assert the connection can be established with the domain domain specified in the constructor
            Assert.IsTrue(conn.testConnection());

            // Assert that invalid domain strings will result in a failure in testing the connection
            conn.domain = "http://wwww.finalyearproject.cloudapp.net";
            Assert.IsFalse(conn.testConnection());

            conn.domain = "http://wwww.finalyearproject.cloudapp.net/app/index.php/recordings";
            Assert.IsFalse(conn.testConnection());

            conn.domain = "wwww.finalyearproject.cloudapp.net";
            Assert.IsFalse(conn.testConnection());
        }


        [TestMethod()]
        public void registerTest()
        {
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

            //result = conn.register(userInfo);
            //Assert.AreEqual(result, "USERNAME_EXISTS");

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

            // Assert that an invalid URI will not return the appropriate data
            try
            {
                conn.recordingUrl = "http://www.facebook.com/recordings";
                foreach (RecordingManager rec in conn.getRecordings())
                {
                    recList.Add(rec);
                }
                Assert.Fail("No exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is WebException);
            }
        }

        [TestMethod()]
        public void getRecInfoTest()
        {
            conn = new ConnectionManager();

            // Assert that a valid recording will be returned
            string rec = conn.getRecInfo("Facebook in Firefox");
            Assert.IsInstanceOfType(rec, typeof(string));

            rec = conn.getRecInfo("Gmail - Chrome");
            Assert.IsInstanceOfType(rec, typeof(string));

            // Assert that an invalid recording name will not return the appropriate data
            try
            {
                string rec2 = conn.getRecInfo("123456abcdef");
                Assert.Fail("No exception thrown");
            }
            catch (WebException ex)
            {
                Assert.IsTrue(ex is WebException);
            }

            // Assert that an invalid recording name will not return the appropriate data
            try
            {
                string rec2 = conn.getRecInfo("!!£6@");
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
            string json = "{ \"593\":{ \"LWin\":{ \"value\":256} },\"683\":{ \"LWin\":{ \"value\":257} },\"1332\":{ \"T\":{ \"value\":256} },\"1402\":{ \"E\":{ \"value\":256} },\"1488\":{ \"T\":{ \"value\":257},\"E\":{ \"value\":257} },\"1582\":{ \"S\":{ \"value\":256} },\"1686\":{ \"T\":{ \"value\":256} },\"1766\":{ \"S\":{ \"value\":257},\"T\":{ \"value\":257} },\"Name\":\"test\",\"Desc\":\"test\",\"recId\":\"5fe03f40-b67f-4fc8-8c57-0a84fd4c9441\",\"userName\":\"test\"}";
            Assert.IsTrue(conn.uploadRecording(json));

            // Upload a recording with a null username
            json = "{ \"593\":{ \"LWin\":{ \"value\":256} },\"683\":{ \"LWin\":{ \"value\":257} },\"1332\":{ \"T\":{ \"value\":256} },\"1402\":{ \"E\":{ \"value\":256} },\"1488\":{ \"T\":{ \"value\":257},\"E\":{ \"value\":257} },\"1582\":{ \"S\":{ \"value\":256} },\"1686\":{ \"T\":{ \"value\":256} },\"1766\":{ \"S\":{ \"value\":257},\"T\":{ \"value\":257} },\"Name\":\"test\",\"Desc\":\"test\",\"recId\":\"5fe03f40-b67f-4fc8-8c57-0a84fd4c9441\",\"userName\":\"\"}";
            Assert.IsFalse(conn.uploadRecording(json));

            // Upload a recording without a username object
            json = "{ \"593\":{ \"LWin\":{ \"value\":256} },\"683\":{ \"LWin\":{ \"value\":257} },\"1332\":{ \"T\":{ \"value\":256} },\"1402\":{ \"E\":{ \"value\":256} },\"1488\":{ \"T\":{ \"value\":257},\"E\":{ \"value\":257} },\"1582\":{ \"S\":{ \"value\":256} },\"1686\":{ \"T\":{ \"value\":256} },\"1766\":{ \"S\":{ \"value\":257},\"T\":{ \"value\":257} },\"Name\":\"test\",\"Desc\":\"test\",\"recId\":\"5fe03f40-b67f-4fc8-8c57-0a84fd4c9441\"}";
            Assert.IsFalse(conn.uploadRecording(json));

            // Upload a recording with a null title
            json = "{ \"593\":{ \"LWin\":{ \"value\":256} },\"683\":{ \"LWin\":{ \"value\":257} },\"1332\":{ \"T\":{ \"value\":256} },\"1402\":{ \"E\":{ \"value\":256} },\"1488\":{ \"T\":{ \"value\":257},\"E\":{ \"value\":257} },\"1582\":{ \"S\":{ \"value\":256} },\"1686\":{ \"T\":{ \"value\":256} },\"1766\":{ \"S\":{ \"value\":257},\"T\":{ \"value\":257} },\"Name\":\"\",\"Desc\":\"test\",\"recId\":\"5fe03f40-b67f-4fc8-8c57-0a84fd4c9441\",\"userName\":\"test\"}";
            Assert.IsFalse(conn.uploadRecording(json));

            // Upload a recording without a title object
            json = "{ \"593\":{ \"LWin\":{ \"value\":256} },\"683\":{ \"LWin\":{ \"value\":257} },\"1332\":{ \"T\":{ \"value\":256} },\"1402\":{ \"E\":{ \"value\":256} },\"1488\":{ \"T\":{ \"value\":257},\"E\":{ \"value\":257} },\"1582\":{ \"S\":{ \"value\":256} },\"1686\":{ \"T\":{ \"value\":256} },\"1766\":{ \"S\":{ \"value\":257},\"T\":{ \"value\":257} },\"Desc\":\"test\",\"recId\":\"5fe03f40-b67f-4fc8-8c57-0a84fd4c9441\",\"userName\":\"test\"}";
            Assert.IsFalse(conn.uploadRecording(json));

            // Upload a recording with a null description
            json = "{ \"593\":{ \"LWin\":{ \"value\":256} },\"683\":{ \"LWin\":{ \"value\":257} },\"1332\":{ \"T\":{ \"value\":256} },\"1402\":{ \"E\":{ \"value\":256} },\"1488\":{ \"T\":{ \"value\":257},\"E\":{ \"value\":257} },\"1582\":{ \"S\":{ \"value\":256} },\"1686\":{ \"T\":{ \"value\":256} },\"1766\":{ \"S\":{ \"value\":257},\"T\":{ \"value\":257} },\"Name\":\"test\",\"Desc\":\"\",\"recId\":\"5fe03f40-b67f-4fc8-8c57-0a84fd4c9441\",\"userName\":\"\"}";
            Assert.IsFalse(conn.uploadRecording(json));

            // Upload a recording without a description object
            json = "{ \"593\":{ \"LWin\":{ \"value\":256} },\"683\":{ \"LWin\":{ \"value\":257} },\"1332\":{ \"T\":{ \"value\":256} },\"1402\":{ \"E\":{ \"value\":256} },\"1488\":{ \"T\":{ \"value\":257},\"E\":{ \"value\":257} },\"1582\":{ \"S\":{ \"value\":256} },\"1686\":{ \"T\":{ \"value\":256} },\"1766\":{ \"S\":{ \"value\":257},\"T\":{ \"value\":257} },\"Name\":\"test\",\"recId\":\"5fe03f40-b67f-4fc8-8c57-0a84fd4c9441\",\"userName\":\"\"}";
            Assert.IsFalse(conn.uploadRecording(json));

            // Upload a recording with a null ID
            json = "{ \"593\":{ \"LWin\":{ \"value\":256} },\"683\":{ \"LWin\":{ \"value\":257} },\"1332\":{ \"T\":{ \"value\":256} },\"1402\":{ \"E\":{ \"value\":256} },\"1488\":{ \"T\":{ \"value\":257},\"E\":{ \"value\":257} },\"1582\":{ \"S\":{ \"value\":256} },\"1686\":{ \"T\":{ \"value\":256} },\"1766\":{ \"S\":{ \"value\":257},\"T\":{ \"value\":257} },\"Name\":\"test\",\"Desc\":\"\",\"recId\":\"\",\"userName\":\"\"}";
            Assert.IsFalse(conn.uploadRecording(json));

            // Upload a recording without an ID object
            json = "{ \"593\":{ \"LWin\":{ \"value\":256} },\"683\":{ \"LWin\":{ \"value\":257} },\"1332\":{ \"T\":{ \"value\":256} },\"1402\":{ \"E\":{ \"value\":256} },\"1488\":{ \"T\":{ \"value\":257},\"E\":{ \"value\":257} },\"1582\":{ \"S\":{ \"value\":256} },\"1686\":{ \"T\":{ \"value\":256} },\"1766\":{ \"S\":{ \"value\":257},\"T\":{ \"value\":257} },\"Name\":\"test\",\"Desc\":\"\",\"userName\":\"\"}";
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
            conn = new ConnectionManager();

            conn.deleteRecording("6543a052-c2ad-45b6-86ef-df6ee40d5080");
            string test = Properties.Settings.Default.currentUser;
        }
    }
}