using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace InterviewQuestions.MakingChange {
	public static class MakingChange {
		// Recursive solution
		public static int CountWaysToMakeChange(int amount, int[] denominations) {
			if (amount < 0) {
				throw new ArgumentException();
			}

			if (denominations == null) {
				throw new ArgumentNullException();
			}

			if (denominations.Any(d => d <= 0)) {
				throw new ArgumentException();
			}

			// return CountWaysToMakeChangeBottomUp(amount, denominations);
			return CountWaysToMakeChangeRecurse(amount, denominations, denominationUsed: int.MaxValue);
		}

		private static int CountWaysToMakeChangeBottomUp(int amount, int[] denominations) {
			int[] waysToMakeChange = new int[amount + 1];
			waysToMakeChange[0] = 1;

			foreach (int denomination in denominations) {
				for (int higherAmount = denomination; higherAmount <= amount; higherAmount++) {
					int higherAmountRemainder = higherAmount - denomination;
					waysToMakeChange[higherAmount] += waysToMakeChange[higherAmountRemainder];
				}
			}

			return waysToMakeChange[amount];
		}

		private static int CountWaysToMakeChangeRecurse(int amount, int[] denominations, int denominationUsed) {
			if (amount < 0) {
				return 0;
			} else if (amount == 0) {
				return 1;
			}

			int total = 0;
			foreach (int denomination in denominations) {
				if (denomination > denominationUsed) {
					continue;
				}

				total += CountWaysToMakeChangeRecurse(amount - denomination, denominations, denominationUsed: denomination);
			}
			return total;
		}
	}
}