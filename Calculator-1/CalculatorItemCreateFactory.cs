using System;
using System.Data;
using System.Windows.Forms;

namespace Calculator_1
{
    internal class CalculatorItemCreateFactory
    {
        internal static void TaxCalCreate(TextBox calBox, TextBox formulaBox, TextBox allCalBox, Button taxButton, Button noTaxButton, object sender)
        {
            if (sender.Equals(taxButton))
            {
                if (calBox.Text == "")
                {
                    return;
                }

                string a = calBox.Text;

                string tax = a + "* 1.1";

                DataTable dt = new DataTable();
                var result = dt.Compute(tax, "");

                calBox.Text = Math.Floor((decimal)result).ToString();
                formulaBox.Text = $"{a}円 ⇒ 税込 : " + Math.Floor((decimal)result) + "円";
                allCalBox.Text += formulaBox.Text + "\r\n";
            }
            else if (sender.Equals(noTaxButton))
            {
                if (calBox.Text == "")
                {
                    return;
                }
                string a = calBox.Text;

                string tax = a + "/ 1.1 + 0.1";

                DataTable dt = new DataTable();
                var result = dt.Compute(tax, "");

                calBox.Text = Math.Floor((decimal)result).ToString();
                formulaBox.Text = $"{a}円 ⇒ 税抜 : " + Math.Floor((decimal)result) + "円";
                allCalBox.Text += formulaBox.Text + "\r\n";
            }
        }

        internal static void DecimalPointButton(TextBox calBox, TextBox formulaBox, TextBox allCalBox, object sender)
        {
            if (formulaBox.Text.Contains("=") || formulaBox.Text.Contains("税"))
            {
                calBox.Text += ".";
                formulaBox.Text = calBox.Text;
            }
            else if (formulaBox.Text == "")
            {
                return;
            }
            else
            {
                calBox.Text += ".";
                formulaBox.Text += ".";
            }
        }

        internal static void AnswerButtonCreate(TextBox calBox, TextBox formulaBox, TextBox allCalBox, object sender)
        {
            if (formulaBox.Text.Contains("="))
            {
                return;
            }

            allCalBox.Text += formulaBox.Text + " = ";
            string a = formulaBox.Text
                .Replace("＋", "+")
                .Replace("－", "-")
                .Replace("×", "*")
                .Replace("÷", "/");

            string exp = a;//"(1+6)*5/(7-4)"

            DataTable dt = new DataTable();
            var result = dt.Compute(exp, "");//decimalなのでキャストいらず

            formulaBox.Text += " = " + result.ToString();
            calBox.Text = result.ToString();
            allCalBox.Text += result.ToString() + "\r\n";
            #region

            //FormulaBoxClear(sender, formulaBox, calBox, answerButton);
            //var add = Eval(allCalBox.Text);
            //allCalBox.Text = add.ToString();



            //calBox.ToString =
            ////var addButton = "=";
            ////while (true)
            ////{
            ////    if (addButton == "=")
            ////    {
            ////        break;
            ////    }
            //int a =0;
            //    Cal(a);
            ////}
            ////var addButton = "=";
            //calBox.Text = a.ToString();//addButton.Text
            #endregion
        }
    }
}