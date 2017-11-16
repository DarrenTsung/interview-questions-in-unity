using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace InterviewQuestions.BinarySearch {
	public static class BinarySearch {
		// PRAGMA MARK - Public Interface
		public static int FindIndex(int[] array, int searchElement) {
			if (array == null) {
				throw new ArgumentNullException("Array must not be null!");
			}

			if (array.Length == 0) {
				return -1;
			}

			int high = array.Length - 1;
			int low = 0;

			if (array[high] == searchElement) {
				return high;
			} else if (array[low] == searchElement) {
				return low;
			}

			while (high > low + 1) {
				int mid = (int)((high + low) / 2);
				int midElement = array[mid];

				if (midElement > searchElement) {
					high = mid;
				} else if (midElement == searchElement) {
					return mid;
				} else {
					low = mid;
				}
			}

			return -1;
		}
	}
}