using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace draft.Page
{
    public class BasicCheckBoxPage : BasePage
    {
        private const string PageAddress = "http://demo.seleniumeasy.com/basic-checkbox-demo.html";
        private IWebElement CheckBox => Driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement CheckBoxMessage => Driver.FindElement(By.Id("txtAge"));
        private const string CheckBoxMessageText = "Success - Check box is checked";
        private IReadOnlyCollection<IWebElement> multipleCheckBoxes => Driver.FindElements(By.ClassName("cb1-element"));
        private IWebElement CheckAll => Driver.FindElement(By.Id("check1"));


        public BasicCheckBoxPage(IWebDriver webdriver) : base(webdriver)
        { }

        public void NavigateToPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
        }

        public void CheckOneCheckBox()
        {
            if (!CheckBox.Selected)
               CheckBox.Click();
        }

        public void CheckAllCheckBoxes()
        {
            foreach (IWebElement singleCheckbox in multipleCheckBoxes)
            {
                if (!singleCheckbox.Selected)
                    singleCheckbox.Click();
            }
        }

        public void ClickGroupButton()
        {
            CheckAll.Click();
        }

        public void AssertMultipleCheckBoxesUnchecked()
        {
            foreach (IWebElement singleCheckbox in multipleCheckBoxes)
            {
                Assert.False(singleCheckbox.Selected, "One is checked!");
            }
        }
        public void AssertSingleCheckBoxDemoSuccessMessage()
        {
            Assert.AreEqual(CheckBoxMessageText, CheckBoxMessage.Text, "wrong text");
        }

        public void AssertCheckBoxDemoSuccessMessage()
        {
            Assert.AreEqual(CheckBoxMessageText, CheckBoxMessage.Text, "wrong text");
        }
        public void AssertButtonName(string expectedName)
        {
            Assert.AreEqual(expectedName, CheckAll.GetAttribute("value"), "Wrong button name");
        }
    }
}
