using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace InterviewQuestions.ProductOfOtherNumbers {
	public static class ProductOfOtherNumbers {
		public static int[] GetProductsOfAllIntsExceptAtIndex(int[] input) {
			if (input == null) {
				throw new ArgumentNullException();
			}

			int[] finalProducts = new int[input.Length];

			int productSoFar = 1;
			for (int i = 0; i < input.Length; i++) {
				finalProducts[i] = productSoFar;
				productSoFar *= input[i];
			}

			productSoFar = 1;
			for (int i = input.Length - 1; i >= 0; i--) {
				finalProducts[i] *= productSoFar;
				productSoFar *= input[i];
			}

			return finalProducts;
		}
	}
}