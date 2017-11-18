using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using NUnit;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace InterviewQuestions.CountIslands {
	public class CountIslandsTests {
		[Test]
		public static void Count_HandlesBasicCase() {
			Assert.That(CountIslands.Count(new int[,] {
				{ 0, 1, 1, 0 },
				{ 0, 0, 0, 0 }
			}), Is.EqualTo(1));
		}

		[Test]
		public static void Count_HandlesCase1() {
			Assert.That(CountIslands.Count(new int[,] {
				{ 0, 1, 1, 0 },
				{ 0, 1, 0, 0 },
				{ 0, 0, 0, 0 },
				{ 1, 0, 1, 0 },
			}), Is.EqualTo(3));
		}

		[Test]
		public static void Count_HandlesCase2() {
			Assert.That(CountIslands.Count(new int[,] {
				{ 0, 1, 1, 0 },
				{ 0, 1, 0, 0 },
				{ 0, 0, 0, 0 },
				{ 1, 1, 1, 0 },
			}), Is.EqualTo(2));
		}

		[Test]
		public static void Count_HandlesDiagonals() {
			Assert.That(CountIslands.Count(new int[,] {
				{ 0, 0, 1, 0 },
				{ 0, 1, 0, 0 },
				{ 0, 0, 0, 0 },
				{ 1, 1, 1, 0 },
			}), Is.EqualTo(3));
		}

		[Test]
		public static void Count_Handles1DGrid() {
			Assert.That(CountIslands.Count(new int[,] {
				{ 0, 1, 1, 0, 0, 0, 1, 1},
			}), Is.EqualTo(2));
		}

		[Test]
		public static void Count_HandlesSingleLand() {
			Assert.That(CountIslands.Count(new int[,] {
				{ 1 },
			}), Is.EqualTo(1));
		}

		[Test]
		public static void Count_HandlesAllWater() {
			Assert.That(CountIslands.Count(new int[,] {
				{ 0, 0, 0 },
				{ 0, 0, 0 },
				{ 0, 0, 0 },
			}), Is.EqualTo(0));
		}

		[Test]
		public static void Count_HandlesInvalidGrid() {
			Assert.Throws<ArgumentException>(() => CountIslands.Count(new int[,] {
				{ 0, 0, 0 },
				{ 0, 0, 2 },
				{ 0, 0, 0 },
			}));
		}

		[Test]
		public static void Count_HandlesNullGrid() {
			Assert.Throws<ArgumentNullException>(() => CountIslands.Count(null));
		}
	}
}