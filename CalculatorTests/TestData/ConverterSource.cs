using NUnit.Framework;
using System.Collections.Generic;

namespace CalculatorTests
{
    public abstract class ConverterSource
    {
        public static IEnumerable<TestCaseData> MesureConvertion()
        {
            yield return new TestCaseData(new object[] { 5, MassBlocks.Carats, 1, MassBlocks.Grams });
            yield return new TestCaseData(new object[] { 7, MassBlocks.Miligrams, 0.007, MassBlocks.Grams });
            yield return new TestCaseData(new object[] { 4, MassBlocks.Stone, 896, MassBlocks.Ounces });
            yield return new TestCaseData(new object[] { 2, MassBlocks.Carats, 0.000000393682611, MassBlocks.LongTonsUK });
        }
    }
}
