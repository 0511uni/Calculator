using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Calculator_1
{
    internal class Factory
    {
        internal static void DataCreate(TextBox allCalBox, ToolStripMenuItem saveMenu, ToolStripMenuItem loadMenu, object sender)
        {
            if (sender.Equals(saveMenu))
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
            else if (sender.Equals(loadMenu))
            {
                FileCreateFactory.FileLoad(allCalBox);
            }

        }

        internal static void DataSaveAndLoad(TextBox allCalBox, ToolStripMenuItem saveItem, ToolStripMenuItem loadItem, object sender)
        {
            if (sender.Equals(saveItem))
            {
                DataCreateFactory.DataSave(allCalBox);
            }
            else if (sender.Equals(loadItem))
            {
                DataCreateFactory.DataLoad(allCalBox);
            }
        }


        internal static void BmiCreate(TabControl tabControl1, TextBox allCalBox, TextBox heightBox, TextBox weightBox, TextBox bmiBox)
        {

            WeightCreateFactory.BmiCalCreate(tabControl1, allCalBox, heightBox, weightBox, bmiBox);
        }

        internal static void BaseWeightCreata(TabControl tabControl1, TextBox allCalBox, TextBox heightBox, TextBox weightBox, TextBox baseWeightBox)
        {
            WeightCreateFactory.BaseWeightCalCreate(tabControl1, allCalBox, heightBox, weightBox, baseWeightBox);
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

        internal static void HourlyWageCal(TabControl tabControl1, Button hourlyWageResultButton, Button hourlyWageReverseResultButton, TextBox annualIncomeBox, TextBox hourlyWageResultBox, TextBox allCalBox, object sender)
        {
            ToolCreateCalFactory.HourlyWageCal(tabControl1, hourlyWageResultButton, hourlyWageReverseResultButton, allCalBox, annualIncomeBox, hourlyWageResultBox, sender);
        }

        internal static void WalkWhatPartFromStationCal(TabControl tabControl1, Button walkWhatPartFromStationResultButton, Button walkWhatPartFromStationLnverseResultButton, TextBox walkWhatPartFromStationCalBox, TextBox walkWhatPartFromStationResultBox, TextBox allCalBox, object sender)
        {
            ToolCreateCalFactory.WalkWhatPartFromStationCal(tabControl1, walkWhatPartFromStationResultButton, walkWhatPartFromStationLnverseResultButton, walkWhatPartFromStationCalBox, walkWhatPartFromStationResultBox, allCalBox, sender);
        }

        internal static void YesrsOldCreata(TabControl tabControl1, TextBox yearBox, TextBox manthBox, TextBox dayBox, TextBox yearsOldBox, TextBox allCalBox, object sender, object yearsOldResultButton, object yearsOldCaiBoxButton, TextBox calBox, TextBox formulaBox)
        {
            if (sender.Equals(yearsOldCaiBoxButton))
            {
                DateTimeCreateFactory.YearsOldCalCreatar(tabControl1, yearBox, manthBox, dayBox, yearsOldBox, allCalBox, calBox, formulaBox);
            }
            else if (sender.Equals(yearsOldResultButton))
            {
                DateTimeCreateFactory.YearsOldCreatar(tabControl1, yearBox, manthBox, dayBox, yearsOldBox, allCalBox);
            }
        }
    }
}