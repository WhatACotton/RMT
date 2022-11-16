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
        RandomMusicTimer RMT = new RandomMusicTimer();

        //変数宣言
        public string FolderPath = null;
        public string SelectedMusicFile = null;//選択したファイル名
        public string Selectedm3uFile = null;//選択したプレイリスト名

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
            FolderPath= Directory.GetCurrentDirectory();//ディレクトリの取得

        }
        public void PlayMusic()
        {
            ShowingtoolStripStatusLabel1Text("再生中！");
            TimerControl(true);
            PlayControl(false);
            RangeControl(false);
            SelectControl(false);
        }
        public void StopMusic()
        {
            ShowingtoolStripStatusLabel1Text("停止しました");
            TimerControl(false);
            PlayControl(true);
            RangeControl(true);
            SelectControl(true);
        }
        #region<control>
        private void SelectControl(bool Flag)
        {
            button2.Enabled = Flag;
            dataGridView1.Enabled = Flag;
        }
        private void PlayControl(bool Flag)
        {
            //再生ボタン
            button1.Enabled = Flag;
            //停止ボタン
            button4.Enabled = !Flag;
        }
        private void TimerControl(bool Flag)
        {
            timer1.Enabled = Flag;
        }
        private void RangeControl(bool Flag)
        {
            //コントロールの有効化
            numericUpDown1.Enabled = Flag;
            numericUpDown2.Enabled = Flag;
            trackBar1.Enabled = Flag;
            trackBar2.Enabled = Flag;
        }
        public void ShowingtoolStripStatusLabel1Text(string Text)
        {
            //ステータス表示
            toolStripStatusLabel1.Text =Text;
        }
        public void ShowingPlaylist(string Text)
        {
            textBox2.Text = Text;
        }
        public void TickSet(int Time)
        {
            timer1.Interval = Time;
        }
        public void ListControl(bool Flag)
        {
                //リスト1行削除ボタン
                button6.Enabled = Flag;

                //保存ボタン
                button7.Enabled = Flag;

                //名前を付けて保存ボタン
                button8.Enabled = Flag;

                //曲追加ボタン
                button9.Enabled = Flag;

                //クリアボタン
                button10.Enabled = Flag;

                //プレイリスト追加ボタン
                button11.Enabled = Flag;

                //ランダムボタン
                button13.Enabled = Flag;

                //リストに挿入ボタン
                button12.Enabled = Flag;

            
        }
        public void FileControl(bool Flag)
        {
            //ファイルを開くボタン
            button3.Enabled = Flag;
            //新規プレイリスト作成ボタン
            button5.Enabled = Flag;
        }
        #endregion
        //コントロールの有効化・無効化(音楽の再生・停止用)

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
            SelectedMusicFile = RMT.SelectMusic();
            if (SelectedMusicFile != null)
            {
                SetMusic();
                return SelectedMusicFile;
            }
            else
            {
                ShowingtoolStripStatusLabel1Text("ファイルが選択されていません code:03");
                return null;
            }
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
            int duration=RMT.GetFileDuration(SelectedMusicFile);
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

        
        //再生ボタン
        private void button1_Click(object sender, EventArgs e)
        {
            int RNDTime = RMT.ChoosingTime((int)numericUpDown1.Value, (int)numericUpDown2.Value);
            TickSet(RNDTime);

            if (SelectedMusicFile == null) //ファイルが選択されてない時
            {
                if (randomize&dataGridView1.RowCount!=0)
                {
                    try
                    {
                        /*
                         * ～ランダム再生～
                         * 表の行数をもとに乱数を生成して曲を選択する
                         * 選択された曲を選択する
                         */
                        //乱数生成
                        Random rnd = new Random();
                        int rndm = rnd.Next(0, dataGridView1.Rows.Count - 1);
                        SelectedMusicFile = dataGridView1.Rows[rndm].Cells[3].Value.ToString();
                        textBox1.Text = dataGridView1.Rows[rndm].Cells[1].Value.ToString();
                        dataGridView1.FirstDisplayedScrollingRowIndex = rndm;
                        dataGridView1.Rows[rndm].Selected = true;
                        //曲をセット
                        SetMusic();
                        //曲を再生
                        RMT.PlayMusic(SelectedMusicFile);
                        PlayMusic();
                        //リスト編集機能の有効化
                        ListControl(false);
                    }
                    catch(NullReferenceException)
                    {
                        Debug.WriteLine("再生無し");
                    }


                }
                else
                {
                    ShowingtoolStripStatusLabel1Text("ファイルが選択されていません code:04");
                }
            }
            else
            {
                if (randomize)
                {
                    //乱数生成
                    Random rnd = new Random();
                    int rndm =rnd.Next(0,dataGridView1.Rows.Count-1);
                    SelectedMusicFile = dataGridView1.Rows[rndm].Cells[3].Value.ToString();
                    textBox1.Text = dataGridView1.Rows[rndm].Cells[1].Value.ToString();
                    dataGridView1.FirstDisplayedScrollingRowIndex = rndm;
                    dataGridView1.Rows[rndm].Selected = true;
                    RMT.PlayMusic(SelectedMusicFile);
                    PlayMusic();
                    //リスト編集機能の有効化
                    ListControl(false);

                }
                else
                {
                    RMT.PlayMusic(SelectedMusicFile);
                    PlayMusic();
                    //リスト編集機能の有効化
                    ListControl(false);
                }
            }

        }

        //停止ボタン
        private void button4_Click(object sender, EventArgs e)
        {
            RMT.StopMusic(SelectedMusicFile);
            StopMusic();
            //リスト編集機能の有効化
            ListControl(true);
        }

        //制限時間後
        private void timer1_Tick(object sender, EventArgs e)
        {
            RMT.StopMusic(SelectedMusicFile);
            StopMusic();
            //リスト編集機能の有効化
            ListControl(true);
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
            Process.Start(FolderPath + @"\readme.txt"); // 指定したフォルダを開く
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        #endregion
        #region<m3uファイル読み込み>
        string[][] GridData;
        string[][] dealdata;
        //ファイルを開く
        private void button3_Click(object sender, EventArgs e)
        {
            Selectedm3uFile = M3uFileSelectSetting();
            if (Selectedm3uFile == null)
            {
                FileControl(true);
                ListControl(false);
                ShowingtoolStripStatusLabel1Text("ファイルが選択されていません code:05");
            }
            else
            {
                FileControl(false);
                ListControl(true);
                WriteGridViewData(Selectedm3uFile);
                textBox2.Text = Selectedm3uFile;

            }
        }
        public void WriteGridViewData(string data)
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
                else
                {
                   
                    
                  
                }
                
               
            }
           
            
           
        }
        private void WriteGridView(string[][]GridData)
        {
            if(GridData != null){
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
                int checkduration = RMT.GetFileDuration(InputLocation);
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
            string m3u = RMT.Selectm3u(FolderPath);
            if (m3u != null)
            {
                return m3u;
            }
            else
            {
                return null;
            }
        }
        #endregion
        #region<m3uファイル作成>
        //新規作成ボタン
        private void button5_Click(object sender, EventArgs e)
        {
            //新規ファイル作成
            string newFile = RMT.CreateFile(FolderPath);
            if (newFile != null)
            {
                //datagridviewにデータを追加
                WriteGridViewData(newFile);
                //選択したプレイリストはダイアログで取得したディレクトリに指定
                Selectedm3uFile = newFile;
                //m3uファイルの作成
                m3uCreate(newFile);
                //作成したファイルをテキストボックスに表示
                ShowingPlaylist(newFile);
                //作成したファイルをストリップバーに表示
                ShowingtoolStripStatusLabel1Text(newFile + "を作成しました");
                ListControl(true);
                FileControl(false);
            }
            else
            {
                ListControl(false);
                FileControl(true);
                ShowingtoolStripStatusLabel1Text("キャンセルされました");
                Selectedm3uFile = null;
            }
        }
        public void ShowingToolStripText(string text)
        {
            toolStripStatusLabel1.Text = text;
        }
        private void m3uCreate(string flocation)
        {
            StreamWriter clear = new StreamWriter(flocation, false, Encoding.Default);
            {
                clear.WriteLine("#EXTM3U");
                clear.Close();
            }
        }


        #endregion
        #region<m3uファイル保存>
       
            
        //名前を付けて保存
        private void button8_Click(object sender, EventArgs e)
        {
            string savePath = RMT.M3uFileSaveSetting(FolderPath);
            if (savePath != null)
            {
                toolStripStatusLabel1.Text = savePath + "に保存しました";
                DataSave(savePath);
            }
            else
            {
                toolStripStatusLabel1.Text = "キャンセルされました。code:06";
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
                DataSave(Selectedm3uFile);
            }
        }
        //datagridviewのデータ取得
        private void DataSave(string FilePath)
        {
            if (FilePath != null)
            {
                string[][] SaveData = new string[4][];
                string[] songname = new string[dataGridView1.Rows.Count - 1];
                string[] duration = new string[dataGridView1.Rows.Count - 1];
                string[] location = new string[dataGridView1.Rows.Count - 1];
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
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
            else
            {
                ShowingtoolStripStatusLabel1Text("データが入力されていません code:07");
            }    
            
        }
     
        #endregion
        #region<Gridの編集>


        private void AddGrid()
        {
            string[][] AddData = RMT.MusicFileAdd();
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
            ListControl(false);
            FileControl(true);
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
                string[] duration = { RMT.GetFileDuration(SelectedMusicFile).ToString() };
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
