using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Calculator_1
{
    internal class DataCreateFactory
    {
        internal static void DataLoad(TextBox temps)
        {
            var result = MessageBox.Show("データを読み込みますか？！", "データ読込", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                string fileName = "計算式";
                string dataPrograms = File.ReadAllText($@"{fileName}.txt");
                temps.Text = dataPrograms;
            }
        }

        internal static void DataSave(TextBox temps)
        {
            var result = MessageBox.Show("データセーブしますか？！", "データセーブ", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                object tempTitle = "計算式";
                string fileName = $"{tempTitle}.txt";

                string temp = temps.Text;
                File.WriteAllText($@"{fileName}", temp, Encoding.UTF8);
            }
        }
    }
}