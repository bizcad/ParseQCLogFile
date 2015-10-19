using System;
using System.Collections.Generic;
using System.IO;

namespace ParseLogFile
{
    public class CsvFileWriter
    {
        public void Write(string filepath, List<RunStats> statsList )
        {
            Comparison<RunStats> compEPV = new Comparison<RunStats>(RunStats.CompareEndingPortfolioValue);
            statsList.Sort(compEPV);
            string path = filepath.Replace(".txt", ".csv");
            var stringlist = CsvSerializer.Serialize(",", statsList);
            using (var sw = new StreamWriter(path))
            {
                foreach (var s in stringlist)
                {
                    sw.WriteLine(s);
                }
                sw.Flush();
                sw.Close();
            }
            Console.WriteLine("File written: {0}\n", path);
        }
    }
}
