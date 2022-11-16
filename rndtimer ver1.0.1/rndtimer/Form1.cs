using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace rndtimer
{

    public partial class Form1 : Form
    {
        /// <errorcode>
        /// 01:長さが0秒の曲が選択された
        /// 02:開始時刻と終了時刻が不整合
        /// 03:単一ファイル選択でキャンセル
        /// 04:ファイル未選択で再生
        /// 05:m3uファイル選択でキャンセル
        /// 06:追加行が未選択
        /// 07:表がからなのに保存
        /// </errorcode>
        #region<rndmusictimer本体>
        //変数宣言
        string SelectedMusicFile = null;//選択したファイル名
        int start;//ストップ時間の下限
        int end;//ストップ時間の上限
        string folderPath = Directory.GetCurrentDirectory();//ディレクトリの取得
        public Form1()
        {
            InitializeComponent();
            //初期化処理
            //上限・下限の設定
            numericUpDown1.Minimum = 1;
            numericUpDown2.Minimum = 1;
            trackBar1.Minimum = 1;
            trackBar2.Minimum = 1;
            numericUpDown1.Value = 1;
            numericUpDown2.Value = 1;
            //datagridviewの表の設定
            dataGridView1.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Silver;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Black;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

       
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
            trackBar2.Enabled = false;
            //再生ボタンの無効化
            button1.Enabled = false;
            //停止ボタンの有効化
            button4.Enabled = true;
            //選択ボタンの無効化
            button2.Enabled = false;
            //ステータス表示
            toolStripStatusLabel1.Text = "再生中！";
            //ストップさせる時間の乱数生成;
            timer1.Interval = Choosingtime();
            //datagridviewの無効化
            dataGridView1.Enabled = false;
            //編集の無効化
            UnableEditPLAY();
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
            trackBar2.Enabled = true;
            //再生ボタンの有効化
            button1.Enabled = true;
            //選択ボタンの有効化
            button2.Enabled = true;
            //停止ボタンの無効化
            button4.Enabled = false;
            //ステータス表示
            toolStripStatusLabel1.Text = "停止しました";
            //datagridviewの有効化
            dataGridView1.Enabled = true;
            //編集機能の有効化
            EnabledEditPLAY();
        }

        //コントロールの有効化・無効化(音楽の再生・停止用)
        private void EnabledEditPLAY()
        {
            if (Selectedm3uFile != null)
            {
                //リスト1行削除ボタン
                button6.Enabled = true;
                //保存ボタン
                button7.Enabled = true;
                //名前を付けて保存ボタン
                button8.Enabled = true;
                //曲追加ボタン
                button9.Enabled = true;
                //クリアボタン
                button10.Enabled = true;
                //プレイリスト追加ボタン
                button11.Enabled = true;
                //ランダムボタン
                button13.Enabled = true;
            }
           

        }
        private void UnableEditPLAY()
        {
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            button12.Enabled = false;
            button13.Enabled = false;
        }

        //ストップさせる時間の乱数生成
        public int Choosingtime()
        {
            //numericUpDown1.Value,numericUpDown2.Valueがdouble型なのでキャスト
            start = (int)numericUpDown1.Value;
            end = (int)numericUpDown2.Value;
            //乱数生成
            Random rnd = new Random();
            //ミリ秒から変換
            return rnd.Next(start, end) * 1000;
        }

        //範囲チェック
        private void RangeCheck()
        {
            //上限と下限のチェック
            //不適の時
            if (numericUpDown1.Value > numericUpDown2.Value)
            {
                toolStripStatusLabel1.Text = "終了時刻と開始時刻が不正です code:02";
                //再生ボタンの無効化
                button1.Enabled = false;
            }
            //適の時
            else
            {
                toolStripStatusLabel1.Text = "";
                //再生ボタンの有効化
                button1.Enabled = true;
            }
        }
        private void SetMusic()
        {
            CheckSetDuration();
            //選択したファイルの表示(拡張子なし)
            textBox1.Text = Path.GetFileNameWithoutExtension(SelectedMusicFile);
        }
        //ファイル選択
        private string MusicFileSelectSetting()
        {
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
                SelectedMusicFile = ofd.FileName;//選択したファイルの設定
                SetMusic();
            }
            else
            {
                if (SelectedMusicFile == null)
                {
                    toolStripStatusLabel1.Text = "ファイルが選択されていません code:03";
                    //再生ボタンの無効化
                    button1.Enabled = false;
                }
                
            }
            ofd.Dispose();
            return SelectedMusicFile;
        }
        /*checksetduration 
         * 
         * ・GetFileDuration(string型)
         *   選択した曲の情報取得
         *   
         * ・SetDefault(int型)
         *      ・RangeCheck()
         *   　      上限・下限チェック
         * 　上限・下限の長さから規定値設定
         * 　コントロールの有効化
         * 
         * 　
         */
        private void CheckSetDuration()
        {
            int duration=GetFileDuration(SelectedMusicFile);
            SetDefault(duration);


            //上・下限の設定
            trackBar1.Maximum = duration;
            numericUpDown2.Maximum = duration;
            trackBar2.Maximum = duration;
            numericUpDown1.Maximum = duration;


            if (duration == 0)
            {
                //メッセージボックスを表示する
                MessageBox.Show
                    (
                    "長さが1秒以上の曲を選んでください",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );

                //選択ファイルをnullに
                SelectedMusicFile = null;
                toolStripStatusLabel1.Text = "ファイルが選択されていません code:01";
                textBox1.Text = "";
            }
            else
            {
                numericUpDown1.Maximum = duration;
            }
        }

        //ファイル選択ごとにデフォルトに戻す
        private void SetDefault(int duration)
        {
            RangeCheck();

            //上限の設定
            if (duration >= 10)
            {
                numericUpDown2.Value = 10;
            }
            else
            {
                numericUpDown2.Value = duration;
            }
            //上限の設定
            if (duration >= 5)
            {
                numericUpDown1.Value = 5;
            }
            else
            {
                numericUpDown1.Value = 1;
            }

            //コントロールの有効化
            trackBar1.Enabled = true;
            trackBar2.Enabled = true;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;

        }

        //選択した曲の情報取得
        private int GetFileDuration(string fname)
        {
            int duration;
            try
            {
                //選択したファイルの情報抽出ターゲット
                TagLib.File file = TagLib.File.Create(fname);
                //曲の長さ(秒)の取得
                duration = file.Properties.Duration.Seconds + file.Properties.Duration.Minutes * 60;
            }
            catch (FileNotFoundException)
            {
                duration = -1;
                Debug.WriteLine("filenotfound");
            }
            return duration;
           
        }

        //再生ボタン
        private void button1_Click(object sender, EventArgs e)
        {
            if (SelectedMusicFile == null) //ファイルが選択されてない時
            {
                //選択されていないのにランダムがオンになっている時
                if (randomize&dataGridView1.RowCount!=0)
                {
                    try
                    {
                        //乱数生成
                        Random rnd = new Random();
                        //乱数の範囲は表の行数から取得
                        int rndm = rnd.Next(0, dataGridView1.Rows.Count - 1);
                        //生成した乱数から行を特定して情報を取得
                        SelectedMusicFile = dataGridView1.Rows[rndm].Cells[3].Value.ToString();
                        textBox1.Text = dataGridView1.Rows[rndm].Cells[1].Value.ToString();
                        dataGridView1.FirstDisplayedScrollingRowIndex = rndm;
                        //取得した情報をもとに行を選択
                        dataGridView1.Rows[rndm].Selected = true;
                        //音楽の選択
                        SetMusic();
                        //音楽の再生
                        PlayMusic(SelectedMusicFile);
                    }
                    catch(NullReferenceException)
                    {
                        Debug.WriteLine("再生無し");
                    }


                }
                else
                {
                    toolStripStatusLabel1.Text = "ファイルが選択されていません code:04";
                }
            }
            else
            {
                //ランダムがオンの場合
                if (randomize)
                {
                    //乱数生成
                    Random rnd = new Random();
                    int rndm =rnd.Next(0,dataGridView1.Rows.Count-1);
                    SelectedMusicFile = dataGridView1.Rows[rndm].Cells[3].Value.ToString();
                    textBox1.Text = dataGridView1.Rows[rndm].Cells[1].Value.ToString();
                    dataGridView1.FirstDisplayedScrollingRowIndex = rndm;
                    dataGridView1.Rows[rndm].Selected = true;
                    PlayMusic(SelectedMusicFile);

                }
                //ランダムがオフの場合
                else
                {
                    PlayMusic(SelectedMusicFile);
                }
            }

        }

        //停止ボタン
        private void button4_Click(object sender, EventArgs e)
        {
            StopMusic(SelectedMusicFile);
        }

        //制限時間後
        private void timer1_Tick(object sender, EventArgs e)
        {
            StopMusic(SelectedMusicFile);
        }

        //選択ボタン
        private void button2_Click(object sender, EventArgs e)
        {
            SelectedMusicFile = MusicFileSelectSetting();
        }

        //上限の設定
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            //トラックバーとの同期
            if (trackBar1.Value < trackBar1.Maximum)
            {
                trackBar1.Value = (int)numericUpDown2.Value;
            }

            RangeCheck();
        }

        //下限の設定
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //トラックバーとの同期
            if (trackBar1.Value < trackBar1.Maximum)
            {
                trackBar2.Value = (int)numericUpDown1.Value;
            }

            RangeCheck();
        }

        ///<トラックバー>
        ///数値と同期させる
        ///</トラックバー>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //数字変更との同期
            numericUpDown2.Value = trackBar1.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            //数字変更との同期
            numericUpDown1.Value = trackBar2.Value;
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
            Process.Start(folderPath + @"\readme.txt"); // 指定したフォルダを開く
        }

        #endregion
        #region<m3uファイル読み込み>
        string Selectedm3uFile=null;
        string[][] GridData;
        string[][] dealdata;
        //ファイルを開く
        private void button3_Click(object sender, EventArgs e)
        {
            Selectedm3uFile = M3uFileSelectSetting();
            if (Selectedm3uFile == null)
            {
                UnableEdit();
                toolStripStatusLabel1.Text = "ファイルが選択されていません code:05";

            }
            else
            {
                EnabledEdit();
                WriteGridViewData(Selectedm3uFile);
                textBox2.Text = Selectedm3uFile;

            }
        }
        private void WriteGridViewData(string data)
        {
            Loadingm3u loadingm3U = new Loadingm3u();

            if (data ==null)
            {
                GridData =new string[3][];
            }
            else
            {
                if (File.Exists(data))
                {
                    GridData = loadingm3U.Loading(data);
                    WriteGridView(GridData);
                }  
            }
        }
        private void WriteGridView(string[][]GridData)
        {
            if(GridData != null)
            {
                string InputLocation;
                string song;
                string duration;
                string Location;
                for (int i = 0; i < GridData[1].Length; i++)
                {
                    dealdata = new string[3][];
                    dealdata = GridData;
                    InputLocation = dealdata[2][i];
                    InputLocation = CheckAdress(InputLocation);
                    song = dealdata[0][i];
                    duration = dealdata[1][i];
                    Location = InputLocation;
                    int checkduration = GetFileDuration(InputLocation);
                    if (checkduration == -1)
                    {
                        toolStripStatusLabel1.Text = GridData[0][i] + "が見つかりませんでした";
                    }
                    else
                    {
                        dataGridView1.Rows.Add(i + 1, song, duration, Location);
                    }
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rows = dataGridView1.CurrentCell.RowIndex;
            if (dataGridView1.Rows[rows].Cells[3].Value.ToString() == null)
            {
                SelectedMusicFile = null;
                textBox1.Text = null;
            }
            else
            {
                SelectedMusicFile = dataGridView1.Rows[rows].Cells[3].Value.ToString();
                SetMusic();
            }
            
        }
        private string CheckAdress(string adress)
        {
            string vfname;
            if (adress.Contains(":\\"))
            {
                vfname = adress;
            }
            else
            {
                vfname =   Selectedm3uFile.Remove(Selectedm3uFile.LastIndexOf("\\")+1)+adress;
            }
            return vfname;
        }
        private string M3uFileSelectSetting()
        {
            string folderPath = Directory.GetCurrentDirectory();
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd2 = new OpenFileDialog
            {
                //はじめに表示されるフォルダを指定する
                //指定しない（空の文字列）の時は、現在のディレクトリが表示される
                InitialDirectory = folderPath+@"\playlists",
                //[ファイルの種類]に表示される選択肢を指定する
                //指定しないとすべてのファイルが表示される
                Filter = "音楽プレイリスト(*.m3u)|*.m3u",
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
            if (ofd2.ShowDialog() == DialogResult.OK)
            {
                Selectedm3uFile = ofd2.FileName;//選択したファイルの設定
            }
            else
            {
                Selectedm3uFile =null;
            }
            ofd2.Dispose();
            return Selectedm3uFile;
        }
        #endregion
        #region<m3uファイル作成>
        //新規作成ボタン
        private void button5_Click(object sender, EventArgs e)
        {
            //新規ファイル作成
            Selectedm3uFile = FileCreate();
            //作成したファイルをストリップバーに表示
            toolStripStatusLabel1.Text = Selectedm3uFile;
            //デフォルトのフォルダーを指定するために現在のディレクトリの取得
            string folderPath = Directory.GetCurrentDirectory();


            ///<ファイル選択ダイアログ>
            ///新規ファイルのディレクトリの取得
            ///・デフォルトのディレクトリはPlaylists直下
            ///・指定ファイル形式はm3u
            ///・上書き保存を可能にする
            ///</ファイル選択ダイアログ>
 

            //OpenFileDialogクラスのインスタンスを作成
            SaveFileDialog ofd4 = new SaveFileDialog
            {
                //はじめに表示されるフォルダを指定する
                //指定しない（空の文字列）の時は、現在のディレクトリが表示される
                InitialDirectory = folderPath+@"\Playlists",
                //[ファイルの種類]に表示される選択肢を指定する
                //指定しないとすべてのファイルが表示される
                Filter = "音楽プレイリスト(*.m3u)|*.m3u",
                //[ファイルの種類]ではじめに選択されるものを指定する
                //タイトルを設定する
                Title = "新規プレイリスト作成",
                //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
                RestoreDirectory = true,
                //存在しないファイルの名前が指定されたとき警告を表示する
                //デフォルトでTrueなので指定する必要はない
                CheckFileExists = false,
                //存在しないパスが指定されたとき警告を表示する
                //デフォルトでTrueなので指定する必要はない
                CheckPathExists = false ,
                FileName=Selectedm3uFile
            };
            ofd4.OverwritePrompt = true;
            //ダイアログを表示する
            //OKが出たとき
            if (ofd4.ShowDialog() == DialogResult.OK)
            {
                //datagridviewにデータを追加
                WriteGridViewData(Selectedm3uFile);
                //選択したプレイリストはダイアログで取得したディレクトリに指定
                Selectedm3uFile = ofd4.FileName;
                //m3uファイルの作成
                m3uCreate(ofd4.FileName);
                textBox2.Text = Selectedm3uFile;
                EnabledEdit();
                ofd4.Dispose();

            }
            else
            {
                toolStripStatusLabel1.Text = "キャンセルされました";
                Selectedm3uFile = null;
                UnableEdit();
                ofd4.Dispose();

            }
            
        }
        private void m3uCreate(string flocation)
        {
            StreamWriter clear = new StreamWriter(flocation, false, Encoding.UTF8);
            {
                clear.WriteLine("#EXTM3U");
                clear.Close();
            }
        }
        private void EnabledEdit()
        {
            button3.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button13.Enabled = true;

        }
        private void UnableEdit()
        {
            button3.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            button12.Enabled = false;
            button13.Enabled = false;

        }
        private string FileCreate()
        {
            int fnum = 1;
            for (int r = 1; r > 0; r++)
            {
                string FP = folderPath + @"\Playlists\" + fnum.ToString() + @".m3u";
                Debug.WriteLine(FP);
                if (File.Exists(FP))
                {
                    ++fnum;
                }
                else
                {
                    break;
                }
            }
            string returnname = fnum.ToString() + @".m3u";
            return returnname;

        }
        #endregion
        #region<m3uファイル保存>
        //名前を付けて保存のダイアログ
        private string M3uFileSaveSetting()
        {
            string folderPath = Directory.GetCurrentDirectory();

            //OpenFileDialogクラスのインスタンスを作成
            SaveFileDialog ofd4 = new SaveFileDialog
            {
                //はじめに表示されるフォルダを指定する
                //指定しない（空の文字列）の時は、現在のディレクトリが表示される
                InitialDirectory = folderPath+@"\Playlists",
                //[ファイルの種類]に表示される選択肢を指定する
                //指定しないとすべてのファイルが表示される
                Filter = "音楽プレイリスト(*.m3u)|*.m3u",
                //[ファイルの種類]ではじめに選択されるものを指定する
                //タイトルを設定する
                Title = "名前を付けて保存",
                //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
                RestoreDirectory = true,
                //存在しないファイルの名前が指定されたとき警告を表示する
                //デフォルトでTrueなので指定する必要はない
                CheckFileExists = false,
                //存在しないパスが指定されたとき警告を表示する
                //デフォルトでTrueなので指定する必要はない
                CheckPathExists = false
            };
            ofd4.OverwritePrompt = true;
            //ダイアログを表示する
            if (ofd4.ShowDialog() == DialogResult.OK)
            {
                Selectedm3uFile = ofd4.FileName;//選択したファイルの設定

                ofd4.Dispose();
                return Selectedm3uFile;

            }
            else
            {
                Selectedm3uFile = null;
                ofd4.Dispose();
                return null;

            }


        }
        //名前を付けて保存
        private void button8_Click(object sender, EventArgs e)
        {
            string savePath = M3uFileSaveSetting();
            Selectedm3uFile = savePath;
            if (savePath == null)
            {
                toolStripStatusLabel1.Text = "ファイルが選択されていません。code:06";
            }
            else
            {
                toolStripStatusLabel1.Text = savePath + "に保存しました";
                GetData(savePath);
            }
        }
        //上書き保存
        private void button7_Click(object sender, EventArgs e)
        {
            if (Selectedm3uFile == null)
            {
                toolStripStatusLabel1.Text = "ファイルが選択されていません。code:06";
            }
            else
            {
                toolStripStatusLabel1.Text = Selectedm3uFile + "に上書き保存しました";
                GetData(Selectedm3uFile);
            }
        }
        //datagridviewのデータ取得
        private void GetData(string FilePath)
        {
            try
            {
                string[][] SaveData = new string[4][];
                string[] songname = new string[dataGridView1.Rows.Count-1];
                string[] duration = new string[dataGridView1.Rows.Count-1];
                string[] location = new string[dataGridView1.Rows.Count-1];
                for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                    songname[i] = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    duration[i] = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    location[i] = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    Debug.WriteLine(dataGridView1.Rows[i].Cells[3].Value.ToString());
                }
                SaveData[0] = songname;
                SaveData[1] = duration;
                SaveData[2] = location;
                SaveData[3] = new string[1];
                SaveData[3][0] = FilePath;


                Loadingm3u saving = new Loadingm3u();
                saving.save(SaveData);
            }
            catch (NullReferenceException)
            {
                toolStripStatusLabel1.Text = "データが入力されていません code:07";
            }
            
        }
     
        #endregion
        #region<Gridの編集>
        private string[][] MusicFileAdd()
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd3 = new OpenFileDialog
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
            ofd3.Multiselect = true;
            string[][] returndata = new string[3][];
            //ダイアログを表示する
            if (ofd3.ShowDialog() == DialogResult.OK)
            {
                string[] InputSongName = new string[ofd3.FileNames.Length];
                string[] InputDuration = new string[ofd3.FileNames.Length];
                string[] InputLocation = new string[ofd3.FileNames.Length];

                int n = 0;
                foreach (string input in ofd3.FileNames)
                {
                    Debug.WriteLine(input);
                    InputSongName[n] = Path.GetFileNameWithoutExtension(input);
                    InputDuration[n] = GetFileDuration(input).ToString();
                    InputLocation[n] = input;
                    n++;
                }
                returndata[0] = InputSongName;
                returndata[1] = InputDuration;
                returndata[2] = InputLocation;
            }
            else
            {
                returndata = null;
            }
            ofd3.Dispose();
            dataGridView1.Enabled = true;
            return returndata;
        }

        private void AddGrid()
        {
            dataGridView1.Enabled=false;
            
            string[][] AddData = MusicFileAdd();
            if (AddData == null)
            {
                toolStripStatusLabel1.Text = "ファイルが選択されていません。code:06";
            }
            else
            {
                toolStripStatusLabel1.Text = "ファイルが読み込まれました";
                WriteGridView(AddData);
            }


        }
       
        private void button9_Click(object sender, EventArgs e)
        {
            AddGrid();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DeleteGrid();
        }
        private void DeleteGrid()
        {
            int rows = dataGridView1.CurrentCell.RowIndex;
            try
            {
                dataGridView1.Rows.RemoveAt(rows);

            }
            catch (InvalidOperationException)
            {
                Debug.WriteLine("削除無し");
            }


        }
        #endregion
        #region<others>
      
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            SelectedMusicFile = null;
            textBox1.Text = null;
            textBox2.Text = null;
            Selectedm3uFile = null;
            dataGridView1.Rows.Clear();
            UnableEdit();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Selectedm3uFile = M3uFileSelectSetting();
            toolStripStatusLabel1.Text = Selectedm3uFile;
            if (Selectedm3uFile == null)
            {
                toolStripStatusLabel1.Text = "ファイルが選択されていません。code:06";

            }
            else
            {
                WriteGridViewData(Selectedm3uFile);

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (Selectedm3uFile == null)
            {
                toolStripStatusLabel1.Text = "ファイルが選択されていません。code:06";

            }
            else
            {
                AddMusic();

            }
        }
        private void AddMusic()
        {
            if (SelectedMusicFile == null)
            {

            }
            else
            {
                string[][] AddData = new string[3][];
                string[] songname = { Path.GetFileNameWithoutExtension(SelectedMusicFile) };
                string[] duration = { GetFileDuration(SelectedMusicFile).ToString() };
                string[] Location = { SelectedMusicFile };
                AddData[0] = songname;
                AddData[1] = duration;
                AddData[2] = Location;
                WriteGridView(AddData);
                toolStripStatusLabel1.Text = songname[0] + "を追加しました";
            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button12.Enabled = true;
        }
        bool randomize;
        private void button13_Click(object sender, EventArgs e)
        {
            if (randomize)
            {
                button13.Text = "Random OFF";
                randomize = false;
            }
            else
            {
                button13.Text = "Random ON";
                randomize = true;
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                int rows = dataGridView1.CurrentCell.RowIndex;
                if (dataGridView1.Rows[rows].Cells[3].Value.ToString() == null)
                {
                    SelectedMusicFile = null;
                    textBox1.Text = null;
                }
                else
                {
                    SelectedMusicFile = dataGridView1.Rows[rows].Cells[3].Value.ToString();
                    SetMusic();
                }
            }
            catch(NullReferenceException)
            {
                Debug.WriteLine("選択無し");
                SelectedMusicFile = null;
                toolStripStatusLabel1.Text = "ファイルが選択されていません code:01";
                textBox1.Text = "";
            }
               
            
           
        }
    }
    #endregion

}
