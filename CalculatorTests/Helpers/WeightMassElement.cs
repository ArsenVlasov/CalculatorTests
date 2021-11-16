using OpenQA.Selenium.Appium.Windows;

namespace CalculatorTests
{
    public abstract class WeightMassElement
    {
        public static int GetMeasureAmount(WindowsDriver<WindowsElement> session, bool isInput)
        {
            string measure;
            string amountString;
            int amount;
            if (isInput)
            {
                measure = session.FindElementByXPath("//ComboBox[@Name ='Input unit']").Text;
                amountString = session.FindElementByXPath($"//Text[@Name ='Convert from 0 {measure}']").Text.Split(' ')[2];
            }
            else
            {
                measure = session.FindElementByXPath("//ComboBox[@Name ='Output unit']").Text;
                amountString = session.FindElementByXPath($"//Text[@Name ='Converts into 0 {measure}']").Text.Split(' ')[2];
            }
            bool isCorrect = int.TryParse(amountString, out amount);
            return (isCorrect) ? amount : throw new System.Exception("Incorrect name of amount measure element");

        }

        public static void ClickComboBoxMeasure(WindowsDriver<WindowsElement> session, bool isInput, MassBlocks measure)
        {
            string teg = isInput? "Input": "Output";
            var comboBox=session.FindElementByXPath($"//ComboBox[@Name ='{teg} unit']");
            comboBox.Click();
            var blocks = comboBox.FindElementsByClassName("TextBlock");
            blocks[(int)measure].Click();
            comboBox.Clear();
        }

        public static double GetOutputValue(WindowsDriver<WindowsElement> session)
        {
            return double.Parse(session.FindElementByAccessibilityId("Value2").Text.Split(' ')[2]);
        }
    }
}
