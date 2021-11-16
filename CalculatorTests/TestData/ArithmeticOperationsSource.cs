using NUnit.Framework;
using System.Collections.Generic;

namespace CalculatorTests
{
    public abstract class ArithmeticOperationsSource
    {
        public static IEnumerable<TestCaseData> DigitsSum()
        {
            yield return new TestCaseData(new object[] { 1, MathematicalSigns.Plus, 7, 8 });
            yield return new TestCaseData(new object[] { 5, MathematicalSigns.Plus, 2, 7 });
            yield return new TestCaseData(new object[] { 0, MathematicalSigns.Plus, 0, 0 });
        }

        public static IEnumerable<TestCaseData> DigitsDifference()
        {
            yield return new TestCaseData(new object[] { 8, MathematicalSigns.Minus, 7, 1 });
            yield return new TestCaseData(new object[] { 6, MathematicalSigns.Minus, 9, -3 });
            yield return new TestCaseData(new object[] { 1, MathematicalSigns.Minus, 1, 0 });
        }

        public static IEnumerable<TestCaseData> DigitsMultiply()
        {
            yield return new TestCaseData(new object[] { 1, MathematicalSigns.Multiply, 9, 9 });
            yield return new TestCaseData(new object[] { 5, MathematicalSigns.Multiply, 6, 30 });
            yield return new TestCaseData(new object[] { 1, MathematicalSigns.Multiply, 0, 0 });

        }

        public static IEnumerable<TestCaseData> DigitsDivisons()
        {
            yield return new TestCaseData(new object[] { 6, MathematicalSigns.Divide, 3, 2 });
            yield return new TestCaseData(new object[] { 6, MathematicalSigns.Divide, 5, 1.2 });
            yield return new TestCaseData(new object[] { 1, MathematicalSigns.Divide, 1, 1 });
        }
    }
}
