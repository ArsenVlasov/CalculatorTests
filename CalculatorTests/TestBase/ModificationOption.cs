using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace CalculatorTests
{
    abstract class ModificationOption
    {
        private static WindowsElement s_header;

        public static void ChooseCalculatorMode(WindowsDriver<WindowsElement> session, string name, string mode)
        {
            try
            {
                s_header = session.FindElementByAccessibilityId("Header");
            }
            catch
            {
                s_header = session.FindElementByAccessibilityId("ContentPresenter");
            }
            if (!s_header.Text.Equals($"{name}", StringComparison.OrdinalIgnoreCase))
            {
                session.FindElementByAccessibilityId("TogglePaneButton").Click();
                var splitViewPane = session.FindElementByClassName("SplitViewPane");
                splitViewPane.FindElementByName($"{name} {mode}").Click();
                Assert.IsTrue(s_header.Text.Equals($"{name}", StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}
