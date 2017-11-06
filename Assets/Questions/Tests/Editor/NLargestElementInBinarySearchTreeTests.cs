using System;
using System.Collections;
using System.Collections.Generic;

using NUnit;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

using InterviewQuestions.BinaryTree;

namespace InterviewQuestions.NLargestElementInBinarySearchTree {
	public static class NLargestElementInBinarySearchTreeTests {
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
		// "[1] [2 3] [4 5 6 7] [8 9 10 11 12 13 14 15]" (brackets for organizational purposes)
		// Any * means that node does not exist
		[Test]
		public static void NLargestElementInBinarySearchTree_HandlesNormal() {
			var root = BinaryTreeStringUtil.Create("[4] [2 6] [1 3 5 7]");
			Assert.That(NLargestElementInBinarySearchTree.FindInOrder(root, 2).Value, Is.EqualTo(6));
			Assert.That(NLargestElementInBinarySearchTree.FindQueue(root, 2).Value, Is.EqualTo(6));
		}

		[Test]
		public static void NLargestElementInBinarySearchTree_HandlesNormal2() {
			var root = BinaryTreeStringUtil.Create("[4] [2 6] [1 3 5 7]");
			Assert.That(NLargestElementInBinarySearchTree.FindInOrder(root, 4).Value, Is.EqualTo(4));
			Assert.That(NLargestElementInBinarySearchTree.FindQueue(root, 4).Value, Is.EqualTo(4));
		}

		[Test]
		public static void NLargestElementInBinarySearchTree_HandlesLeftTree() {
			var root = BinaryTreeStringUtil.Create("[4] [2 *] [1 3 * *]");
			Assert.That(NLargestElementInBinarySearchTree.FindInOrder(root, 2).Value, Is.EqualTo(3));
			Assert.That(NLargestElementInBinarySearchTree.FindQueue(root, 2).Value, Is.EqualTo(3));
		}

		[Test]
		public static void NLargestElementInBinarySearchTree_HandlesLeftTree2() {
			var root = BinaryTreeStringUtil.Create("[4] [2 *] [1 3 * *]");
			Assert.That(NLargestElementInBinarySearchTree.FindInOrder(root, 3).Value, Is.EqualTo(2));
			Assert.That(NLargestElementInBinarySearchTree.FindQueue(root, 3).Value, Is.EqualTo(2));
		}

		[Test]
		public static void NLargestElementInBinarySearchTree_HandlesDeepTree() {
			var root = BinaryTreeStringUtil.Create("[8] [4 12] [2 6 10 14] [1 3 5 7 9 11 13 15]");
			Assert.That(NLargestElementInBinarySearchTree.FindInOrder(root, 5).Value, Is.EqualTo(11));
			Assert.That(NLargestElementInBinarySearchTree.FindQueue(root, 5).Value, Is.EqualTo(11));
		}

		[Test]
		public static void NLargestElementInBinarySearchTree_HandlesShallowTree() {
			var root = BinaryTreeStringUtil.Create("[2] [1 3]");
			Assert.That(NLargestElementInBinarySearchTree.FindInOrder(root, 3).Value, Is.EqualTo(1));
			Assert.That(NLargestElementInBinarySearchTree.FindQueue(root, 3).Value, Is.EqualTo(1));
		}

		[Test]
		public static void NLargestElementInBinarySearchTree_HandlesShallowTree2() {
			var root = BinaryTreeStringUtil.Create("[2] [1 3]");
			Assert.That(NLargestElementInBinarySearchTree.FindInOrder(root, 2).Value, Is.EqualTo(2));
			Assert.That(NLargestElementInBinarySearchTree.FindQueue(root, 2).Value, Is.EqualTo(2));
		}

		[Test]
		public static void NLargestElementInBinarySearchTree_HandlesTreeWithNotEnoughNodes() {
			var root = BinaryTreeStringUtil.Create("[2] [1 3]");
			Assert.That(NLargestElementInBinarySearchTree.FindInOrder(root, 4), Is.EqualTo(null));
			Assert.That(NLargestElementInBinarySearchTree.FindQueue(root, 4), Is.EqualTo(null));
		}

		[Test]
		public static void NLargestElementInBinarySearchTree_HandlesNullRoot() {
			Assert.Throws<ArgumentNullException>(() => NLargestElementInBinarySearchTree.FindInOrder(null, 2));
			Assert.Throws<ArgumentNullException>(() => NLargestElementInBinarySearchTree.FindQueue(null, 2));
		}
	}
}