using System;
using System.Collections;
using System.Collections.Generic;

using NUnit;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace InterviewQuestions.RotatedDictionary {
	public static class RotatedDictionaryTests {
		[Test]
		public static void FindRotationPointIndex_BasicExample_ReturnsExpected() {
			Assert.That(RotatedDictionary.FindRotationPointIndex(new string[] {
				"ptolemaic",
				"retrograde",
				"supplant",
				"undulate",
				"xenoepist",
				"asymptote", // <-- rotates here!
				"babka",
				"banoffee",
				"engender",
				"karpatka",
				"othellolagkage",
			}), Is.EqualTo(5));
		}

		[Test]
		public static void FindRotationPointIndex_HandlesNullArgument() {
			Assert.Throws<ArgumentNullException>(() => RotatedDictionary.FindRotationPointIndex(null));
		}

		[Test]
		public static void FindRotationPointIndex_HandlesSmallEven() {
			Assert.That(RotatedDictionary.FindRotationPointIndex(new string[] {
				"xenoepist",
				"asymptote", // <-- rotates here!
			}), Is.EqualTo(1));
		}

		[Test]
		public static void FindRotationPointIndex_HandlesSmallOdd() {
			Assert.That(RotatedDictionary.FindRotationPointIndex(new string[] {
				"xenoepist",
				"asymptote", // <-- rotates here!
				"babka",
			}), Is.EqualTo(1));
		}

		[Test]
		public static void FindRotationPointIndex_HandlesSingle() {
			Assert.That(RotatedDictionary.FindRotationPointIndex(new string[] {
				"asymptote", // <-- rotates here!
			}), Is.EqualTo(0));
		}

		[Test]
		public static void FindRotationPointIndex_HandlesRotationPointAtEnd() {
			Assert.That(RotatedDictionary.FindRotationPointIndex(new string[] {
				"ptolemaic",
				"retrograde",
				"supplant",
				"undulate",
				"xenoepist",
				"asymptote", // <-- rotates here!
			}), Is.EqualTo(5));
		}

		[Test]
		public static void FindRotationPointIndex_HandlesRotationPointAtBeginning() {
			Assert.That(RotatedDictionary.FindRotationPointIndex(new string[] {
				"asymptote", // <-- rotates here!
				"babka",
				"banoffee",
				"engender",
				"karpatka",
				"othellolagkage",
			}), Is.EqualTo(0));
		}
	}
}