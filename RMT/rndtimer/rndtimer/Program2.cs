using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace csv作る
{
    class Program
    {
        static void Main(string[] args)
        {
            string src = @"C:\Users\hwwat\Documents\重要__英語__1f" + ".txt";

            StreamReader sr = new StreamReader(src);
            while (!sr.EndOfStream)
            {

                string line = sr.ReadLine();
                string[] values = line.Split('\t');
                List<string> lists = new List<string>();
                lists.AddRange(values);
                string[] column = line.Split(',');
                Console.WriteLine(column);
                string link = src + ".csv";
                using (FileStream fs = File.Create(link))
                {
                    fs.Close();
                }
                using (StreamWriter contents = new StreamWriter(link, false, Encoding.UTF8))
                {
                    contents.WriteLine(column);
                }
            }
        }
    }
}
