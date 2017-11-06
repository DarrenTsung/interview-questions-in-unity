using System;
using System.Collections;
using System.Collections.Generic;

using NUnit;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

using InterviewQuestions.BinaryTree;

namespace InterviewQuestions.SuperbalancedBinaryTree {
	public static class SuperbalancedBinaryTreeTests {
		// The following tree:
		//                           1
		//                     /            \
		//                   2               3
		//                 /   \           /  \
		//                4     5        6      7
		//               / \   /  \    /  \    /  \
		//              8  9  10  11  12  13  14  15
		//
		// Maps to:
		// "1 2 3 4 5 6 7 8 9 10 11 12 13 14 15"
		// Any * means that node does not exist
		[Test]
		public static void IsSuperbalanced_BasicExample_ReturnsExpected() {
			var root = BinaryTreeStringUtil.Create("[1] [2 3] [4 5 6 7]");
			Assert.That(SuperbalancedBinaryTree.IsSuperbalanced(root), Is.EqualTo(true));
		}

		[Test]
		public static void IsSuperbalanced_HandlesNullCorrectly() {
			Assert.Throws<ArgumentNullException>(() => SuperbalancedBinaryTree.IsSuperbalanced(null));
		}

		[Test]
		public static void IsSuperbalanced_HandlesNoChildrenCorrectly() {
			var root = BinaryTreeStringUtil.Create("[1]");
			Assert.That(SuperbalancedBinaryTree.IsSuperbalanced(root), Is.EqualTo(true));
		}

		[Test]
		public static void IsSuperbalanced_HandlesSingleBranchCorrectly() {
			var root = BinaryTreeStringUtil.Create("[1] [2 *] [4 * * *]");
			Assert.That(SuperbalancedBinaryTree.IsSuperbalanced(root), Is.EqualTo(true));
		}

		[Test]
		public static void IsSuperbalanced_HandlesInbalanceCorrectly() {
			var root = BinaryTreeStringUtil.Create("[1] [2 3] [4 * * *] [8 * * * * * * *]");
			Assert.That(SuperbalancedBinaryTree.IsSuperbalanced(root), Is.EqualTo(false));
		}

		[Test]
		public static void IsSuperbalanced_HandlesDeepInbalanceCorrectly() {
			var root = BinaryTreeStringUtil.Create("[1] [2 *] [4 5 * *] [8 * * * * * * *] [16]");
			Assert.That(SuperbalancedBinaryTree.IsSuperbalanced(root), Is.EqualTo(false));
		}

		[Test]
		public static void IsSuperbalanced_HandlesDeepInbalance2Correctly() {
			var root = BinaryTreeStringUtil.Create("[1] [2 3] [4 * * 7] [8 * * * * * * *] [16]");
			Assert.That(SuperbalancedBinaryTree.IsSuperbalanced(root), Is.EqualTo(false));
		}
	}
}