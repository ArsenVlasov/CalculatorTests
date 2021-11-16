using NUnit.Framework;
using System.Threading;

namespace CalculatorTests
{
    [TestFixture]
    class DigitsOperationDifference : CalculatorSession
    {
        [SetUp]
        public void ChooseStandartCalculator()
        {
            ModificationOption.ChooseCalculatorMode(session, "Standard", "Calculator");
        }

        /*
          StandardElement.ChangeNumberSign(session, firstDigit);
            session.FindElementByAccessibilityId(StandardElement.GetDigitsId(firstDigit)).Click();
            session.FindElementByAccessibilityId(StandardElement.GetMathSignsId(operationSign)).Click();
            StandardElement.ChangeNumberSign(session, secondDigit);
            session.FindElementByAccessibilityId(StandardElement.GetDigitsId(secondDigit)).Click();
            session.FindElementByName("Equals").Click();
            Assert.AreEqual(expectResult.ToString(), StandardElement.GetCalculatorResultText(session));
            */

        [Test]
        [TestCaseSource(typeof(ArithmeticOperationsSource), nameof(ArithmeticOperationsSource.DigitsDifference))]
        public void ArithmeticOps(int firstDigit, MathematicalSigns operationSign, int secondDigit, double expectResult)
        {
            Thread.Sleep(1000);

            StandardElement.ChangeNumberSign(session, firstDigit);
            StandardElement.EnterValue(session, firstDigit);
            StandardElement.EnterValue(session, (char)operationSign);
            StandardElement.ChangeNumberSign(session, secondDigit);
            StandardElement.EnterValue(session, secondDigit);
            StandardElement.EnterValue(session, (char)MathematicalSigns.Equals);
            Assert.AreEqual(expectResult.ToString(), StandardElement.GetCalculatorResultText(session));
        }

        [TearDown]
        public void ClearResult()
        {
            session.FindElementByName("Clear").Click();
            Assert.AreEqual("0", StandardElement.GetCalculatorResultText(session));
        }
    }
}
