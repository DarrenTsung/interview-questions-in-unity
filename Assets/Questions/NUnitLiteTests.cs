/*
namespace NUnitLiteTests {
	using NUnitLite;
	using UnityEngine;
	using UnityEditor;
	using System;
	using InterviewQuestions.AppleStocks;
	using InterviewQuestions.GameOfStones;
	using InterviewQuestions.ProductOfOtherNumbers;

	[ExecuteInEditMode]
	[InitializeOnLoad]
	public static class NUnitLiteTests {
		static NUnitLiteTests() {
			TestRunner.RunAllTests(logCallback: (s) => UnityEngine.Debug.Log(s));
		}

		[Test]
		public static void GetMaxProfit_BasicExample_ReturnsExpected() {
			Assert.That(AppleStocks.GetMaxProfit(new int[] { 10, 7, 5, 8, 11, 9 }), Is.EqualTo(6));
		}

		[Test]
		public static void GetMaxProfit_HandlesInvalidArguments() {
			Assert.Throws<ArgumentNullException>(() => AppleStocks.GetMaxProfit(null));
		}

		[Test]
		public static void Solve_BasicExample_ReturnsExpected() {
			Assert.That(GameOfStones.Solve(1), Is.EqualTo(PlayerType.Second));
		}

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
		public static void GetProductsOfAllIntsExceptAtIndex_HandlesNegativesCorrectly_FAILS() {
			Assert.That(ProductOfOtherNumbers.GetProductsOfAllIntsExceptAtIndex(new int[] { -1, -1, -1 }), Is.EqualTo(new int[] { 2, 3, 1 }));
		}

		[Test]
		public static void GetProductsOfAllIntsExceptAtIndex_HandlesZerosCorrectly() {
			Assert.That(ProductOfOtherNumbers.GetProductsOfAllIntsExceptAtIndex(new int[] { 1, 3, 0 }), Is.EqualTo(new int[] { 0, 0, 3 }));
		}
	}
}
*/
