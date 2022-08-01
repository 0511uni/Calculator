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
        string basicArithmeticOperations = "＋－";

        public Calculator()
        {
            InitializeComponent();
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        bool once;
        bool oncek;

        private void NumberButtonClicked(object sender, EventArgs e)
        {
            //記号キーのonce
            oncek = false;
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
                calBox.Clear();
                formulaBox.Clear();
            }
            else if (formuraData == "" && sender.Equals(button00))
            {
                return;
            }

            string number = (sender as Button).Text;
            calBox.Text += number;
            formulaBox.Text += number;

            #region  Enabledで制御する場合の方法(記号キーの受け渡し)
            //addButton.Enabled = true;
            //subtractButton.Enabled = true;
            //multiplyButton.Enabled = true;
            //divideButton.Enabled = true;
            #endregion
        }

        private void AnswerButton_Clicked(object sender, EventArgs e)
        {
            if (formulaBox.Text.Contains("="))
            {
                return;
            }
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


        #region


        //private void FormulaBoxClear(object sender, TextBox formulaBox, TextBox calBox, Button answerButton)
        //{
        //    if (sender.Equals(answerButton))
        //    {
        //        formulaBox.Text = "";
        //        formulaBox.Text = calBox.Text;
        //    }
        //}
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
            if (formulaBox.Text == "")
            {
                return;
            }
            else if (formulaBox.Text.Contains("=") || formulaBox.Text.Contains("税"))
            {
                formulaBox.Text = calBox.Text;
                basicArithmeticOperations = (sender as Button).Text;
                formulaBox.Text += basicArithmeticOperations;
                oncek = true;
                once = false;
            }
            else if (!oncek)
            {              
                basicArithmeticOperations = (sender as Button).Text;
                formulaBox.Text += basicArithmeticOperations;
                oncek = true;
                once = false;
            }

            #region  Enabledで制御する場合の方法
            //once = false;
            //addButton.Enabled = false;
            //addButton.BackColor = Color.WhiteSmoke;
            //addButton.ForeColor = SystemColors.ControlText;
            //subtractButton.Enabled = false;
            //subtractButton.BackColor = Color.WhiteSmoke;
            //subtractButton.ForeColor = SystemColors.ControlText;
            //multiplyButton.Enabled = false;
            //multiplyButton.BackColor = Color.WhiteSmoke;
            //multiplyButton.ForeColor = Color.Black;
            //divideButton.Enabled = false;
            //divideButton.BackColor = Color.WhiteSmoke;
            //divideButton.ForeColor = Color.Black;


            //if (sender.Equals(addButton) ||
            //    sender.Equals(subtractButton) ||
            //    sender.Equals(multiplyButton) ||
            //    sender.Equals(divideButton))
            //{
            //    return;
            //}
            #endregion
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

        private void NoTaxButtonClicked(object sender, EventArgs e)
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

        private void DecimalPointButtonClicked(object sender, EventArgs e)
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
            Factory.BmiCreate(tabControl1, allCalBox, heightBox, weightBox, bmiBox);
        }

        private void BaseWeightButtonClicked(object sender, EventArgs e)
        {
            Factory.BaseWeightCreata(tabControl1, allCalBox, heightBox, weightBox, baseWeightBox);
        }

        private void CalHeigthtButtonClicked(object sender, EventArgs e)
        {
            if (calBox.Text == "")
            {
                tabControl1.SelectedIndex = 0;
            }

            heightBox.Text = calBox.Text;
            calBox.Clear();
            formulaBox.Clear();
        }

        private void CalWeigthtButtonClicked(object sender, EventArgs e)
        {
            if (calBox.Text == "")
            {
                tabControl1.SelectedIndex = 0;
            }

            weightBox.Text = calBox.Text;
            calBox.Clear();
            formulaBox.Clear();
        }

        private void BmiAndBaseWeightResultButtonClicked(object sender, EventArgs e)
        {
            Factory.BmiAndBaseWeightCreata(tabControl1, allCalBox, heightBox, weightBox, baseWeightBox, bmiBox);
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
            if (calBox.Text == "")
            {
                tabControl1.SelectedIndex = 0;
            }
            annualIncomeBox.Text = calBox.Text;
            calBox.Clear();
            formulaBox.Clear();
        }

        private void HourlyWageCalButtonClicked(object sender, EventArgs e)
        {
            if (calBox.Text == "")
            {
                tabControl1.SelectedIndex = 0;
            }
            hourlyWageResultBox.Text = calBox.Text;
            calBox.Clear();
            formulaBox.Clear();
        }

        private void HourlyWageResultButtonClicked(object sender, EventArgs e)
        {
            Factory.HourlyWageCal(tabControl1, hourlyWageResultButton, hourlyWageReverseResultButton, annualIncomeBox, hourlyWageResultBox, allCalBox, sender);
        }

        private void HourlyWageReverseResultButtonClicked(object sender, EventArgs e)
        {
            Factory.HourlyWageCal(tabControl1, hourlyWageResultButton, hourlyWageReverseResultButton, annualIncomeBox, hourlyWageResultBox, allCalBox, sender);
        }

        private void WalkWhatPartFromStationCalButtonClicked(object sender, EventArgs e)
        {
            if (calBox.Text == "")
            {
                tabControl1.SelectedIndex = 0;
            }

            walkWhatPartFromStationCalBox.Text = calBox.Text;
            calBox.Clear();
            formulaBox.Clear();
        }
        private void WalkWhatPartFromStationResultCalButtonCliked(object sender, EventArgs e)
        {
            if (calBox.Text == "")
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

        private void BackSpaceButtonClicked(object sender, EventArgs e)
        {
            if (formulaBox.Text == "")
            {
                return;
            }
            else
            {
                formulaBox.Text = formulaBox.Text.Substring(0, formulaBox.Text.Length - 1).Trim();
            }
        }

        private void YearsOldResultButtonClicked(object sender, EventArgs e)
        {
            if (yearBox.Text == "" || manthBox.Text == "" || dayBox.Text == "")
            {
                tabControl1.SelectedIndex = 0;
            }
            else
            {
                var year = int.Parse(yearBox.Text);
                var manth = int.Parse(manthBox.Text);
                var day = int.Parse(dayBox.Text);
                var birthday = new DateTime(year, manth, day);
                var today = DateTime.Today;
                var age = GetAge(birthday, today);
                yearsOldBox.Text = age.ToString();
                allCalBox.Text += $"-------------------\r\n" +
                    $"{yearBox.Text}年{manthBox.Text}月{dayBox.Text}日" +
                    $" 生まれ\r\n" +
                    $"　　↓\r\n" +
                    $"　　{yearsOldBox.Text}歳\r\n";
            }
        }

        static int GetAge(DateTime birthday, DateTime targetDay)
        {
            var age = targetDay.Year - birthday.Year;
            if (targetDay < birthday.AddYears(age))
            {
                age--;
            }
            return age;
        }

        private void YearsOldCaiBoxButtonClieked(object sender, EventArgs e)
        {
            if (calBox.Text == "")
            {
                tabControl1.SelectedIndex = 0;
            }
            else if (yearBox.Text == "")
            {
                yearBox.Text = calBox.Text;
                calBox.Clear();
                formulaBox.Clear();
            }
            else if (manthBox.Text == "")
            {
                manthBox.Text = calBox.Text;
                calBox.Clear();
                formulaBox.Clear();
            }
            else if (dayBox.Text == "")
            {
                dayBox.Text = calBox.Text;
                formulaBox.Clear();
            }
            else if (yearsOldBox.Text == "")
            {
                return;
            }
            else
            {
                tabControl1.SelectedIndex = 0;
                calBox.Clear();
                yearBox.Clear();
                manthBox.Clear();
                dayBox.Clear();
                yearsOldBox.Clear();
            }
        }
    }
}
