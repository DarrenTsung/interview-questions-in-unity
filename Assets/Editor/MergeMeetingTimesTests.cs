using System;
using System.Collections;
using System.Collections.Generic;

using NUnit;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace InterviewQuestions.MergeMeetingTimes {
	public static class MergeMeetingTimesTests {
		[Test]
		public static void Merge_BasicExample_ReturnsExpected() {
			Assert.That(MergeMeetingTimes.Merge(new Meeting[] { new Meeting(0, 1), new Meeting(3, 5), new Meeting(4, 8), new Meeting(10, 12), new Meeting(9, 10) }), Is.EqualTo(new Meeting[] { new Meeting(0, 1), new Meeting(3, 8), new Meeting(9, 12) }));
		}

		[Test]
		public static void Merge_HandlesEnclosedMeetingTime() {
			Assert.That(MergeMeetingTimes.Merge(new Meeting[] { new Meeting(0, 1), new Meeting(3, 6), new Meeting(4, 5) }), Is.EqualTo(new Meeting[] { new Meeting(0, 1), new Meeting(3, 6) }));
		}

		[Test]
		public static void Merge_HandlesNegativeMeetingTimes() {
			Assert.That(MergeMeetingTimes.Merge(new Meeting[] { new Meeting(-3, 1), new Meeting(3, 5), new Meeting(4, 8), new Meeting(-2, -1) }), Is.EqualTo(new Meeting[] { new Meeting(-3, 1), new Meeting(3, 8) }));
		}

		[Test]
		public static void Merge_HandlesMultipleMerges() {
			Assert.That(MergeMeetingTimes.Merge(new Meeting[] { new Meeting(-3, 3), new Meeting(3, 5), new Meeting(4, 8), new Meeting(-2, -1) }), Is.EqualTo(new Meeting[] { new Meeting(-3, 8) }));
		}

		[Test]
		public static void Merge_HandlesNullCorrectly() {
			Assert.Throws<ArgumentNullException>(() => MergeMeetingTimes.Merge(null));
		}
	}
}