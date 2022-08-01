using System;
using System.Data;
using System.Windows.Forms;

namespace Calculator_1
{
    internal class WeightCreateFactory
    {
        internal static void BmiCalCreate(TabControl tabControl1, TextBox allCalBox, TextBox heightBox, TextBox weightBox, TextBox bmiBox)
        {
            if (heightBox.Text == "" && weightBox.Text == "" ||
                heightBox.Text == "" ||
                weightBox.Text == "")
            {
                tabControl1.SelectedIndex = 0;
            }
            else
            {
                string height = heightBox.Text;

                height += "/ 100.0";

                string weight = weightBox.Text;

                string bmi = weight + "/(" + height + "*" + height + ")";

                DataTable dt = new DataTable();
                var result = dt.Compute(bmi, "");

                //bmiBox.Text = ($"{0.00}", (decimal)result).ToString();
                bmiBox.Text = $"{(decimal)result:0.00}";

                allCalBox.Text += $"-------------------\r\n" +
                    $"♦ BMI ♦\r\n" +
                    $"Height: {heightBox.Text}cm\r\n" +
                    $"Weight: {weightBox.Text}kg\r\n" +
                    $"　↓\r\n" +
                    $"BMI : {(decimal)result:0.00}\r\n";
                #region 計算式一覧
                //　(heightBox /heightBox)/weightBox
                //double bmiCreate = Math.Floor(Math.Round(weightBox / Math.Pow(heightBox /100,2) * 100));
                #endregion
            }
        }

        internal static void BaseWeightCalCreate(TabControl tabControl1, TextBox allCalBox, TextBox heightBox, TextBox weightBox, TextBox baseWeightBox)
        {
            if (heightBox.Text == "" || heightBox.Text == "" && weightBox.Text == "")
            {
                tabControl1.SelectedIndex = 0;
            }
            else
            {
                string height = heightBox.Text;

                height += "/ 100.0";

                string heightCal = height + "*" + height;

                string calBase = "22*" + heightCal + "* 100";

                DataTable dt1 = new DataTable();
                var result1 = dt1.Compute(calBase, "");

                string baseWeight = calBase + "/ 100";

                DataTable dt2 = new DataTable();
                var result2 = dt2.Compute(baseWeight, "");

                //標準体重 Math.Floor(Math.Round(22 *Math.Pow(heightBox /100,2) * 100)/100);
                baseWeightBox.Text = $"{(decimal)result2:0.00}";

                allCalBox.Text += $"-------------------\r\n" +
                    $"♦ BaseWeight ♦\r\n" +
                    $"Height: {heightBox.Text} cm\r\n" +
                    $"　↓\r\n" +
                    $"BaseWeight : {(decimal)result2:0.00} Kg\r\n";
            }
        }
    }
}