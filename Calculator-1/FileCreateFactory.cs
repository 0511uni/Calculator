using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Calculator_1
{
    internal class FileCreateFactory
    {
        internal static void FileSaveDialog(TextBox temps)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.FileName = "新しい計算ファイル.txt";

            sfd.Filter = "テキスト文書(*.txt)|*.txt|リッチテキスト形式文書(*.rtf)|*.rtf|すべてのファイル(*.*)|*.*";
            
            sfd.FilterIndex = 1;


            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, temps.Text, Encoding.UTF8);//"https://dobon.net"
            }

            #region 既存のFileに保存の場合
            /*
            
            OpenFileDialog ofd = new OpenFileDialog();


            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string temp = temps.Text;
                File.WriteAllText(ofd.FileName, temp, Encoding.UTF8);
            }
            */
            #endregion
        }


        internal static void FileSave(TextBox temps)
        {
            //デスクトップに保存
            string directoryName = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            DirectoryInfo di = new DirectoryInfo($@"{directoryName}");
            di.Create();
            object tempTitle = "計算式";
            string fileName = $"{tempTitle}.txt";

            string temp = temps.Text;
            File.WriteAllText($@"{directoryName}\{fileName}", temp, Encoding.UTF8);
        }

        internal static void FileLoad(TextBox temps)
        {
            OpenFileDialog ofd = new OpenFileDialog();


            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、選択されたファイルを読み取り専用で開く
                Stream stream = ofd.OpenFile();

                if (stream != null)
                {
                    ////内容を読み込み、表示する
                    using (var sr = new StreamReader(stream))
                    {
                        temps.Text = sr.ReadToEnd();

                        //閉じる
                        sr.Close();
                    }

                    stream.Close();
                }
            }

            #region デスクトップ指定で読み込みの場合
            //string directoryName = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            //string fileName = "計算式";
            //string dataPrograms = File.ReadAllText($@"{directoryName}\{fileName}.txt");
            //temps.Text = dataPrograms.ToString();
            #endregion
        }
    }
}