# ParseQCLogFile
<a href="https://github.com/QuantConnect/Lean">QuantConnect Lean Engine</a> outputs a file ..\Engine\bin\Debug\log.txt automatically each time you run a back test.  This program parses the statistics section into csv columnar format.

Usage: 

At a C:\ prompt 

	ParseLogFile {filepath}
	
The filepath for this version is hardcoded.  So clone the project and change the path in Program.Main to a file of your preference.

Otherwise you can supply the full file path, including the file name, on the command line.

## Output
The program will output a .csv file with statistics for each of the Lean runs in the file.  It picks up the the Start Date and End Date of your algorithm. The other columns are the lines in the file with the string "STATISTICS::" in the line.  

- The $ is dropped from Total Fees. 
- Percentages are changed to decimals: .06% becomes .0006.  
- NaN is changed to 0.
- I squeeze space and "-" out of the column names so the column names are ProperCase.

So you end up with a file you can open in Excel and see how different runs compare.  Lean does not overwrite the log.txt between runs.  It can get quite long and I got tired of running through the file looking for Compound Annual Return and the like.

I add the following method to my algorithm to give me some extra information in the log file, and this program picks these up and gives you a column in the csv file.  This way you can run different algorithms and see how they compare.  It is idiosynchratic to my programming and will probably be blank for you unless you include this method or some variation thereof.

<pre>
        public override void OnEndOfAlgorithm()
        {
            Debug(string.Format("\nAlgorithm Name: {0}\n Symbol: {1}\n Ending Portfolio Value: {2} \n",
			this.GetType().Name,
			symbol,
			Portfolio.TotalPortfolioValue));
        }
</pre>

This current version is intended to track only one symbol. If you are using multiple symbols you will need to change the string written in the above method to supply a list of symbol names you use in your algorithm.

###Licensing

This program is provided with an MIT license because I think it is open enough for you do whatever you please with it without bothering me.  If you come up with a bug or an improvement, I am a reasonable being and will listen to what you have to say through the github issues feature on this repo.  If it is a good suggestion, you can make a pull request and we will include your improvements.

###Warranty
This code was written in a few hours.  It is hardly even tested and is supplied without warranty or guarantees of any kind.  Run it at your own risk.  

QuantConnect has recently revised the statistics computations in Lean, so there is a decent change the log.txt fill will change.  Any changes my not be reflected in this program.

Remember, investing is risky and you can lose all your money.  Do not blame me if you do.

Nick Stein aka bizcad 10/18/2015