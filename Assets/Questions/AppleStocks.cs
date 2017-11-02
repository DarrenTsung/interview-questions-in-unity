using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace InterviewQuestions.AppleStocks {
	public static class AppleStocks {
		// Find max profit given 1 buy + 1 sell
		// MUST buy one stock and sell one stock
		public static int GetMaxProfit(int[] stockPricesYesterday) {
			if (stockPricesYesterday == null) {
				throw new ArgumentNullException("stockPrices cannot be null!");
			}

			if (stockPricesYesterday.Length < 2) {
				throw new ArgumentException("Cannot have less than two stock prices, need to buy and sell at least once each!");
			}

			int lowestPrice = Math.Min(stockPricesYesterday[0], stockPricesYesterday[1]);
			int maxProfit = stockPricesYesterday[1] - stockPricesYesterday[0];

			foreach (int stockPrice in stockPricesYesterday.Skip(2)) {
				maxProfit = Math.Max(stockPrice - lowestPrice, maxProfit);
				lowestPrice = Math.Min(stockPrice, lowestPrice);
			}

			return maxProfit;
		}
	}
}