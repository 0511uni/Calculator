using System;
using System.Windows.Forms;

namespace Calculator_1
{
    internal class DateTimeCreateFactory
    {
        internal static void YearsOldCreatar(TabControl tabControl1, TextBox yearBox, TextBox manthBox, TextBox dayBox, TextBox yearsOldBox, TextBox allCalBox)
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

        private static object GetAge(DateTime birthday, DateTime targetDay)
        {
            var age = targetDay.Year - birthday.Year;
            if (targetDay < birthday.AddYears(age))
            {
                age--;
            }
            return age;
        }

        internal static void YearsOldCalCreatar(TabControl tabControl1, TextBox yearBox, TextBox manthBox, TextBox dayBox, TextBox yearsOldBox, TextBox allCalBox, TextBox calBox, TextBox formulaBox)
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