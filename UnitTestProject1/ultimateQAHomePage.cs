using OpenQA.Selenium;

namespace UnitTestProject1
{
    internal class UltimateQAHomePage : BaseSempleAplicationPage
    {


        public UltimateQAHomePage(IWebDriver driver) : base(driver) { }
       

        public bool IsVisible {
            get
            {
                try
                {
                    return StartHereButton.Displayed;
                }
                catch ( NoSuchElementException)
                {
                    return false;
                     
                }
            }
        }
            

        public IWebElement StartHereButton => Driver.FindElement(By.LinkText("Start here"));
    }
} 