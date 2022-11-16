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
            StreamReader sr = new StreamReader(@"C:\Users\hwwat\Documents\programing\C#\Noun.txt");
            {
                int n = 0;

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Console.WriteLine("next");
                    string link = @"C:\Users\hwwat\Documents\programing\C#\ankid\" + line;
                    string linkmd = link + ".md";
                    // 拡張子を変更する 
                    string newPath1 = Path.ChangeExtension(linkmd, ".txt");
                    // 実際のファイル名を変更する
                    File.Move(linkmd,newPath1);
                    using (StreamWriter contents = new StreamWriter(newPath1, true, Encoding.UTF8))
                    {
                        StreamReader sr2 = new StreamReader(@"C:\Users\hwwat\Documents\programing\C#\"+line+".txt");
                        {
                            var contents2 = sr2.ReadToEnd();
                            if(contents2.Contains("名詞"))
                            {

                            }
                                else
                                    {
                                        contents.WriteLine("#名詞");
                                        n++;
                                    }
                           
                            sr2.Close();
                        }

                        contents.Close();
                    }

                    // 拡張子を変更する
                    string newPath =
                          Path.ChangeExtension(newPath1, ".md");
                            File.Move(newPath1, newPath);


                    }

                }
            }
        }
    }
