using System;
using System.Collections;
using System.Collections.Generic;

using NUnit;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace InterviewQuestions.MakingChange {
	public static class MakingChangeTests {
		[Test]
		public static void CountWaysToMakeChange_BasicExample_ReturnsExpected() {
			Assert.That(MakingChange.CountWaysToMakeChange(4, new int[] { 1, 2, 3 }), Is.EqualTo(4));
		}

		[Test]
		public static void CountWaysToMakeChange_HandlesNoWayToMakeChange() {
			Assert.That(MakingChange.CountWaysToMakeChange(7, new int[] { 3 }), Is.EqualTo(0));
		}

		[Test]
		public static void CountWaysToMakeChange_HandlesZeroDenomination() {
			Assert.Throws<ArgumentException>(() => MakingChange.CountWaysToMakeChange(4, new int[] { 0 }));
		}

		[Test]
		public static void CountWaysToMakeChange_HandlesNegativeDenomination() {
			Assert.Throws<ArgumentException>(() => MakingChange.CountWaysToMakeChange(4, new int[] { 1, 2, -3 }));
		}

		[Test]
		public static void CountWaysToMakeChange_HandlesNoDenominations() {
			Assert.That(MakingChange.CountWaysToMakeChange(4, new int[] {}), Is.EqualTo(0));
		}

		[Test]
		public static void CountWaysToMakeChange_HandlesNoDenominations_And_ZeroAmount() {
			Assert.That(MakingChange.CountWaysToMakeChange(0, new int[] {}), Is.EqualTo(1));
		}

		[Test]
		public static void CountWaysToMakeChange_HandlesNegativesCorrectly() {
			Assert.Throws<ArgumentException>(() => MakingChange.CountWaysToMakeChange(-2, null));
		}

		[Test]
		public static void CountWaysToMakeChange_HandlesNullCorrectly() {
			Assert.Throws<ArgumentNullException>(() => MakingChange.CountWaysToMakeChange(4, null));
		}
	}
}