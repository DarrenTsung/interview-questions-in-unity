using System;
using System.Collections;
using System.Collections.Generic;

using NUnit;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace InterviewQuestions.RectangularLove {
	public static class RectangularLoveTests {
		[Test]
		public static void GetIntersection_BasicExample_ReturnsExpected() {
			Assert.That(RectangularLove.GetIntersection(new Rectangle(1, 1, 2, 2), new Rectangle(2, 2, 2, 2)), Is.EqualTo(new Rectangle(2, 2, 1, 1)));
		}

		[Test]
		public static void GetIntersection_HandlesNullCorrectly() {
			Assert.Throws<ArgumentNullException>(() => RectangularLove.GetIntersection(null, null));
		}

		[Test]
		public static void GetIntersection_NoOverlap_ReturnsExpected() {
			Assert.That(RectangularLove.GetIntersection(new Rectangle(1, 1, 2, 2), new Rectangle(4, 4, 2, 2)), Is.EqualTo(null));
		}

		[Test]
		public static void GetIntersection_TouchingOverlap_ReturnsExpected() {
			Assert.That(RectangularLove.GetIntersection(new Rectangle(1, 1, 2, 2), new Rectangle(3, 3, 2, 2)), Is.EqualTo(null));
		}

		[Test]
		public static void GetIntersection_Enclosed_ReturnsExpected() {
			Assert.That(RectangularLove.GetIntersection(new Rectangle(1, 1, 3, 3), new Rectangle(2, 2, 2, 2)), Is.EqualTo(new Rectangle(2, 2, 2, 2)));
		}

		[Test]
		public static void GetIntersection_HandlesNegativesCorrectly() {
			Assert.That(RectangularLove.GetIntersection(new Rectangle(-2, -2, 2, 2), new Rectangle(-1, -1, 2, 2)), Is.EqualTo(new Rectangle(-1, -1, 1, 1)));
		}
	}
}