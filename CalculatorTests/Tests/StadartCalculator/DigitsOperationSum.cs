using NUnit.Framework;
using System.Threading;

namespace CalculatorTests
{
    [TestFixture]
    class DigitsOperationSum : CalculatorSession
    {
        [SetUp]
        public void ChooseStandartCalculator()
        {
            ModificationOption.ChooseCalculatorMode(session, "Standard", "Calculator");
        }

        [Test]
        [TestCaseSource(typeof(ArithmeticOperationsSource), nameof(ArithmeticOperationsSource.DigitsSum))]
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
