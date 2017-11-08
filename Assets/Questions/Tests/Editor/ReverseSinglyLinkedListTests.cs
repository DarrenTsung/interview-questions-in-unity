using System;
using System.Collections;
using System.Collections.Generic;

using NUnit;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

using InterviewQuestions.SinglyLinkedList;

namespace InterviewQuestions.ReverseSinglyLinkedList {
	public static class ReverseSinglyLinkedListTests {
		[Test]
		public static void ReverseInPlace_BasicExample_ReturnsExpected() {
			var head = SinglyLinkedListStringUtil.Create("1 2 3 4 5");
			var expectedHead = SinglyLinkedListStringUtil.Create("5 4 3 2 1");

			var newHead = ReverseSinglyLinkedList.ReverseInPlace(head);

			Assert.That(newHead, Is.EqualTo(expectedHead).Using(new SinglyLinkedListEqualityComparer()));
		}

		[Test]
		public static void ReverseInPlace_HandlesSingleElement() {
			var head = SinglyLinkedListStringUtil.Create("1");
			var expectedHead = SinglyLinkedListStringUtil.Create("1");

			var newHead = ReverseSinglyLinkedList.ReverseInPlace(head);

			Assert.That(newHead, Is.EqualTo(expectedHead).Using(new SinglyLinkedListEqualityComparer()));
		}

		[Test]
		public static void ReverseInPlace_HandlesNull() {
			Assert.Throws<ArgumentNullException>(() => ReverseSinglyLinkedList.ReverseInPlace(null));
		}
	}
}