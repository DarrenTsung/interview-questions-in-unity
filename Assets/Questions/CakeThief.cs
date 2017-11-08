using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace InterviewQuestions.CakeThief {
	public class CakeType {
		public int Weight { get; }
		public long Value { get; }

		public CakeType(int weight, long value) {
			Weight = weight;
			Value = value;
		}
	}

	public static class CafeThief {
		// PRAGMA MARK - Public Interface
		public static long MaxDuffelBagValue(CakeType[] cakeTypes, int capacity) {
			if (cakeTypes == null || cakeTypes.Length == 0) {
				throw new ArgumentException();
			}

			if (cakeTypes.Any(c => c.Weight < 0)) {
				throw new ArgumentException("CakeType with invalid weight!");
			}

			if (cakeTypes.Any(c => c.Weight == 0 && c.Value > 0)) {
				return long.MaxValue;
			}

			if (capacity <= 0) {
				return 0;
			}

			long[] dp = new long[capacity + 1];
			for (int i = 1; i <= capacity; i++) {
				foreach (var cakeType in cakeTypes) {
					if (cakeType.Weight > i) {
						continue;
					}

					dp[i] = Math.Max(dp[i], dp[i - cakeType.Weight] + cakeType.Value);
				}
			}

			return dp[capacity];
		}
	}
}