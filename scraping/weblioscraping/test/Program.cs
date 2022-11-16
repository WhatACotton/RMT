using System.Diagnostics;
string word = "agree";
Console.WriteLine(word);
Process process = new Process();
//コマンドプロンプトのパスをファイルネームにセットする
process.StartInfo.FileName = Environment.GetEnvironmentVariable("ComSpec");
process.StartInfo.CreateNoWindow = false;         //コマンドプロンプトのウィンドウを非表示
process.StartInfo.UseShellExecute = false;        //プロセスを実行可能ファイルから直接作成する
process.StartInfo.RedirectStandardOutput = true;  //テキスト出力をStandardOutputストリームに書き込む
process.StartInfo.Arguments = @"/c python C:\Users\hwwat\Documents\programing\python\weblio.py " + word;
process.Start();
Console.WriteLine(@"/c python C:\Users\hwwat\Documents\programing\python\weblio.py " + word);
//出力を読み取る
string results = process.StandardOutput.ReadToEnd();
process.WaitForExit();
process.Close();
Console.WriteLine(results);