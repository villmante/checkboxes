using NUnit.Framework;

namespace draft.Test
{
    class BasicCheckBoxTest : BaseTest
    {

        [Test]
        public static void CheckBoxTest()
        {
            _page.NavigateToPage();
            _page.CheckOneCheckBox();
            _page.AssertSingleCheckBoxDemoSuccessMessage();
        }

        [Test]
        public static void CheckBoxesTest()
        {
            _page.NavigateToPage();
            _page.CheckAllCheckBoxes();
            _page.AssertButtonName("Uncheck All");
        }

        [Test]
        public static void UnchecCheckBoxesTest()
        {
            _page.NavigateToPage();
            _page.CheckAllCheckBoxes();
            _page.ClickGroupButton();
            _page.AssertMultipleCheckBoxesUnchecked();
        }
    }
}

