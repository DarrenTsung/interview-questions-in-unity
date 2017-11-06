using System;
using System.Collections;
using System.Collections.Generic;

using NUnit;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

using InterviewQuestions.BinaryTree;

namespace InterviewQuestions.IsBinarySearchTree {
	public static class IsBinarySearchTreeTests {
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
		public static void IsBinarySearchTree_HandlesBasicValid() {
			var root = BinaryTreeStringUtil.Create("[4] [2 *] [1 3 * *]");
			Assert.That(IsBinarySearchTree.ValidateBinarySearchTree(root), Is.EqualTo(true));
		}

		[Test]
		public static void IsBinarySearchTree_HandlesBasicInvalid() {
			var root = BinaryTreeStringUtil.Create("[4] [2 *] [1 8 * *]");
			Assert.That(IsBinarySearchTree.ValidateBinarySearchTree(root), Is.EqualTo(false));
		}

		[Test]
		public static void IsBinarySearchTree_HandlesDeeperInvalid() {
			var root = BinaryTreeStringUtil.Create("[4] [1 *] [* 2 * *] [* * * 8 * * * *]");
			Assert.That(IsBinarySearchTree.ValidateBinarySearchTree(root), Is.EqualTo(false));
		}

		[Test]
		public static void IsBinarySearchTree_HandlesDeeperValid() {
			var root = BinaryTreeStringUtil.Create("[4] [1 *] [* 2 * *] [* * * 3 * * * *]");
			Assert.That(IsBinarySearchTree.ValidateBinarySearchTree(root), Is.EqualTo(true));
		}

		[Test]
		public static void IsBinarySearchTree_HandlesDuplicates() {
			var root = BinaryTreeStringUtil.Create("[4] [1 *] [* 2 * *] [* * 1 3 * * * *]");
			Assert.That(IsBinarySearchTree.ValidateBinarySearchTree(root), Is.EqualTo(false));
		}
	}
}