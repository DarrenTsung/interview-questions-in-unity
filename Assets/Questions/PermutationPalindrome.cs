using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace InterviewQuestions.PermutationPalindrome {
	public static class PermutationPalindrome {
		// PRAGMA MARK - Public Interface
		public static bool Check(string s) {
			if (s == null) {
				throw new ArgumentNullException();
			}

			int[] charCounter = new int[26];

			foreach (char c in s) {
				int index = ConvertLowercaseCharToInt(c);
				if (index < 0 || index >= 26) {
					throw new ArgumentException("Input string must only contain lowercase characters!");
				}

				charCounter[index] = (charCounter[index] + 1) % 2;
			}

			bool stringEven = s.Length % 2 == 0;
			int sumExtraCharacters = charCounter.Sum();
			return stringEven ? sumExtraCharacters == 0 : sumExtraCharacters == 1;
		}


		// PRAGMA MARK - Internal
		private static int ConvertLowercaseCharToInt(char c) {
			return (int)c - (int)'a';
		}
	}
}