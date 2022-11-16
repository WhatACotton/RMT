using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace rndtimer
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //変数宣言
        string SelectedFile = "";//選択したファイル名
        int start;//ストップ時間の下限
        int end;//ストップ時間の上限
        int duration = 0;//ユーザー決める上限

        //音楽の再生
        private void PlayMusic(string filenames)
        {
            //tickの有効化
            timer1.Enabled = true;

            //ファイルの再生
            Microsoft.SmallBasic.Library.Sound.Play(filenames);

            //コントロールの無効化
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            trackBar1.Enabled = false;

            //再生ボタンの有効化
            button1.Enabled = false;

            //停止ボタンの有効化
            button4.Enabled = true;

            //選択ボタンの無効化
            button2.Enabled = false;

            //ステータス表示
            toolStripStatusLabel1.Text = "再生中！";

            //ストップさせる時間の乱数生成;
            timer1.Interval = Choosingtime();

        }

        //音楽の停止
        private void StopMusic(string filenames)
        {
            //tickの無効化
            timer1.Enabled = false;

            //音楽の停止
            Microsoft.SmallBasic.Library.Sound.Stop(filenames);

            //コントロールの有効化
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            trackBar1.Enabled = true;

            //再生ボタンの有効化
            button1.Enabled = true;

            //選択ボタンの有効化
            button2.Enabled = true;

            //停止ボタンの無効化
            button4.Enabled = false;

            //ステータス表示
            toolStripStatusLabel1.Text = "停止しました";

        }

        //ストップさせる時間の乱数生成
        public int Choosingtime()
        {
            //numericUpDown1.Value,numericUpDown2.Valueがdouble型なのでキャスト
            start = (int)numericUpDown1.Value;
            end = (int)numericUpDown2.Value;

            //乱数生成
            Random rnd = new Random();

            return rnd.Next(start, end) * 1000;
        }

        //範囲チェック
        private void RangeCheck()
        {
            //上限と下限のチェック
            //不適の時
            if (numericUpDown1.Value > numericUpDown2.Value)
            {
                textBox2.Text = "終了時刻と開始時刻が不正です";
                button1.Enabled = false;

            }
            //適の時
            else
            {
                textBox2.Text = "";
                button1.Enabled = true;
            }
        }

        //ファイル選択
        private string FileSelectSetting()
        {
            string fname = "";
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog
            {
                //はじめに表示されるフォルダを指定する
                //指定しない（空の文字列）の時は、現在のディレクトリが表示される
                InitialDirectory = @"C:\music",
                //[ファイルの種類]に表示される選択肢を指定する
                //指定しないとすべてのファイルが表示される
                Filter = "音楽ファイル(*.mp3;*.wav)|*.mp3;*.wav",
                //[ファイルの種類]ではじめに選択されるものを指定する
                //タイトルを設定する
                Title = "開くファイルを選択してください",
                //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
                RestoreDirectory = true,
                //存在しないファイルの名前が指定されたとき警告を表示する
                //デフォルトでTrueなので指定する必要はない
                CheckFileExists = true,
                //存在しないパスが指定されたとき警告を表示する
                //デフォルトでTrueなので指定する必要はない
                CheckPathExists = true
            };
            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                SelectedFile = ofd.FileName;//選択したファイルの設定
                GetFileInfo(SelectedFile);
                SetDefault();
            }
            else
            {
                textBox1.Text = "ファイルが選択されていません";
                SelectedFile = "";
                //再生ボタンの無効化
                button1.Enabled = false;
            }
            ofd.Dispose();
            return fname;
        }

        //ファイル選択ごとにデフォルトに戻す
        private void SetDefault()
        {
            //上限の設定
            if (duration >= 10)
            {
                numericUpDown2.Value = 10;
            }
            else
            {
                numericUpDown2.Value = duration;
            }

            //下限のリセット
            numericUpDown1.Value = 5;

            //コントロールの有効化
            trackBar1.Enabled = true;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;

            RangeCheck();
        }

        //選択した曲の情報取得
        private void GetFileInfo(string fname)
        {
            textBox1.Text = SelectedFile;//選択したファイルの表示

            //選択したファイルの情報抽出ターゲット
            TagLib.File file = TagLib.File.Create(fname);

            //曲の長さ(秒)の取得
            duration = file.Properties.Duration.Seconds + file.Properties.Duration.Minutes * 60;

            //選択したファイルの表示
            textBox1.Text = Path.GetFileName(fname);

            //上・下限の設定
            trackBar1.Maximum = duration;
            numericUpDown2.Maximum = duration;
            if (duration == 0)
            {
                //メッセージボックスを表示する
                MessageBox.Show("長さが1秒以上の曲を選んでください",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                SelectedFile = "";
                textBox1.Text = "ファイルが選択されていません";


            }
            else
            {
                numericUpDown1.Maximum = duration;
            }
        }

        //再生ボタン
        private void button1_Click(object sender, EventArgs e)
        {
            if (SelectedFile == "") //ファイルが選択されてない時
            {
                textBox1.Text = "ファイルが選択されていません";
            }
            else
            {
                PlayMusic(SelectedFile);
            }

        }

        //停止ボタン
        private void button4_Click(object sender, EventArgs e)
        {
            StopMusic(SelectedFile);
        }

        //制限時間後
        private void timer1_Tick(object sender, EventArgs e)
        {
            StopMusic(SelectedFile);
        }

        //選択ボタン
        private void button2_Click(object sender, EventArgs e)
        {
            SelectedFile = FileSelectSetting();
        }

        //上限の設定
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            //トラックバーとの同期
            if(trackBar1.Value < trackBar1.Maximum)
            {
                trackBar1.Value = (int)numericUpDown2.Value;
            }

            RangeCheck();
        }

        //下限の設定
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            RangeCheck();
        }

        //トラックバー
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //数字変更との同期
            numericUpDown2.Value = trackBar1.Value;
        }

        private void ヘルプを表示するToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ヘルプを表示するToolStripMenuItem.Checked == false)
            {
                toolTip1.Active = false;
            }
            else
            {
                toolTip1.Active = true;
            }
        }

        private void 終了するToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // アプリケーションを終了する
            Application.Exit();
        }

        private void readmeを開くToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string folderPath = Directory.GetCurrentDirectory();
            Process.Start(folderPath+@"\readme.txt"); // 指定したフォルダを開く
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
      
    }
}
