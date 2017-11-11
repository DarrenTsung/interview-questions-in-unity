using System;
using System.Collections;
using System.Collections.Generic;

using NUnit;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace InterviewQuestions.GameOfStones {
	public static class GameOfStonesTests {
		[Test]
		public static void Solve_BasicExample_ReturnsExpected() {
			Assert.That(GameOfStones.Solve(1), Is.EqualTo(PlayerType.Second));
		}

		[Test]
		public static void Solve_Handles2StoneGame() {
			Assert.That(GameOfStones.Solve(2), Is.EqualTo(PlayerType.First));
		}

		[Test]
		public static void Solve_Handles3StoneGame() {
			Assert.That(GameOfStones.Solve(3), Is.EqualTo(PlayerType.First));
		}

		[Test]
		public static void Solve_Handles4StoneGame() {
			Assert.That(GameOfStones.Solve(4), Is.EqualTo(PlayerType.First));
		}

		[Test]
		public static void Solve_Handles5StoneGame() {
			Assert.That(GameOfStones.Solve(5), Is.EqualTo(PlayerType.First));
		}

		[Test]
		public static void Solve_Handles6StoneGame() {
			Assert.That(GameOfStones.Solve(6), Is.EqualTo(PlayerType.First));
		}

		[Test]
		public static void Solve_Handles7StoneGame() {
			Assert.That(GameOfStones.Solve(7), Is.EqualTo(PlayerType.Second));
		}

		[Test]
		public static void Solve_Handles10StoneGame() {
			Assert.That(GameOfStones.Solve(10), Is.EqualTo(PlayerType.First));
		}
	}
}