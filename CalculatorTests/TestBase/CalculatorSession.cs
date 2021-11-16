using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorSession
    {
        private readonly string windowsApplicationDriverUrl = "http://127.0.0.1:8000";
        private readonly string calculatorAppId = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";
        private static Process s_winAppDriverProcess;
        protected static WindowsDriver<WindowsElement> session;

        [OneTimeSetUp]
        public void SetUpDriverAndApp()
        {
            //s_winAppDriverProcess = Process.Start($@"{AppDomain.CurrentDomain.BaseDirectory}\Windows Application Driver\WinAppDriver.exe");
             if (session == null)
            {
                AppiumOptions opt = new AppiumOptions();
                opt.AddAdditionalCapability("app", calculatorAppId);
                opt.AddAdditionalCapability("deviceName", "WindowsPC");
                session = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), opt);
                Assert.IsNotNull(session);
                new WebDriverWait(session, TimeSpan.FromSeconds(1.5))
                    .Until(ExpectedConditions.ElementToBeClickable(By.Name("Calculator")));
            }
        }

        [OneTimeTearDown]
        public void CloseDriverAndApp()
        {
            if (session != null)
            {
                session.Quit();
                session = null;
            }
            //s_winAppDriverProcess?.Kill();
        }
    }
}