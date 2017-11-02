using System;
using System.Collections;
using System.Collections.Generic;

using NUnit;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace InterviewQuestions.AppleStocks {
	public static class AppleStocksTests {
		[Test]
		public static void GetMaxProfit_BasicExample_ReturnsExpected() {
			Assert.That(AppleStocks.GetMaxProfit(new int[] { 10, 7, 5, 8, 11, 9 }), Is.EqualTo(6));
		}

		[Test]
		public static void GetMaxProfit_HandlesInvalidArguments() {
			Assert.Throws<ArgumentNullException>(() => AppleStocks.GetMaxProfit(null));
		}

		[Test]
		public static void GetMaxProfit_HandlesNotEnoughStockPrices() {
			Assert.Throws<ArgumentException>(() => AppleStocks.GetMaxProfit(new int[0]));
			Assert.Throws<ArgumentException>(() => AppleStocks.GetMaxProfit(new int[] { 1 }));
		}

		[Test]
		public static void GetMaxProfit_MustBuyAndSellStock() {
			Assert.That(AppleStocks.GetMaxProfit(new int[] { 1, 0 }), Is.EqualTo(-1));
		}

		[Test]
		public static void GetMaxProfit_MustBuyAndSellStock_Cont() {
			Assert.That(AppleStocks.GetMaxProfit(new int[] { 5, -2, -3 }), Is.EqualTo(-1));
		}

		[Test]
		public static void GetMaxProfit_RespectsTime() {
			Assert.That(AppleStocks.GetMaxProfit(new int[] { 15, 1, 5 }), Is.EqualTo(4));
		}
	}
}