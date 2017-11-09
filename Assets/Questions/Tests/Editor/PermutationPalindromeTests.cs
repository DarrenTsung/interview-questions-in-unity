using System;
using System.Collections;
using System.Collections.Generic;

using NUnit;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace InterviewQuestions.PermutationPalindrome {
	public static class PermutationPalindromeTests {
		[Test]
		public static void Check_HandlesBasicExample() {
			Assert.That(PermutationPalindrome.Check("civic"), Is.EqualTo(true));
		}

		[Test]
		public static void Check_HandlesMutatedExample() {
			Assert.That(PermutationPalindrome.Check("ciicv"), Is.EqualTo(true));
		}

		[Test]
		public static void Check_HandlesFalseExample() {
			Assert.That(PermutationPalindrome.Check("ciliv"), Is.EqualTo(false));
		}

		[Test]
		public static void Check_HandlesEvenNumberOfCharacters() {
			Assert.That(PermutationPalindrome.Check("cici"), Is.EqualTo(true));
		}

		[Test]
		public static void Check_HandlesNull() {
			Assert.Throws<ArgumentNullException>(() => PermutationPalindrome.Check(null));
		}

		[Test]
		public static void Check_HandlesInvalidStrings() {
			Assert.Throws<ArgumentException>(() => PermutationPalindrome.Check("ABCdef"));
		}
	}
}