using System;
using System.Globalization;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        private readonly Helpers _helpers;
        private string dateTimeFormatter = "dddd dd MMMM yyyy HH:mm:ss";
        private String ukFormatedTimeResponse;
        private String canadaFormatedTimeResponse;
        private String timeDiffrenceResponse;
        private String ExpectedResponse240Min = "You are 240m ahead of Canada";
        private String ExpectedResponse300Min = "You are 300m ahead of Canada";
        private String capturedStdOut;



        public DateTime getCurrentUKTime() //Assumed GB UK time zone
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.Now.ToUniversalTime(),
                TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"));
        }

        public DateTime getCurrentCanadaTime() //Assumed Eastern Standard Time for Cananda
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.Now.ToUniversalTime(),
                TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
        }

        public DateTime getSpecificUKTime(int year, int month, int day, int hour, int minute, int second) //Assumed GB UK time zone
        {
            return TimeZoneInfo.ConvertTimeFromUtc(new DateTime(year,month,day,hour,minute,second).ToUniversalTime(),
                TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"));
        }

        public DateTime getSpecificCanadaTime(int year, int month, int day, int hour, int minute, int second) //Assumed Eastern Standard Time for Cananda
        {
            return TimeZoneInfo.ConvertTimeFromUtc(new DateTime(year, month, day, hour, minute, second).ToUniversalTime(),
                TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
        }

        public String getFormatedDate(DateTime datetime, String Format)
        {
            return datetime.ToString(Format);
        }

        public double DateDiffInTime(DateTime dt1, DateTime dt2)
        {
            return Math.Round(dt1.Subtract(dt2).TotalMinutes, 0);
        }
        public Tests()
        {
            _helpers = new Helpers();
            
        }


        [TestMethod]
        public void TestUkWorldAPIResponse()
        {
            /***** TO DO **********
           Mocked - Ideally from mocking service - 
           Created a Feed from mocked httpclient endpoint or real httpclient endpoint as switch as required
           **********************/

            //To DO - +Ve -  Test 200 Ok respons using moked API
            //To DO - -Ve - Test 400 Not Found respons using moked API
            //To DO - -Ve - Test 404 Not Authorised respons using moked API
            //To DO - -Ve - Test 500 Not Authorised respons using moked API
        }

        [TestMethod]
        public void TestCanadaWorldAPIResponse()
        {
            /***** TO DO **********
           Mocked - Ideally from mocking service - 
           Created a Feed from mocked httpclient endpoint or real httpclient endpoint as switch as required
           **********************/

            //To DO - +Ve -  Test 200 Ok respons using moked API
            //To DO - -Ve - Test 400 Not Found respons using moked API
            //To DO - -Ve - Test 404 Not Authorised respons using moked API
            //To DO - -Ve - Test 500 Not Authorised respons using moked API
        }


        [TestMethod]
        [Description("Test sceanrio to test datetime diffrence for current Uk and candian time")] 
        public void CurrentDateTest()
        {
            /***** TO DO **********
           Mocked - Ideally from mocking service - 
           Created a Feed from mocked httpclient endpoint or real httpclient endpoint as switch as required
           **********************/

            // Runs the app and returns the output from Console.WriteLine
            capturedStdOut = _helpers.CapturedStdOut(_helpers.RunApp);

            //Expected 
            ukFormatedTimeResponse = "UK Time: " + getFormatedDate(getCurrentUKTime(), dateTimeFormatter);
            canadaFormatedTimeResponse = "Canada Time: " + getFormatedDate(getCurrentCanadaTime(), dateTimeFormatter);
            timeDiffrenceResponse = $"You are {DateDiffInTime(getCurrentUKTime(), getCurrentCanadaTime())}m ahead of Canada";

            Console.WriteLine("<====== Actual Result from Standard Ouput (Program.cs) =======>");
            Console.WriteLine(capturedStdOut);

            Console.WriteLine("<====== Expected Result =======>");
            Console.WriteLine(ukFormatedTimeResponse);
            Console.WriteLine(canadaFormatedTimeResponse);
            Console.WriteLine(ExpectedResponse240Min);

            //Assert Current time and diffrence -Actual Response from mocking service or Standouput - Used Standard Output Here (From World API)
            // Run an assertion on the captured output
            Assert.IsTrue(capturedStdOut.Contains(ukFormatedTimeResponse));
            Assert.IsTrue(capturedStdOut.Contains(canadaFormatedTimeResponse));
            Assert.IsTrue(capturedStdOut.Contains(ExpectedResponse240Min));
            
        }

        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Description("Test sceanrio to test datetime diffrence for for uk on new year (early morning)")]
        public void NewYearhDateTimeTest()
        {
            /***** TO DO **********
           Mocked - Ideally from mocking service - 
           Created a Feed from mocked httpclient endpoint or real httpclient endpoint as switch as required
           **********************/

            ukFormatedTimeResponse = "UK Time: " + getFormatedDate(getSpecificUKTime(2025, 1, 1, 0, 0, 0), dateTimeFormatter);
            canadaFormatedTimeResponse = "Canada Time: " + getFormatedDate(getSpecificCanadaTime(2025, 1, 1, 0, 0, 0), dateTimeFormatter);
            timeDiffrenceResponse = $"You are {DateDiffInTime(getSpecificUKTime(2025, 1, 1, 0, 0, 0), getSpecificCanadaTime(2025, 1, 1, 0, 0, 0))}m ahead of Canada";

            Console.WriteLine("<====== Actual Mocked Result from  DateTime Lib ( Should be derived from Mocking Response) =======>");
            Console.WriteLine("UK Time: " + getFormatedDate(getSpecificUKTime(2025, 1, 1, 0, 0, 0), dateTimeFormatter));
            Console.WriteLine("Canada Time: " + getFormatedDate(getSpecificCanadaTime(2025, 1, 1, 0, 0, 0), dateTimeFormatter));
            Console.WriteLine(timeDiffrenceResponse);

            Console.WriteLine("<====== Expected Result  =======>");
            Console.WriteLine("UK Time: Wednesday 01 January 2025 00:00:00");
            Console.WriteLine("Canada Time: Tuesday 31 December 2024 19:00:00");
            Console.WriteLine(ExpectedResponse300Min);

            //Assert Current time and diffrence -Actual Response from mocking service 
            Assert.AreEqual(ukFormatedTimeResponse, "UK Time: Wednesday 01 January 2025 00:00:00");
            Assert.AreEqual(canadaFormatedTimeResponse, "Canada Time: Tuesday 31 December 2024 19:00:00");
            Assert.AreEqual(timeDiffrenceResponse,ExpectedResponse300Min);
        }


        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Description("Test sceanrio to test datetime diffrence on British March Daylight Time change")]
        public void BritishMarchTimeChangeTest()
        {
            /***** TO DO **********
           Mocked - Ideally from mocking service - 
           Created a Feed from mocked httpclient endpoint or real httpclient endpoint as switch as required
           **********************/

            var ukFormatedTimeResponse = "UK Time: " + getFormatedDate(getSpecificUKTime(2025, 3, 30, 1, 0, 1), dateTimeFormatter);
            var canadaFormatedTimeResponse = "Canada Time: " + getFormatedDate(getSpecificCanadaTime(2025, 3, 30, 1, 0, 1), dateTimeFormatter);
            var timeDiffrenceResponse = $"You are {DateDiffInTime(getSpecificUKTime(2025, 3, 30, 1, 0, 1), getSpecificCanadaTime(2025, 3, 30, 1, 0, 1))}m ahead of Canada";

            Console.WriteLine("<====== Actual Mocked Result from  DateTime Lib ( Should be derived from Mocking Response) =======>");
            Console.WriteLine("UK Time: " + getFormatedDate(getSpecificUKTime(2025, 3, 30, 1, 0, 1), dateTimeFormatter));
            Console.WriteLine("Canada Time: " + getFormatedDate(getSpecificCanadaTime(2025, 3, 30, 1, 0, 1), dateTimeFormatter));
            Console.WriteLine(timeDiffrenceResponse);

            Console.WriteLine("<====== Expected Result =======>");
            Console.WriteLine("UK Time: Sunday 30 March 2025 02:00:01");
            Console.WriteLine("Canada Time: Saturday 29 March 2025 21:00:01");
            Console.WriteLine(ExpectedResponse300Min);

            //Assert Current time and diffrence -Actual Response from mocking service 
            Assert.AreEqual(ukFormatedTimeResponse, "UK Time: Sunday 30 March 2025 02:00:01");
            Assert.AreEqual(canadaFormatedTimeResponse, "Canada Time: Saturday 29 March 2025 21:00:01");
            Assert.AreEqual(timeDiffrenceResponse, ExpectedResponse300Min);
        }

        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Description("Test sceanrio to test datetime diffrence on British October Daylight Time change")]
        public void BritishOctoberTimeChangeTest()
        {
            /***** TO DO **********
           Mocked - Ideally from mocking service - 
           Created a Feed from mocked httpclient endpoint or real httpclient endpoint as switch as required
           **********************/

            ukFormatedTimeResponse = "UK Time: " + getFormatedDate(getSpecificUKTime(2025, 10, 31, 2, 0, 1), dateTimeFormatter);
            canadaFormatedTimeResponse = "Canada Time: " + getFormatedDate(getSpecificCanadaTime(2025, 10, 31, 2, 0, 1), dateTimeFormatter);
            timeDiffrenceResponse = $"You are {DateDiffInTime(getSpecificUKTime(2025, 10, 31, 2, 0, 1), getSpecificCanadaTime(2025, 10, 31, 2, 0, 1))}m ahead of Canada";
           
            Console.WriteLine("<====== Actual Mocked Result from  DateTime Lib ( Should be derived from Mocking Response) =======>");
            Console.WriteLine("UK Time: " + getFormatedDate(getSpecificUKTime(2025, 10, 31, 2, 0, 1), dateTimeFormatter));
            Console.WriteLine("Canada Time: " + getFormatedDate(getSpecificCanadaTime(2025, 10, 31, 2, 0, 1), dateTimeFormatter));
            Console.WriteLine(timeDiffrenceResponse);

            Console.WriteLine("<====== Expected Result =======>");
            Console.WriteLine("UK Time: Friday 31 October 2025 02:00:00");
            Console.WriteLine("Canada Time: Thursday 30 October 2025 22:00:00");
            Console.WriteLine(ExpectedResponse240Min);

            //Assert Current time and diffrence -Actual Response from mocking service 
            Assert.AreEqual(ukFormatedTimeResponse, "UK Time: Friday 31 October 2025 02:00:01");
            Assert.AreEqual(canadaFormatedTimeResponse, "Canada Time: Thursday 30 October 2025 22:00:01");
            Assert.AreEqual(timeDiffrenceResponse, ExpectedResponse240Min);
        }

        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Description("Test sceanrio to test datetime diffrencein 2026 (Non-Leap year) Time change")]
        public void NonLeapYearTimeChangeTest()
        {
            /***** TO DO **********
           Mocked - Ideally from mocking service - 
           Created a Feed from mocked httpclient endpoint or real httpclient endpoint as switch as required
           **********************/

            ukFormatedTimeResponse = "UK Time: " + getFormatedDate(getSpecificUKTime(2026, 3, 1, 0, 0, 0), dateTimeFormatter);
            canadaFormatedTimeResponse = "Canada Time: " + getFormatedDate(getSpecificCanadaTime(2026, 3, 1, 0, 0, 0), dateTimeFormatter);
            timeDiffrenceResponse = $"You are {DateDiffInTime(getSpecificUKTime(2026, 3, 1, 0, 0, 0), getSpecificCanadaTime(2026, 3, 1, 0, 0, 0))}m ahead of Canada";

            Console.WriteLine("<====== Actual Mocked Result from  DateTime Lib ( Should be derived from Mocking Response) =======>");
            Console.WriteLine("UK Time: " + getFormatedDate(getSpecificUKTime(2026, 3, 1, 0, 0, 0), dateTimeFormatter));
            Console.WriteLine("Canada Time: " + getFormatedDate(getSpecificCanadaTime(2026, 3, 1, 0, 0, 0), dateTimeFormatter));
            Console.WriteLine(timeDiffrenceResponse);

            Console.WriteLine("<====== Expected Result =======>");
            Console.WriteLine("UK Time: Sunday 01 March 2026 00:00:00");
            Console.WriteLine("Canada Time: Saturday 28 February 2026 19:00:00");
            Console.WriteLine(ExpectedResponse300Min);

            //Assert Current time and diffrence -Actual Response from mocking service 
            Assert.AreEqual(ukFormatedTimeResponse, "UK Time: Sunday 01 March 2026 00:00:00");
            Assert.AreEqual(canadaFormatedTimeResponse, "Canada Time: Saturday 28 February 2026 19:00:00");
            Assert.AreEqual(timeDiffrenceResponse, ExpectedResponse300Min);
        }

        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Description("Test sceanrio to test datetime diffrenc in 2028 (Leap year) Time change")]
        public void LeapYearTimeChangeTest()
        {
            /***** TO DO **********
           Mocked - Ideally from mocking service - 
           Created a Feed from mocked httpclient endpoint or real httpclient endpoint as switch as required
           **********************/

            ukFormatedTimeResponse = "UK Time: " + getFormatedDate(getSpecificUKTime(2028, 3, 1, 0, 0, 0), dateTimeFormatter);
            canadaFormatedTimeResponse = "Canada Time: " + getFormatedDate(getSpecificCanadaTime(2028, 3, 1, 0, 0, 0), dateTimeFormatter);
            timeDiffrenceResponse = $"You are {DateDiffInTime(getSpecificUKTime(2028, 3, 1, 0, 0, 0), getSpecificCanadaTime(2028, 3, 1, 0, 0, 0))}m ahead of Canada";

            Console.WriteLine("<====== Actual Mocked Result from  DateTime Lib ( Should be derived from Mocking Response) =======>");
            Console.WriteLine("UK Time: " + getFormatedDate(getSpecificUKTime(2028, 3, 1, 0, 0, 0), dateTimeFormatter));
            Console.WriteLine("Canada Time: " + getFormatedDate(getSpecificCanadaTime(2028, 3, 1, 0, 0, 0), dateTimeFormatter));
            Console.WriteLine(timeDiffrenceResponse);

            Console.WriteLine("<====== Expected Result =======>");
            Console.WriteLine("UK Time: Wednesday 01 March 2028 00:00:00");
            Console.WriteLine("Canada Time: Tuesday 29 February 2028 19:00:00");
            Console.WriteLine(ExpectedResponse300Min);

            //Assert Current time and diffrence -Actual Response from mocking service 
            Assert.AreEqual(ukFormatedTimeResponse, "UK Time: Wednesday 01 March 2028 00:00:00");
            Assert.AreEqual(canadaFormatedTimeResponse, "Canada Time: Tuesday 29 February 2028 19:00:00");
            Assert.AreEqual(timeDiffrenceResponse, ExpectedResponse300Min);
        }

        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Description("Test sceanrio to test datetime diffrence on Eastern March Daylight Time change")]
        public void EasternMarchTimeChangeTest()
        {
            /***** TO DO **********
           Mocked - Ideally from mocking service - 
           Created a Feed from mocked httpclient endpoint or real httpclient endpoint as switch as required
           **********************/

            var ukFormatedTimeResponse = "UK Time: " + getFormatedDate(getSpecificUKTime(2025, 3, 09, 7, 0, 0), dateTimeFormatter);
            var canadaFormatedTimeResponse = "Canada Time: " + getFormatedDate(getSpecificCanadaTime(2025, 3, 09, 7, 0, 0), dateTimeFormatter);
            var timeDiffrenceResponse = $"You are {DateDiffInTime(getSpecificUKTime(2025, 3, 09, 7, 0, 1), getSpecificCanadaTime(2025, 3, 09, 7, 0, 0))}m ahead of Canada";

            Console.WriteLine("<====== Actual Mocked Result from  DateTime Lib ( Should be derived from Mocking Response) =======>");
            Console.WriteLine("UK Time: " + getFormatedDate(getSpecificUKTime(2025, 3, 09, 7, 0, 0), dateTimeFormatter));
            Console.WriteLine("Canada Time: " + getFormatedDate(getSpecificCanadaTime(2025, 3, 09, 7, 0, 0), dateTimeFormatter));
            Console.WriteLine(timeDiffrenceResponse);

            Console.WriteLine("<====== Expected Result =======>");
            Console.WriteLine("UK Time: Sunday 09 March 2025 07:00:00");
            Console.WriteLine("Canada Time: Sunday 09 March 2025 03:00:00");
            Console.WriteLine(ExpectedResponse300Min);

            //Assert Current time and diffrence -Actual Response from mocking service 
            Assert.AreEqual(ukFormatedTimeResponse, "UK Time: Sunday 09 March 2025 07:00:00");
            Assert.AreEqual(canadaFormatedTimeResponse, "Canada Time: Sunday 09 March 2025 03:00:00");
            Assert.AreEqual(timeDiffrenceResponse, ExpectedResponse240Min);
        }

        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Description("Test sceanrio to test datetime diffrence on Eastern November Daylight Time change")]
        public void EasternNovemberTimeChangeTest()
        {
            /***** TO DO **********
           Mocked - Ideally from mocking service - 
           Created a Feed from mocked httpclient endpoint or real httpclient endpoint as switch as required
           **********************/

            ukFormatedTimeResponse = "UK Time: " + getFormatedDate(getSpecificUKTime(2025, 11, 2, 6, 0, 0), dateTimeFormatter);
            canadaFormatedTimeResponse = "Canada Time: " + getFormatedDate(getSpecificCanadaTime(2025, 11, 2, 6, 0, 0), dateTimeFormatter);
            timeDiffrenceResponse = $"You are {DateDiffInTime(getSpecificUKTime(2025, 11, 2, 6, 0, 0), getSpecificCanadaTime(2025, 11, 2, 6, 0, 0))}m ahead of Canada";

            Console.WriteLine("<====== Actual Mocked Result from  DateTime Lib ( Should be derived from Mocking Response) =======>");
            Console.WriteLine("UK Time: " + getFormatedDate(getSpecificUKTime(2025, 11, 2, 6, 0, 0), dateTimeFormatter));
            Console.WriteLine("Canada Time: " + getFormatedDate(getSpecificCanadaTime(2025, 11, 2, 6, 0, 0), dateTimeFormatter));
            Console.WriteLine(timeDiffrenceResponse);

            Console.WriteLine("<====== Expected Result =======>");
            Console.WriteLine("UK Time: Sunday 02 November 2025 06:00:00");
            Console.WriteLine("Canada Time: Sunday 02 November 2025 01:00:00");
            Console.WriteLine(ExpectedResponse240Min);

            //Assert Current time and diffrence -Actual Response from mocking service 
            Assert.AreEqual(ukFormatedTimeResponse, "UK Time: Sunday 02 November 2025 06:00:00");
            Assert.AreEqual(canadaFormatedTimeResponse, "Canada Time: Sunday 02 November 2025 01:00:00");
            Assert.AreEqual(timeDiffrenceResponse, ExpectedResponse300Min);
        }

    }
    internal class BeforeMethodAttribute : Attribute
    {
    }
}