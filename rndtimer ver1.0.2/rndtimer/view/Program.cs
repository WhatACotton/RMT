using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace anki
{
    class Program
    {
        private static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"C:\Users\hwwat\Documents\重要__英語f.csv");
            {
                while(!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] values = line.Split(',');
                    List<string> lists = new List<string>();
                    lists.AddRange(values);
                    int num = lists.Count;
                    for (int n = 0; n < num; n++)
                    {
                        // 表示
                        Console.Write(lists[n] + ",");
                    }
                    Console.WriteLine("next");
                    string filename = lists[0];
                    string filename2 = filename.Replace(" ", "_");
                    string fileedit2 = filename.Replace('\"', ' ');
                    string fileedit4 = fileedit2.Replace('、', ',');
                    string fileedit3 = fileedit4.Replace('/', ' ');
                    string fileedit = fileedit3.Replace('?', ' ');

                    string title = filename2;
                    string link = @"C:\Users\hwwat\Documents\programing\C#\ankid\" + fileedit+".txt";
                    using (FileStream fs = File.Create(link))
                    {
                        fs.Close();
                    }
                    using (StreamWriter contents = new StreamWriter(link, false, Encoding.UTF8))
                    {
                        contents.WriteLine("#"+title);
                        int n = 1;
                        string[] kakiko = new string[25];

                        foreach (string jun in lists)
                        {
                            kakiko[n] = jun;
                            if(jun.Length==0)
                            {

                            }else
                            {
                                string bun="";

                                switch (n)
                                {
                                    case 2:
                                        bun = "#LEAP_名詞 " + jun;
                                        break;
                                    case 3:
                                        bun = "#LEAP_自動詞 " + jun;
                                        break;
                                    case 4:
                                        bun = "#LEAP_他動詞 " + jun;
                                        break;
                                    case 5:
                                        bun = "#LEAP_形容詞 " + jun;
                                        break;
                                    case 6:
                                        bun = "#LEAP_前置詞 " + jun;
                                        break;
                                    case 7:
                                        bun = "#LEAP_副詞 " + jun;
                                        break;
                                    case 8:
                                        bun = "#LEAP_接続詞 " + jun;
                                        break;
                                    case 9:
                                        bun = "#LEAP_助動詞 " + jun;
                                        break;
                                    case 10:
                                        bun = "備考 " + jun;
                                        break;
                                    case 11:
                                        bun = "#ターゲット1400 " + jun;
                                        break;
                                    case 12:
                                        bun = "#ターゲット1900 " + jun;
                                        break;
                                    case 13:
                                        bun = "#ターゲット英熟語1000 " + jun;
                                        break;
                                    case 14:
                                        bun = "#システム英単語 " + jun;
                                        break;
                                    case 15:
                                        bun = "#速読英単語 " + jun;
                                        break;
                                    case 16:
                                        bun = "#Duo3.0 " + jun;
                                        break;
                                    case 17:
                                        bun = "#鉄壁 " + jun;
                                        break;
                                    case 18:
                                        bun = "#stock3200 " + jun;
                                        break;
                                    case 19:
                                        bun = "#stock4500 " + jun;
                                        break;
                                    case 20:
                                        bun = "#出る順3級 " + jun;
                                        break;
                                    case 21:
                                        bun = "#出る順準2級 " + jun;
                                        break;
                                    case 22:
                                        bun = "#出る順2級 " + jun;
                                        break;
                                    case 23:
                                        bun = "#出る順準1級 " + jun;
                                        break;
                                    case 24:
                                        bun = "#出る順1級 " + jun;
                                        break;
                                    

                                }
                                   
                                contents.WriteLine(bun);
                            }
                            n++;

                        }
                        contents.Close();
                        // 拡張子を変更する
                        string newPath =
                          Path.ChangeExtension(link, ".md");
                        if(File.Exists(newPath))
                        {

                        }
                        else // 実際のファイル名を変更する
                            File.Move(link, newPath);


                    }
                   
                }
            }
        }
    }
}
    