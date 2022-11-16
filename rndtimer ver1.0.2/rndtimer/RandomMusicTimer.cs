using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rndtimer
{
    class RandomMusicTimer
    {

        public void StopMusic(string FileDirectory)
        {
            //音楽の停止
            Microsoft.SmallBasic.Library.Sound.Stop(FileDirectory);
        }

        public void PlayMusic(string FileDirectory)
        {
            //音楽の停止
            Microsoft.SmallBasic.Library.Sound.Play(FileDirectory);
        }
        public int ChoosingTime(int Start, int End)
        {
            //乱数生成
            Random rnd = new Random();
            //ミリ秒から変換
            return rnd.Next(Start, End) * 1000;
        }
        private string FileNameCreate(string FolderPath)
        {

            int fnum = 1;
            for (int r = 1; r > 0; r++)
            {
                string FP = FolderPath + @"\Playlists\Playlist" + fnum.ToString() + @".m3u";
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
            string returnname = @"Playlist" + fnum.ToString() + @".m3u";
            return returnname;
        }
        ///<ファイル選択ダイアログ>
        ///新規ファイルのディレクトリの取得
        ///・デフォルトのディレクトリはPlaylists直下
        ///・指定ファイル形式はm3u
        ///・上書き保存を可能にする
        ///</ファイル選択ダイアログ>
        public string CreateFile(string FolderPath)
        {

            //OpenFileDialogクラスのインスタンスを作成
            SaveFileDialog ofdCreate = new SaveFileDialog
            {
                //はじめに表示されるフォルダを指定する
                //指定しない（空の文字列）の時は、現在のディレクトリが表示される
                InitialDirectory = FolderPath + @"\Playlists",
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
                CheckPathExists = false,

                FileName = FileNameCreate(FolderPath)
            };
            ofdCreate.OverwritePrompt = true;
            //ダイアログを表示する
            //OKが出たとき
            if (ofdCreate.ShowDialog() == DialogResult.OK)
            {
                string SelectedFile = ofdCreate.FileName;
                ofdCreate.Dispose();
                return SelectedFile;
            }
            else
            {
                ofdCreate.Dispose();
                return null;
            }
        }
        public string SelectMusic()
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofdSelectMusic = new OpenFileDialog
            {
                //はじめに表示されるフォルダを指定する
                //指定しない（空の文字列）の時は、現在のディレクトリが表示される
                InitialDirectory = @"C:\music",
                //[ファイルの種類]に表示される選択肢を指定する
                //指定しないとすべてのファイルが表示される
                Filter = "音楽ファイル(*.mp3;*.wav)|*.mp3;*.wav",
                //[ファイルの種類]ではじめに選択されるものを指定する
                //タイトルを設定する
                Title = "音楽を選択してください",
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
            if (ofdSelectMusic.ShowDialog() == DialogResult.OK)
            {
                string SelectedMusicFile = ofdSelectMusic.FileName;//選択したファイルの設定
                ofdSelectMusic.Dispose();
                return SelectedMusicFile;
            }
            else
            {
                ofdSelectMusic.Dispose();
                return null;
            }
        }
        public string Selectm3u(string FolderPath)
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofdm3u = new OpenFileDialog
            {
                //はじめに表示されるフォルダを指定する
                //指定しない（空の文字列）の時は、現在のディレクトリが表示される
                InitialDirectory = FolderPath + @"\playlists",
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
            if (ofdm3u.ShowDialog() == DialogResult.OK)
            {
                string m3u = ofdm3u.FileName;
                ofdm3u.Dispose();
                return m3u;//選択したファイルの設定
            }
            else
            {
                ofdm3u.Dispose();
                return null;
            }
        }
        public string[][] MusicFileAdd()
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
            return returndata;
        }
        //選択した曲の情報取得
        public int GetFileDuration(string fname)
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
        //名前を付けて保存のダイアログ
        public string M3uFileSaveSetting(string FolderPath)
        {

            //OpenFileDialogクラスのインスタンスを作成
            SaveFileDialog ofd4 = new SaveFileDialog
            {
                //はじめに表示されるフォルダを指定する
                //指定しない（空の文字列）の時は、現在のディレクトリが表示される
                InitialDirectory = FolderPath + @"\Playlists",
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
                string Selectedm3uFile = ofd4.FileName;
                ofd4.Dispose();
                return Selectedm3uFile;

            }
            else
            {
                ofd4.Dispose();
                return null;

            }
        }
    }

}