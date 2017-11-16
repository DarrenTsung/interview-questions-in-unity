using System;
using System.Collections;
using System.Collections.Generic;

using NUnit;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace InterviewQuestions.BinarySearch {
	public static class BinarySearchTests {
		[Test]
		public static void Search_EvenArray_ReturnsExpected() {
			Assert.That(BinarySearch.FindIndex(new int[] { 1, 4, 6, 9, 10 }, searchElement: 4), Is.EqualTo(1));
		}

		[Test]
		public static void Search_NotInArray_ReturnsNegativeOne() {
			Assert.That(BinarySearch.FindIndex(new int[] { 1, 4, 6, 9, 10 }, searchElement: 5), Is.EqualTo(-1));
		}

		[Test]
		public static void Search_NotInArray_BelowLow_ReturnsNegativeOne() {
			Assert.That(BinarySearch.FindIndex(new int[] { 1, 4, 6, 9, 10 }, searchElement: -10), Is.EqualTo(-1));
		}

		[Test]
		public static void Search_NotInArray_AboveHigh_ReturnsNegativeOne() {
			Assert.That(BinarySearch.FindIndex(new int[] { 1, 4, 6, 9, 10 }, searchElement: 200), Is.EqualTo(-1));
		}

		[Test]
		public static void Search_OddArray_ReturnsExpected() {
			Assert.That(BinarySearch.FindIndex(new int[] { 1, 4, 6, 10 }, searchElement: 6), Is.EqualTo(2));
		}

		[Test]
		public static void Search_OddArray_FirstElement_ReturnsExpected() {
			Assert.That(BinarySearch.FindIndex(new int[] { 1, 4, 6, 10 }, searchElement: 1), Is.EqualTo(0));
		}

		[Test]
		public static void Search_OddArray_LastElement_ReturnsExpected() {
			Assert.That(BinarySearch.FindIndex(new int[] { 1, 4, 6, 10 }, searchElement: 10), Is.EqualTo(3));
		}

		[Test]
		public static void Search_EvenArray_FirstElement_ReturnsExpected() {
			Assert.That(BinarySearch.FindIndex(new int[] { 1, 6, 10 }, searchElement: 1), Is.EqualTo(0));
		}

		[Test]
		public static void Search_EvenArray_LastElement_ReturnsExpected() {
			Assert.That(BinarySearch.FindIndex(new int[] { 1, 6, 10 }, searchElement: 10), Is.EqualTo(2));
		}

		[Test]
		public static void Search_HandlesDuplicates() {
			Assert.That(BinarySearch.FindIndex(new int[] { 1, 6, 6, 6, 6, 6, 10 }, searchElement: 10), Is.EqualTo(6));
		}

		[Test]
		public static void Search_FindsAnyIndex_FromDuplicates() {
			int indexFound = BinarySearch.FindIndex(new int[] { 1, 2, 3, 4, 6, 6, 10 }, searchElement: 6);
			Assert.That(indexFound == 4 || indexFound == 5, Is.EqualTo(true));
		}

		[Test]
		public static void Search_LargeArray_ReturnsExpected() {
			Assert.That(BinarySearch.FindIndex(new int[] { 1, 4, 5, 6, 10, 1000, 2000, 20020, 900000 }, searchElement: 4), Is.EqualTo(1));
		}

		[Test]
		public static void Search_EmptyArray_ReturnsExpected() {
			Assert.That(BinarySearch.FindIndex(new int[] { }, searchElement: 10), Is.EqualTo(-1));
		}

		[Test]
		public static void Search_NullArray_ThrowException() {
			Assert.Throws<ArgumentNullException>(() => BinarySearch.FindIndex(null, searchElement: 10));
		}
	}
}