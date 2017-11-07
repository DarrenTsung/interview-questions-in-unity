using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace InterviewQuestions.RotatedDictionary {
	public static class RotatedDictionary {
		// PRAGMA MARK - Public Interface
		// Some varient of binary search should work..
		public static int FindRotationPointIndex(string[] rotatedDictionary) {
			if (rotatedDictionary == null) {
				throw new ArgumentNullException();
			}

			int high = rotatedDictionary.Length - 1;
			int low = 0;

			// NOTE (darren): lowWord < highWord, assuming that the dictionary is
			// sorted in some order and only rotated, then the rotation was 0
			if (string.Compare(rotatedDictionary[low], rotatedDictionary[high]) < 0) {
				// rotation of 0 means rotation point is still at 0 index
				return 0;
			}

			while (high > low + 1) {
				string highWord = rotatedDictionary[high];

				int mid = (int)((high + low) / 2.0f);
				string midWord = rotatedDictionary[mid];

				// NOTE (darren): midWord < highWord
				if (string.Compare(midWord, highWord) < 0) {
					high = mid;
				} else {
					low = mid;
				}
			}

			return high;
		}
	}
}