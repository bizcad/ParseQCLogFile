# ParseQCLogFile
Parses into csv a QuantConnect log.txt which is output automatically by the Open Source version of the QuantConnect Lean Engine.

Usage: 
	ParseLogFile {filepath}
	
The filepath for this version is hardcoded.  So clone the project and change the path in Program.Main to a file of your preference.

Otherwise you can supply the full file path, including the file name, on the command line.

# Output
The program will output a .csv file with the Start Date and End Date of the algorithm's back test.  The other columns are the lines in the file with the string STATISTICS:: in a line.  

So you end up with a file you can open in Excel and see how different runs compare.  Lean does not overwrite the log.txt between runs.  It can get quite long and I got tired of running through the file looking for CAR and the like.

I add the following method to my algorithm to give me some extra information in the log file, and this program picks these up and gives me a column in the csv file.  This way I can run different algorithms and see how they compare.

<code>
        public override void OnEndOfAlgorithm()
        {
            Debug(string.Format("\nAlgorithm Name: {0}\n Symbol: {1}\n Ending Portfolio Value: {2} \n",
			this.GetType().Name,
			symbol,
			Portfolio.TotalPortfolioValue));
        }
</code>

This current version is intended to track only one symbol. If you are using multiple symbols you will need to change the string written in the above method to supply a list of symbol names you use in your algorithm.

#Licensing

This program is provided with an MIT license because I think it is open enough for you do whatever you please with it without bothering me.  If you come up with a bug or an improvement I am a reasonable being and will listen to what you have to say through the issues feature of github.  If it is a good suggestion, you can make a pull request and we will include your improvements.

This code is hardly even tested and is supplied without warranty or guarantees of any kind.  Run it at your own risk.  Remember, investing is risky and you can lose all your money.  Do not blame me if you do.