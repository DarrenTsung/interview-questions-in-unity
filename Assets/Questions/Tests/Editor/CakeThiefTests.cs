using System;
using System.Collections;
using System.Collections.Generic;

using NUnit;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace InterviewQuestions.CakeThief {
	public static class CakeThiefTests {
		[Test]
		public static void MaxDuffelBagValue_BasicExample_ReturnsExpected() {
			Assert.That(CafeThief.MaxDuffelBagValue(new CakeType[] {
				new CakeType(weight: 7, value: 160),
				new CakeType(weight: 3, value: 90),
				new CakeType(weight: 2, value: 15),
			}, capacity: 20), Is.EqualTo(555));
		}

		[Test]
		public static void MaxDuffelBagValue_HandlesNonGreedy() {
			Assert.That(CafeThief.MaxDuffelBagValue(new CakeType[] {
				new CakeType(weight: 11, value: 12),
				new CakeType(weight: 10, value: 10),
			}, capacity: 20), Is.EqualTo(20));
		}

		[Test]
		public static void MaxDuffelBagValue_HandlesZeroWeight() {
			Assert.That(CafeThief.MaxDuffelBagValue(new CakeType[] {
				new CakeType(weight: 0, value: 12),
				new CakeType(weight: 10, value: 10),
			}, capacity: 20), Is.EqualTo(long.MaxValue));
		}

		[Test]
		public static void MaxDuffelBagValue_HandlesZeroWeightZeroValue() {
			Assert.That(CafeThief.MaxDuffelBagValue(new CakeType[] {
				new CakeType(weight: 0, value: 0),
				new CakeType(weight: 10, value: 10),
			}, capacity: 20), Is.EqualTo(20));
		}
	}
}