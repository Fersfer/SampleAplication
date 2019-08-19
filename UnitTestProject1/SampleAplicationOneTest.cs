using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;


namespace UnitTestProject1
{
    [TestClass]
    [TestCategory("SAM")]

       public class SampleAplicationOneTest
    {
        private IWebDriver Driver { get; set; }
        internal TestUser TheTestUser { get; private set; }

        [TestMethod]
     public void Test1()
        {
           
            var sampleAplicationPage = new SampleAplicationPage(Driver);
            sampleAplicationPage.GoTo();            
            var ultimateQAHomePage = sampleAplicationPage.FillOutFormAndSubmit(TheTestUser);
            Assert.IsTrue(ultimateQAHomePage.IsVisible, "Ultimate QA Home Page was not visible");
           
        }

        [TestMethod]
        public void PretendentTestNumber2()
        {
            var sampleAplicationPage = new SampleAplicationPage(Driver);
            sampleAplicationPage.GoTo();

            var ultimateQAHomePage = sampleAplicationPage.FillOutFormAndSubmit(TheTestUser);
            Assert.IsTrue(ultimateQAHomePage.IsVisible, "Ultimate QA Home Page was not visible");

        }


        [TestInitialize]
        public void SetupForEverySingleTestMethod()
        {
            Driver = GetChromeDriver();

            TheTestUser = new TestUser();
            TheTestUser.FirstName = "Nikolay";
            TheTestUser.LastName = "Blahzah";
            TheTestUser.GenderType = Gender.Female;
        }

        [TestCleanup]
        public void CleanUpAfterEveryTestMethod()
        {
            Driver.Close();
            Driver.Quit();
        }

           

        private IWebDriver GetChromeDriver()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
    }
}
