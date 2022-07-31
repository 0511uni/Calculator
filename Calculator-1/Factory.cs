using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Calculator_1
{
    internal class Factory
    {
        internal static void DataCreate(TextBox allCalBox)
        {
            ShowMessage(allCalBox);
        }

        private static void ShowMessage(TextBox allCalBox)
        {//, bool saveMenu , MenuStrip saveMenu, MenuStrip lordMenu
            var result = MessageBox.Show("ファイル作りますか？！", "ファイル生成", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                FileCreateFactory.FileSaveDialog(allCalBox);
                #region
                //if (saveMenu.Enabled)
                //{

                //}
                //else if (lordMenu.Enabled)
                //{

                //}

                //if (inputBox.Text == "4")
                //{
                //    BulkyGarbage.BulkyGarbageReservationFileData();
                //    BulkyGarbage.BulkyGarbageReservationResult(fileCreatingResultDisplay);
                //}
                //else if (inputBox.Text == "5")
                //{
                //    ListTable.GarbageCollectionTableResult(fileCreatingResultDisplay);
                //    ListTable.GarbageCollectionTableFileData();
                //}
                //htmlFileButton.Enabled = false;
                #endregion
            }
        }

        internal static void DataCreateLoad(TextBox allCalBox)
        {
            ShowMessageLoad(allCalBox);
        }

        private static void ShowMessageLoad(TextBox allCalBox)
        {
            var result = MessageBox.Show("ファイル読み込みますか？！", "ファイル読込", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                FileCreateFactory.FileLoad(allCalBox);
            }
        }

        internal static void BmiCreate(TabControl tabControl1, TextBox allCalBox, TextBox heightBox, TextBox weightBox, TextBox bmiBox)
        {

            WeightCreateFactory.BmiCalCreate(tabControl1,allCalBox, heightBox, weightBox, bmiBox);
        }

        internal static void BaseWeightCreata(TabControl tabControl1, TextBox allCalBox, TextBox heightBox, TextBox weightBox, TextBox baseWeightBox)
        {
            WeightCreateFactory.BaseWeightCalCreate(tabControl1,allCalBox, heightBox, weightBox, baseWeightBox);
        }

        internal static void BmiAndBaseWeightCreata(TabControl tabControl1, TextBox allCalBox, TextBox heightBox, TextBox weightBox, TextBox baseWeightBox, TextBox bmiBox)
        {
            if (heightBox.Text == "")
            {
                tabControl1.SelectedIndex = 0;
            }
            else if (weightBox.Text == "")
            {
                WeightCreateFactory.BaseWeightCalCreate(tabControl1, allCalBox, heightBox, weightBox, baseWeightBox);
            }
            else
            {
                WeightCreateFactory.BmiCalCreate(tabControl1, allCalBox, heightBox, weightBox, bmiBox);
                WeightCreateFactory.BaseWeightCalCreate(tabControl1, allCalBox, heightBox, weightBox, baseWeightBox);
            }
        }

        internal static void DataLoad(TextBox allCalBox)
        {
            DataCreateFactory.DataLoad(allCalBox);
        }

        internal static void DataSave(TextBox allCalBox)
        {
            DataCreateFactory.DataSave(allCalBox);
        }

        internal static void HourlyWageCal(TabControl tabControl1, Button hourlyWageResultButton, Button hourlyWageReverseResultButton, TextBox annualIncomeBox, TextBox hourlyWageResultBox, TextBox allCalBox, object sender)
        {
            ToolCreateCalFactory.HourlyWageCal(tabControl1,hourlyWageResultButton, hourlyWageReverseResultButton, allCalBox, annualIncomeBox, hourlyWageResultBox, sender);
        }

        internal static void WalkWhatPartFromStationCal(TabControl tabControl1, Button walkWhatPartFromStationResultButton, Button walkWhatPartFromStationLnverseResultButton, TextBox walkWhatPartFromStationCalBox, TextBox walkWhatPartFromStationResultBox, TextBox allCalBox, object sender)
        {
            ToolCreateCalFactory.WalkWhatPartFromStationCal(tabControl1,walkWhatPartFromStationResultButton,walkWhatPartFromStationLnverseResultButton,walkWhatPartFromStationCalBox, walkWhatPartFromStationResultBox, allCalBox, sender);
        }
    }
}