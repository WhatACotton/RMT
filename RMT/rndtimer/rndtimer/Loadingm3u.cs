using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.MobileControls.Adapters;
using System.IO;
using System.Diagnostics;

namespace rndtimer
{
    class Loadingm3u
    {
        #region<読み込み>
        private string m3uConvert(string location)
        {
            // 拡張子を変更する
            string newPath = Path.ChangeExtension(location, ".txt");
           
                // 実際のファイル名を変更する
                File.Move(location, newPath);
            
            
            return newPath;
        }
        private string txtConvert(string location)
        {
            // 拡張子を変更する
            string newPath = Path.ChangeExtension(location, ".m3u");
            // 実際のファイル名を変更する
            File.Move(location, newPath);
            newPath = location;
            return newPath;
        }
        public string[][] Loading(string location)
        {
           
                string[] lines = File.ReadAllLines(location);
                int Length = (lines.Length - 1) / 2;
                string[][] OutPutData = new string[3][];
                string[] songname = new string[Length];
                string[] duration = new string[Length];
                string[] Location = new string[Length];
                string datas;
                string inputsongname;
                string inputduration;
                location = m3uConvert(location);
            if (Length == 0)
            {
                txtConvert(location);
                return null;
            }
            else
            {
                
                StreamReader sr = new StreamReader(location, Encoding.Default);
                {
                    while (!sr.EndOfStream)
                    {

                        for (int i = 0; i < Length;)
                        {
                            datas = sr.ReadLine();

                            if (datas.Contains("#EXTM3U")) { }
                            else
                            {
                                bool ReadLocation;
                                if (datas.Contains("#EXTINF"))
                                {
                                    ReadLocation = false;
                                }
                                else
                                {
                                    ReadLocation = true;
                                }
                                if (!ReadLocation)
                                {
                                    string[] values = datas.Split(',');
                                    inputduration = values[0].Replace("#EXTINF:", "");

                                    inputsongname = values[1];
                                    if (inputsongname.StartsWith(" - "))
                                    {
                                        inputsongname = inputsongname.Replace(" - ", "");
                                    }
                                    songname[i] = inputsongname;
                                    duration[i] = inputduration;

                                }
                                else
                                {
                                    Location[i] = datas;
                                    i++;
                                }

                            }
                        }

                    }
                    sr.Close();
                    txtConvert(location);

                }
                OutPutData[0] = songname;
                OutPutData[1] = duration;
                OutPutData[2] = Location;
                return OutPutData;

            }


        }
        #endregion
        #region<書き込み>
        public void save(string[][] savedata)
        {
            string flocation = savedata[3][0];
            StreamWriter clear = new StreamWriter(flocation,false, Encoding.Default);
            {
                clear.WriteLine("");
                clear.Close();
            }
            StreamWriter input = new StreamWriter(flocation, false, Encoding.Default);
            {
                input.WriteLine("#EXTM3U");
                for(int i=0;i<savedata[0].Length;i++)
                {
                    Debug.WriteLine("write" + savedata[0][i]);
                    input.WriteLine("#EXTINF:{0}, {1}\n{2}",savedata[1][i],savedata[0][i],savedata[2][i]);
                    
                }
                
                input.Close();
            }

        }
        #endregion
    }
}