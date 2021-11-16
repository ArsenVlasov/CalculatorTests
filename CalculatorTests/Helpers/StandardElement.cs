using OpenQA.Selenium.Appium.Windows;
using System;

namespace CalculatorTests
{
    public abstract class StandardElement
    {
        private static string s_calculatorResultXPath="//Text[@AutomationId='CalculatorResults']";

        public static string GetDigitsId(int inputValue) => 
            $"num{Math.Abs(inputValue)}Button";

        public static string GetMathSignsId(MathematicalSigns sign)=> 
            $"{Enum.GetName(typeof(MathematicalSigns), sign).ToLower()}Button";

        public static void EnterValue (WindowsDriver<WindowsElement> session, object value)
        {
            session.FindElementByXPath(s_calculatorResultXPath).SendKeys(Convert.ToString(value));
        }

        public static string GetCalculatorResultText(WindowsDriver<WindowsElement> session)
        {
            return session.FindElementByXPath(s_calculatorResultXPath).Text.Replace("Display is", string.Empty).Trim();
        }

        public static void ChangeNumberSign( WindowsDriver<WindowsElement> session, int inputValue)
        {
            if (inputValue < 0)
            {
                session.FindElementByName("Positive Negative").Click();
            }
        }
    }
}
