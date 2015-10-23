using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ParseLogFile
{
    public class FileParser
    {
        public List<RunStats> ParseFile(string filepath)
        {
            var runstats = new RunStats();
            PropertyInfo[] properties = typeof(RunStats).GetProperties();
            var runstatlist = new List<RunStats>();

            using (var sr = new StreamReader(filepath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line.Contains("Start Time: "))
                    {
                        runstats.StartTime = System.Convert.ToDateTime(line.Substring(line.IndexOf(@":", StringComparison.Ordinal) + 1).Trim());
                    }
                    if (line.Contains("End Time: "))
                    {
                        runstats.EndTime = System.Convert.ToDateTime(line.Substring(line.IndexOf(@":", StringComparison.Ordinal) + 1).Trim());
                    }
                    if (line.Contains("Begin DataStream"))
                    {
                        GetStartStop(line, runstats);
                    }
                    if (line.Contains("Algorithm Name:"))
                    {
                        runstats.AlgorithmName = line.Substring(line.IndexOf(@":", StringComparison.Ordinal) + 1).Trim();
                    }
                    if (line.Contains("Symbol:"))
                    {
                        runstats.Symbol = line.Substring(line.IndexOf(@":", StringComparison.Ordinal) + 1).Trim();
                    }
                    if (line.Contains("Ending Portfolio Value:"))
                    {
                        runstats.EndingPortfolioValue =
                            Convert.ToDecimal(line.Substring(line.IndexOf(@":", StringComparison.Ordinal) + 1).Trim());
                    }
                    if (line.Contains("STATISTICS::"))
                    {
                        string[] arr = line.Split(' ');
                        string propname = string.Empty;

                        // get the name from the line by replacing spaces and -
                        for (int i = 3; i < arr.Length - 1; i++)
                        {
                            propname += arr[i].Trim().Replace("-", "");
                        }

                        // Get the value from the line and convert to decimal
                        decimal propval = PropertyValueFromString(arr[arr.Length - 1]);

                        // Set the property value in runstats
                        SetPropertyValue(properties, propname, propval, ref runstats);

                        //// Used for development for creating the class
                        //GeneratePropertyStringForClass(propname);
                    }
                    if (line.Contains("Total Fees"))
                    {
                        runstatlist.Add(runstats);
                        runstats = new RunStats();
                    }
                }
            }
            return runstatlist;
        }

        private static void SetPropertyValue(PropertyInfo[] properties, string propname, decimal propval, ref RunStats runstats)
        {
            PropertyInfo p = properties.First(n => n.Name == propname);
            try
            {
                var setmethod = p.SetMethod;
                if (setmethod != null)
                    p.SetValue(runstats, propval);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Converts the property value string to a decimal.  It it contains a % sign divide by 100
        /// </summary>
        /// <param name="propvalstring">The property value string</param>
        /// <returns>The string converted to a decimal</returns>
        private static decimal PropertyValueFromString(string propvalstring)
        {
            string propertyValueString = propvalstring.Replace("$", string.Empty);       // treat as immutable
            if (propertyValueString.Contains("NaN"))
                return 0;
            
            if (propertyValueString.Contains("%"))
            {
                return Convert.ToDecimal(propertyValueString.Replace("%", string.Empty)) / 100;
            }
            return Convert.ToDecimal(propertyValueString);
        }

        private static void GetStartStop(string line, RunStats runstats)
        {
            int r = line.IndexOf("Start: ", StringComparison.Ordinal) + @"Start: ".Length;
            int t = line.IndexOf("Stop:", StringComparison.Ordinal);
            string start = line.Substring(r, t - r).Trim();
            runstats.Start = Convert.ToDateTime(start);
            string stop = line.Substring(t + @"Stop: ".Length);
            runstats.Stop = Convert.ToDateTime(stop);
        }

        /// <summary>
        ///  Helper method used in development
        /// </summary>
        /// <param name="propname">A property name</param>
        private static void GeneratePropertyStringForClass(string propname)
        {
            var sb = new StringBuilder();
            sb.Append("\t\t");
            sb.Append("public decimal ");
            sb.Append(propname);
            sb.Append(" {");
            sb.Append(@" get;");
            sb.Append(@" set;");
            sb.Append(" }");
            Debug.WriteLine(sb.ToString());
        }
    }
}