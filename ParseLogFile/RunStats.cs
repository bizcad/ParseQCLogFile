using System;

namespace ParseLogFile
{
    public class RunStats
    {
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public string AlgorithmName { get; set; }
        public string Symbol { get; set; }
        public decimal EndingPortfolioValue { get; set; }
        public decimal TotalTrades { get; set; }
        public decimal AverageWin { get; set; }
        public decimal AverageLoss { get; set; }
        public decimal CompoundingAnnualReturn { get; set; }
        public decimal Drawdown { get; set; }
        public decimal Expectancy { get; set; }
        public decimal NetProfit { get; set; }
        public decimal SharpeRatio { get; set; }
        public decimal LossRate { get; set; }
        public decimal WinRate { get; set; }
        public decimal ProfitLossRatio { get; set; }
        public decimal Alpha { get; set; }
        public decimal Beta { get; set; }
        public decimal AnnualStandardDeviation { get; set; }
        public decimal AnnualVariance { get; set; }
        public decimal InformationRatio { get; set; }
        public decimal TrackingError { get; set; }
        public decimal TreynorRatio { get; set; }
        public decimal TotalFees { get; set; }        
    }
}
