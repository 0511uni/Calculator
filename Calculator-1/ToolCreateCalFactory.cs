﻿using System;
using System.Data;
using System.Windows.Forms;

namespace Calculator_1
{
    internal class ToolCreateCalFactory
    {
        internal static void HourlyWageCal(TabControl tabControl1, Button hourlyWageResultButton, Button hourlyWageReverseResultButton, TextBox allCalBox, TextBox annualIncomeBox, TextBox hourlyWageResultBox, object sender)
        {
            if (sender.Equals(hourlyWageResultButton))
            {
                if (annualIncomeBox.Text == "")
                {
                    tabControl1.SelectedIndex = 0;
                }
                else
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
            }
            else if (sender.Equals(hourlyWageReverseResultButton))
            {
                if (hourlyWageResultBox.Text == "")
                {
                    tabControl1.SelectedIndex = 0;
                }
                else
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
        }

        internal static void WalkWhatPartFromStationCal(TabControl tabControl1, Button walkWhatPartFromStationResultButton, Button walkWhatPartFromStationReverseResultButton, TextBox walkWhatPartFromStationCalBox, TextBox walkWhatPartFromStationResultBox, TextBox allCalBox, object sender)
        {
            // https://kk-1984.hatenablog.com/entry/20100816/1281973896
            if (sender.Equals(walkWhatPartFromStationResultButton))
            {
                if (walkWhatPartFromStationCalBox.Text == "")
                {
                    tabControl1.SelectedIndex = 0;
                }
                else
                {
                    //「駅から徒歩12分」の場合、80 × 12 = 960（m）
                    string walkWhatPartFromStation = walkWhatPartFromStationCalBox.Text;

                    string walkWhatPartFromStationResult = walkWhatPartFromStation + " / 80";

                    DataTable dt = new DataTable();
                    var result = dt.Compute(walkWhatPartFromStationResult, "").ToString();

                    var answer = Math.Floor(decimal.Parse(result));
                 
                    walkWhatPartFromStationResultBox.Text = answer.ToString();
                    allCalBox.Text += $"-------------------\r\n" +
                        $"♦ 駅からの距離 ♦\r\n" +
                        $"距離 :{walkWhatPartFromStationCalBox.Text}ｍ \r\n" +
                        $"　↓ \r\n" +
                        $"徒歩 :" + Math.Floor(float.Parse(result.ToString())) + "分\r\n";
                }
            }
            else if (sender.Equals(walkWhatPartFromStationReverseResultButton))
            {
                if (walkWhatPartFromStationResultBox.Text == "")
                {
                    tabControl1.SelectedIndex = 0;
                }
                else
                {
                    string walkWhatPartFromStation = walkWhatPartFromStationResultBox.Text;

                    string walkWhatPartFromStationResult = walkWhatPartFromStation + " * 80";

                    DataTable dt = new DataTable();
                    var result = dt.Compute(walkWhatPartFromStationResult, "");

                    if (walkWhatPartFromStationResult.Contains("."))
                    {
                        walkWhatPartFromStationCalBox.Text = Math.Floor((decimal)result).ToString();
                        allCalBox.Text += $"-------------------\r\n" +
                            $"♦ 駅からの距離 ♦\r\n" +
                            $"徒歩 :{walkWhatPartFromStationResultBox.Text}分 \r\n" +
                            $"　↓ \r\n" +
                            $"距離 :" + Math.Floor((decimal)result).ToString() + "ｍ\r\n";
                    }
                    else
                    {
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
    }
}