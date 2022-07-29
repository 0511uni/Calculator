using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_1
{
    //ぼやけるやサイズ変わる問題→http://www.ams.eng.osaka-u.ac.jp/user/ishihara/?p=1550
    public partial class Calculator : Form
    {
        string number = "";
        string basicArithmeticOperations = "＋－";

        public Calculator()
        {
            InitializeComponent();
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        bool once;

        private void NumberButtonClicked(object sender, EventArgs e)
        {
            // 計算式表示ウィンドウの文字
            string formuraData = formulaBox.Text;

            // inputDataに記号が含まれているか
            // 含まれていなければ -1
            int contain = formuraData.IndexOf(basicArithmeticOperations);

            // 計算式ウィンドウに記号が含まれていなくて、
            // 計算式ウィンドウが空でなくて
            // チェック最初であること。チェック後、２回目では使えない
            // 他の記号を押すと１回目に初期化される
            if (contain != -1 && formuraData != "" && !once)
            {
                calBox.Text = "";
                once = true;
            }
            else if (formuraData.Contains("="))
            {
                calBox.Text = "";
                formulaBox.Text = calBox.Text;
            }
            else if (formuraData == "" && sender.Equals(button00))
            {
                return;
            }

            number = (sender as Button).Text;
            calBox.Text += number.ToString();
            formulaBox.Text += number.ToString();
        }

        private void AnswerButton_Clicked(object sender, EventArgs e)
        {
            //formulaBox.Text += calBox.Text;
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

            //FormulaBoxClear(sender, formulaBox, calBox, answerButton);
            #region
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

        private void FormulaBoxClear(object sender, TextBox formulaBox, TextBox calBox, Button answerButton)
        {
            if (sender.Equals(answerButton))
            {
                formulaBox.Text = "";
                formulaBox.Text = calBox.Text;
            }
        }

        #region
        //private void Cal(int cal)
        //{
        //    //var cal = 0;
        //    var add = calBox.Text;
        //    switch (add)
        //    {
        //        case "+":
        //            cal += number;
        //            calBox.Text = cal.ToString();
        //            break;
        //        case "-":
        //            cal -= number;
        //            calBox.Text = cal.ToString();
        //            break;
        //        case "×":
        //            cal *= number;
        //            calBox.Text = cal.ToString();
        //            break;
        //        case "÷":
        //            cal /= number;
        //            calBox.Text = cal.ToString();
        //            break;
        //    }
        //}
        #endregion

        private void ArithmeticOperationSymbolClicked(object sender, EventArgs e)
        {
            if (formulaBox.Text.Contains("=") || formulaBox.Text.Contains("税"))
            {
                formulaBox.Text = calBox.Text;
            }
            basicArithmeticOperations = (sender as Button).Text;
            formulaBox.Text += basicArithmeticOperations.ToString();
            once = false;
        }
        #region
        //private void AddButton_Clicked(object sender, EventArgs e)
        //{
        //    formulaBox.Text += calBox.Text;
        //    basicArithmeticOperations = "＋";
        //    formulaBox.Text += basicArithmeticOperations.ToString();
        //    calBox.Text = "";
        //    #region
        //    //int a = 0;
        //    //Cal(a);
        //    //calBox.Text += a.ToString();
        //    //var value = calox.Text;
        //    //object add = value;
        //    //int add = 0;
        //    //add += number;
        //    //calBox.Text = add.ToString();
        //    #endregion
        //}

        //private void SubtractButton_Clicked(object sender, EventArgs e)
        //{
        //    formulaBox.Text += calBox.Text;
        //    basicArithmeticOperations = "－";
        //    formulaBox.Text += basicArithmeticOperations.ToString();
        //    calBox.Text = "";
        //}

        //private void MultiplyButton_Clicked(object sender, EventArgs e)
        //{
        //    formulaBox.Text += calBox.Text;
        //    basicArithmeticOperations = "×";
        //    formulaBox.Text += basicArithmeticOperations.ToString();
        //    calBox.Text = "";
        //}

        //private void DivideButton_Clicked(object sender, EventArgs e)
        //{
        //    formulaBox.Text += calBox.Text;
        //    basicArithmeticOperations = "÷";
        //    formulaBox.Text += basicArithmeticOperations.ToString();
        //    calBox.Text = "";
        //}
        #endregion
        private void ExitButton_Clicked(object sender, EventArgs e)
        {
            var result = MessageBox.Show("終了しますか？！", "アプリケーション終了", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void ClearButtonClicked(object sender, EventArgs e)
        {
            calBox.Clear();
            formulaBox.Clear();
        }

        private void TaxButtonClicked(object sender, EventArgs e)
        {

            string a = calBox.Text;

            string tax = a + "* 1.1";

            DataTable dt = new DataTable();
            var result = dt.Compute(tax, "");

            calBox.Text = Math.Floor((decimal)result).ToString();
            formulaBox.Text = $"{a}円 ⇒ 税込 : " + Math.Floor((decimal)result) + "円";
            allCalBox.Text += formulaBox.Text + "\r\n";
        }

        private void NoTaxButtonClicked(object sender, EventArgs e)
        {
            string a = calBox.Text;

            string tax = a + "/ 1.1 + 0.1";

            DataTable dt = new DataTable();
            var result = dt.Compute(tax, "");

            calBox.Text = Math.Floor((decimal)result).ToString();
            formulaBox.Text = $"{a}円 ⇒ 税抜 : " + Math.Floor((decimal)result) + "円";
            allCalBox.Text += formulaBox.Text + "\r\n";
        }

        private void DecimalPointButtonClicked(object sender, EventArgs e)
        {
            if (formulaBox.Text.Contains("=") || formulaBox.Text.Contains("税"))
            {
                var number = ".";
                calBox.Text += number.ToString();
                formulaBox.Text = calBox.Text;
            }
            else if (formulaBox.Text == "")
            {
                return;
            }
            else
            {
                var number = ".";
                calBox.Text += number.ToString();
                formulaBox.Text += number.ToString();
            }
        }

        private void LoadMenuClicked(object sender, EventArgs e)
        {
            Factory.DataCreateLoad(allCalBox);
        }

        private void SaveMenuClicked(object sender, EventArgs e)
        {
            Factory.DataCreate(allCalBox);
        }

        private void BmiResultButtonClicked(object sender, EventArgs e)
        {
            Factory.BmiCreate(tabControl1,allCalBox, heightBox, weightBox, bmiBox);
        }

        private void BaseWeightButtonClicked(object sender, EventArgs e)
        {
            Factory.BaseWeightCreata(tabControl1,allCalBox, heightBox, weightBox, baseWeightBox);
        }

        private void CalHeigthtButtonClicked(object sender, EventArgs e)
        {
            heightBox.Text = "";
            heightBox.Text += calBox.Text;
            calBox.Clear();
            formulaBox.Clear();

            if (heightBox.Text == "")
            {
                tabControl1.SelectedIndex = 0;
            }
        }

        private void CalWeigthtButtonClicked(object sender, EventArgs e)
        {
            weightBox.Text = "";
            weightBox.Text += calBox.Text;
            calBox.Clear();
            formulaBox.Clear();

            if (weightBox.Text == "")
            {
                tabControl1.SelectedIndex = 0;
            }
        }

        private void SaveItemClicked(object sender, EventArgs e)
        {
            Factory.DataSave(allCalBox);
        }

        private void LoadItemClicked(object sender, EventArgs e)
        {
            Factory.DataLoad(allCalBox);
        }

        private void AnnualIncomeCalButtonClicked(object sender, EventArgs e)
        {
            annualIncomeBox.Text = "";
            annualIncomeBox.Text += calBox.Text;
            calBox.Clear();
            formulaBox.Clear();

            if (annualIncomeBox.Text == "")
            {
                tabControl1.SelectedIndex = 0;
            }
        }

        private void HourlyWageResultButtonClicked(object sender, EventArgs e)
        {
            Factory.HourlyWageCal(tabControl1,hourlyWageResultButton, hourlyWageReverseResultButton, annualIncomeBox, hourlyWageResultBox, allCalBox, sender);
        }

        private void HourlyWageReverseResultButtonClicked(object sender, EventArgs e)
        {
            Factory.HourlyWageCal(tabControl1,hourlyWageResultButton, hourlyWageReverseResultButton, annualIncomeBox, hourlyWageResultBox, allCalBox, sender);
        }

        private void WalkWhatPartFromStationCalButtonClicked(object sender, EventArgs e)
        {
            if (walkWhatPartFromStationCalBox.Text == "")
            {
                tabControl1.SelectedIndex = 0;
            }
            walkWhatPartFromStationCalBox.Text = calBox.Text;
            calBox.Clear();
            formulaBox.Clear();
        }
        private void walkWhatPartFromStationResultCalButtonCliked(object sender, EventArgs e)
        {
            if (walkWhatPartFromStationResultBox.Text == "")
            {
                tabControl1.SelectedIndex = 0;
            }
            walkWhatPartFromStationResultBox.Text = calBox.Text;
            calBox.Clear();
            formulaBox.Clear();
        }

        private void WalkWhatPartFromStationResultButtonClicked(object sender, EventArgs e)
        {
            Factory.WalkWhatPartFromStationCal(tabControl1, walkWhatPartFromStationResultButton, walkWhatPartFromStationLnverseResultButton, walkWhatPartFromStationCalBox, walkWhatPartFromStationResultBox, allCalBox, sender);
        }

        private void WalkWhatPartFromStationReverseResultButtonClicked(object sender, EventArgs e)
        {
            Factory.WalkWhatPartFromStationCal(tabControl1, walkWhatPartFromStationResultButton, walkWhatPartFromStationLnverseResultButton, walkWhatPartFromStationCalBox, walkWhatPartFromStationResultBox, allCalBox, sender);
        }

        private void ClearTextButtonChecked(object sender, EventArgs e)
        {
            allCalBox.Clear();
        }
    }
}
