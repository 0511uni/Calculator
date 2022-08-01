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
    }
}