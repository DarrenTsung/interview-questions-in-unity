using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace InterviewQuestions.ZigZag {
	public static class ZigZagTests {
		[Test]
		public static void ZigZag_HandlesBasicExample() {
			Assert.That(ZigZag.Convert("PAYPALISHIRING", numberRows: 3), Is.EqualTo("PAHNAPLSIIGYIR"));
		}

		[Test]
		public static void ZigZag_HandlesSmallerRow() {
			// P Y A
			// A P L
			Assert.That(ZigZag.Convert("PAYPAL", numberRows: 2), Is.EqualTo("PYAAPL"));
		}

		[Test]
		public static void ZigZag_HandlesLargerRow() {
			// P       Y
			// A     A P
			// Y   P   A
			// P L     L
			// A
			Assert.That(ZigZag.Convert("PAYPALPAYPAL", numberRows: 5), Is.EqualTo("PYAAPYPAPLLA"));
		}

		[Test]
		public static void ZigZag_HandlesNullArgument() {
			Assert.Throws<ArgumentNullException>(() => ZigZag.Convert(null, numberRows: 0));
		}

		[Test]
		public static void ZigZag_HandlesInvalidNumberRows() {
			Assert.Throws<ArgumentException>(() => ZigZag.Convert("PAYPAL", numberRows: -10));
		}

		[Test]
		public static void ZigZag_HandlesOneRow() {
			Assert.That(ZigZag.Convert("PAYPALPAYPAL", numberRows: 1), Is.EqualTo("PAYPALPAYPAL"));
		}

		[Test]
		public static void ZigZag_HandlesSmallInput() {
			Assert.That(ZigZag.Convert("P", numberRows: 5), Is.EqualTo("P"));
		}
	}
}
