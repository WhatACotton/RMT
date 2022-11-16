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
            using (StreamWriter contents = new StreamWriter(@"C:\Users\hwwat\Documents\programing\C#\ankid.txt", false, Encoding.UTF8))
            {
                contents.WriteLine("");
                contents.Close();

            }
            StreamReader sr = new StreamReader(@"C:\Users\hwwat\Documents\重要__英語f.csv");
            {
                int num2 = 1;
                while (!sr.EndOfStream)
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
                    Console.Write(num2.ToString());
                    num2++;
                    Console.WriteLine("next");
                    string filename = lists[0];
                    string filename2 = filename.Replace(" ", "_");
                    if (
                        filename2.Contains("_" ) 
                        || filename2.Contains("-") 
                        || filename2.Contains("[") 
                        || filename2.Contains("）") 
                        || filename2.Contains("～") 
                        || filename2.Contains("］") 
                        || filename2.Contains("+") 
                        || filename2.Contains("\"") 
                        || filename2.Contains(",") 
                        || filename2.Contains("!") 
                        || filename2.Contains(".") 
                        || filename2.Contains(")")
                        || filename2.Contains("/")
                        || filename2.Contains("〜")
                        )
                    {
                       
                    }
                    else
                    {
                        string link = @"C:\Users\hwwat\Documents\programing\C#\ankid.txt";
                        using (StreamWriter contents = new StreamWriter(link, true, Encoding.UTF8))
                        {
                            string bun = filename2;
                            contents.WriteLine(bun);
                            contents.Close();

                        }
                    }
                    
                }


                    }

                }
            }
        }
