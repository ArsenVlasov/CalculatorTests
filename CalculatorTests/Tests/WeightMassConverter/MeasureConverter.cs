using NUnit.Framework;

namespace CalculatorTests
{
    [TestFixture]
    class MeasureConverter : CalculatorSession
    {
        [SetUp]
        public void ChooseWeightMassConverter()
        {
            ModificationOption.ChooseCalculatorMode(session, "Weight and Mass", "Converter");
        }

        [Test]
        [TestCaseSource(typeof(ConverterSource), nameof(ConverterSource.MesureConvertion))]
        public void MeasureOps(int inputValue, MassBlocks inputMeasure, double expectedValue, MassBlocks outputMeasure)
        {
            WeightMassElement.ClickComboBoxMeasure(session, true, inputMeasure);
            session.FindElementByAccessibilityId(StandardElement.GetDigitsId(inputValue)).Click();
            WeightMassElement.ClickComboBoxMeasure(session, false, outputMeasure);
            Assert.AreEqual(expectedValue, WeightMassElement.GetOutputValue(session));
        }

        [TearDown]
        public void ClearResult()
        {
            session.FindElementByName("Clear entry").Click();
            Assert.Multiple(() =>
            {
                Assert.AreEqual(0, WeightMassElement.GetMeasureAmount(session, true));
                Assert.AreEqual(0, WeightMassElement.GetMeasureAmount(session, false));
            });
        }
    }
}

