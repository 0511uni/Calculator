using System;
using System.Data;
using System.Windows.Forms;

namespace Calculator_1
{
    internal class ToolCreateCalFactory
    {
        internal static void HourlyWageCal(Button hourlyWageResultButton, Button hourlyWageReverseResultButton, TextBox allCalBox, TextBox annualIncomeBox, TextBox hourlyWageResultBox, object sender)
        {
            if (sender.Equals(hourlyWageResultButton))
            {
                //年収800万円の場合 、8000000 ÷ 2000 = 4000
                string annualIncome = annualIncomeBox.Text;

                string hourlyWageResult = annualIncome + "0000 / 2000";

                DataTable dt = new DataTable();
                var result = dt.Compute(hourlyWageResult, "");

                hourlyWageResultBox.Text = result.ToString();
                allCalBox.Text += $"-------------------\r\n" +
                    $"♦ 年収で時給 ♦\r\n" +
                    $"年収:{annualIncomeBox.Text}万円 \r\n" +
                    $"　↓ \r\n" +
                    $"時給:" + result.ToString() + "円\r\n";
            }
            else if (sender.Equals(hourlyWageReverseResultButton))
            {
                string hourlyWage = hourlyWageResultBox.Text;

                string annualIncomeResult = hourlyWage + " * 2000";

                DataTable dt = new DataTable();
                var result = dt.Compute(annualIncomeResult, "");

                annualIncomeBox.Text = result.ToString().Replace("0000", "");
                allCalBox.Text += $"-------------------\r\n" +
                    $"♦ 時給で年収 ♦\r\n" +
                    $"時給:{hourlyWageResultBox.Text}円\r\n" +
                    $"　↓ \r\n" +
                    $"年収:" + result.ToString().Replace("0000", "") + "万円 \r\n";
            }              
        }

        internal static void WalkWhatPartFromStationCal(Button walkWhatPartFromStationResultButton, Button walkWhatPartFromStationReverseResultButton, TextBox walkWhatPartFromStationCalBox, TextBox walkWhatPartFromStationResultBox, TextBox allCalBox, object sender)
        {
            // https://kk-1984.hatenablog.com/entry/20100816/1281973896
            if (sender.Equals(walkWhatPartFromStationResultButton))
            {
                //「駅から徒歩12分」の場合、80 × 12 = 960（m）
                string walkWhatPartFromStation = walkWhatPartFromStationCalBox.Text;

                string walkWhatPartFromStationResult = walkWhatPartFromStation + " / 80";

                DataTable dt = new DataTable();
                var result = dt.Compute(walkWhatPartFromStationResult, "");

                walkWhatPartFromStationResultBox.Text = result.ToString();
                allCalBox.Text += $"-------------------\r\n" +
                    $"♦ 駅からの距離 ♦\r\n" +
                    $"距離 :{walkWhatPartFromStationCalBox.Text}ｍ \r\n" +
                    $"　↓ \r\n" +
                    $"徒歩 :" + result.ToString() + "分\r\n";
            }
            else if(sender.Equals(walkWhatPartFromStationReverseResultButton))
            {
                string walkWhatPartFromStation = walkWhatPartFromStationResultBox.Text;

                string walkWhatPartFromStationResult = walkWhatPartFromStation + " * 80";

                DataTable dt = new DataTable();
                var result = dt.Compute(walkWhatPartFromStationResult, "");

                walkWhatPartFromStationCalBox.Text = result.ToString();
                allCalBox.Text += $"-------------------\r\n" +
                    $"♦ 駅からの距離 ♦\r\n" +
                    $"徒歩 :{walkWhatPartFromStationResultBox.Text}分 \r\n" +
                    $"　↓ \r\n" +
                    $"距離 :" + result.ToString() + "ｍ\r\n";
            }
            
        }
    }
}