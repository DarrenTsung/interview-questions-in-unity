using System;
using System.Collections;
using System.Collections.Generic;

using NUnit;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace InterviewQuestions.ProductOfOtherNumbers {
	public static class ProductOfOtherNumbersTests {
		[Test]
		public static void GetProductsOfAllIntsExceptAtIndex_BasicExample_ReturnsExpected() {
			Assert.That(ProductOfOtherNumbers.GetProductsOfAllIntsExceptAtIndex(new int[] { 1, 7, 3, 4 }), Is.EqualTo(new int[] { 84, 12, 28, 21 }));
		}

		[Test]
		public static void GetProductsOfAllIntsExceptAtIndex_HandlesNullCorrectly() {
			Assert.Throws<ArgumentNullException>(() => ProductOfOtherNumbers.GetProductsOfAllIntsExceptAtIndex(null));
		}

		[Test]
		public static void GetProductsOfAllIntsExceptAtIndex_HandlesOneValueCorrectly() {
			Assert.That(ProductOfOtherNumbers.GetProductsOfAllIntsExceptAtIndex(new int[] { 1 }), Is.EqualTo(new int[] { 1 }));
		}

		[Test]
		public static void GetProductsOfAllIntsExceptAtIndex_HandlesNegativesCorrectly() {
			Assert.That(ProductOfOtherNumbers.GetProductsOfAllIntsExceptAtIndex(new int[] { -1, -1, -1 }), Is.EqualTo(new int[] { 1, 1, 1 }));
		}

		[Test]
		public static void GetProductsOfAllIntsExceptAtIndex_HandlesZerosCorrectly() {
			Assert.That(ProductOfOtherNumbers.GetProductsOfAllIntsExceptAtIndex(new int[] { 1, 3, 0 }), Is.EqualTo(new int[] { 0, 0, 3 }));
		}
	}
}