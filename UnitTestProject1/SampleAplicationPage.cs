using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace UnitTestProject1
{
    internal class SampleAplicationPage : BaseSempleAplicationPage
    {

        public SampleAplicationPage(IWebDriver driver) : base(driver) { }
      

        public bool IsVisible {
            get
            {
                return Driver.Title.Contains(PageTitle);
            }
            internal set { }
        }
         
        private string PageTitle => "Sample Application Lifecycle - Sprint 2 - Ultimate QA";

        public IWebElement FirstNameField => Driver.FindElement(By.XPath("//input[@name = 'firstname']"));

        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//*[@type='submit']"));

        public IWebElement LastNameField => Driver.FindElement(By.Name("lastname"));

        public IWebElement FemaleGenderRadioButton => Driver.FindElement(By.XPath("//input[@value = 'female']"));

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/sample-application-lifecycle-sprint-2/");
            Assert.IsTrue(IsVisible,
                $"Simple aplication page was not visible.Expected=>{PageTitle}." + 
                $"Actual=> {Driver.Title}");
        }

        internal UltimateQAHomePage FillOutFormAndSubmit(TestUser  user)
        {
            switch (user.GenderType)
            {
                case Gender.Male:
                    break;
                case Gender.Female:
                    FemaleGenderRadioButton.Click();
                    break;
                case Gender.Other:
                    break;
                 
            }

            FirstNameField.SendKeys(user.FirstName);
            LastNameField.SendKeys(user.LastName);
            SubmitButton.Submit();
            return new UltimateQAHomePage(Driver);
        }
    }
}