﻿using System;

namespace ParseLogFile
{
    public class RunStats
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
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

        public static int CompareCompoundingAnnualReturn(RunStats r1, RunStats r2)
        {
            return r1.CompoundingAnnualReturn.CompareTo(r2.CompoundingAnnualReturn) * -1;
        }
        public static int CompareEndingPortfolioValue(RunStats r1, RunStats r2)
        {
            return r1.EndingPortfolioValue.CompareTo(r2.EndingPortfolioValue) * -1;
        }
    }
}
