using OpenQA.Selenium;

namespace UnitTestProject1
{
    internal class BaseSempleAplicationPage
    {
        protected IWebDriver Driver { get; set; }

        public BaseSempleAplicationPage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}