using System.Data.Common;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace weblioscraping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string src = @"C:\Users\hwwat\Documents\重要__英語f.csv";
            int num2 = 1;
            string[] wordlist = new string[0] { };
            StreamReader sr = new StreamReader(src);
            {

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] values = line.Split(',');
                    List<string> lists = new List<string>();
                    lists.AddRange(values);
                    int num = lists.Count;
                    num2++;
                    string filename = lists[0];
                    if (!filename.Contains(" ")&&!filename.Contains("-")&&!filename.Contains("～") && !filename.Contains("[") && !filename.Contains("(") && !filename.Contains("（") && !filename.Contains("［"))
                    {
                        Array.Resize(ref wordlist, wordlist.Length + 1);
                        wordlist[wordlist.Length - 1] = filename;

                    }


                }
                sr.Close();
                foreach(string word in wordlist)
                {
                    Console.WriteLine(word);
                    Process process = new Process();
                        //コマンドプロンプトのパスをファイルネームにセットする
                    process.StartInfo.FileName = Environment.GetEnvironmentVariable("ComSpec");
                    process.StartInfo.CreateNoWindow = true;         //コマンドプロンプトのウィンドウを非表示⇐ここをtrueにしたら成功した...
                    process.StartInfo.UseShellExecute = false;        //プロセスを実行可能ファイルから直接作成する
                    process.StartInfo.RedirectStandardOutput = true;  //テキスト出力をStandardOutputストリームに書き込む
                    process.StartInfo.Arguments = @"/c python C:\Users\hwwat\Documents\programing\python\weblio2.py "+word;
                    process.Start();
                    Console.WriteLine(@"/c python C:\Users\hwwat\Documents\programing\python\weblio2.py " + word);
                    //出力を読み取る
                    string results = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();
                    process.Close();
                    Console.WriteLine(results);
                    using (StreamWriter contents = new StreamWriter(@"C:\Users\hwwat\Desktop\weblioscraping2.txt", true, Encoding.UTF8))
                    {
                        contents.WriteLine(results);
                    }
                }

            }
        }
    }
}
