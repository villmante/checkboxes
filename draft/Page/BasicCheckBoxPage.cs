
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace draft.Page
{
    public class BasicCheckBoxPage : BasePage
    {

        private const string PageAddress = "http://demo.seleniumeasy.com/basic-checkbox-demo.html";
        private IWebElement checkBox => Driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement checkBoxMessage => Driver.FindElement(By.Id("txtAge"));
        private const string checkBoxMessageText = "Success - Check box is checked";
        private IReadOnlyCollection<IWebElement> checkBoxes => Driver.FindElements(By.ClassName("cb1-element"));
        private IWebElement checkAll => Driver.FindElement(By.Id("check1"));

        public BasicCheckBoxPage(IWebDriver webdriver) : base(webdriver)
        { }

        public BasicCheckBoxPage NavigateToPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public void CheckOneCheckBox()
        {
            if (!checkBox.Selected)
                checkBox.Click();
        }

        public void ClickGroupButton()
        {
            checkAll.Click();
        }

        public void AssertCheckBoxesUnchecked()
        {
            foreach (IWebElement singleCheckbox in checkBoxes)
            {
                Assert.False(singleCheckbox.Selected, "One of checked!");
            }
        }

        public void AssertButtonName(string expectedName)
        {
            Assert.AreEqual(expectedName, checkAll.GetAttribute("value"), "Wrong label");
        }

        public void AssertOneCheckBoxSuccess()
        {
            Assert.AreEqual(checkBoxMessageText, checkBoxMessage.Text, "wrong text!");
        }

        public void CheckAllCheckBoxes()
        {
            foreach (IWebElement singleCheckbox in checkBoxes)
            {
                if (!singleCheckbox.Selected)
                    singleCheckbox.Click();
            }
        }
    }
}
