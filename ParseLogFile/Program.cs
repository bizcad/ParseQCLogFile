using System;
using System.IO;

namespace ParseLogFile
{
    public class Program
    {

        static void Main(string[] args)
        {
            string filepath = args.Length > 0 ? args[0] : @"C:\Users\Nick\Documents\Visual Studio 2013\Projects\LeanITrend\Engine\bin\Debug\log.txt";
            if (File.Exists(filepath))
            {
                var runstatlist = new FileParser().ParseFile(filepath);
                if (runstatlist != null)
                {
                    CsvFileWriter writer = new CsvFileWriter();
                    writer.Write(filepath, runstatlist);
                }
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
            Console.WriteLine("Press any key to finish");
            Console.ReadKey();
        }

        #region "Property Value setters"

        #endregion

        #region "Development Helper Methods"

        #endregion
    }
}
