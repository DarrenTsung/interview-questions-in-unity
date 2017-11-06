using System;
using System.Collections;
using System.Linq;
using UnityEngine;

using InterviewQuestions.BinaryTree;
using InterviewQuestions.FixedSizeQueue;

namespace InterviewQuestions.NLargestElementInBinarySearchTree {
	public static class NLargestElementInBinarySearchTree {
		// PRAGMA MARK - Public Interface
		// Uses reverse in-order traversal to get the BinaryTreeNode
		// m = number of nodes in tree
		// Best case (balanced tree): O(log(m + n)) time, O(log(m)) space (due to stack)
		// Worst case (inbalanced tree): O(m) time, O(m) space (stack)
		public static BinaryTreeNode FindInOrder(BinaryTreeNode root, int n) {
			if (root == null) {
				throw new ArgumentNullException();
			}

			int counter = n;
			return FindInOrderRecurse(root, ref counter);
		}

		// Uses a fixed size queue in order to keep track of history
		// m = number of nodes in tree
		// Best case (balanced tree): O(log(m + n)) time, O(n) space
		// Worst case (inbalanced tree): O(m) time, O(n) space (stack)
		public static BinaryTreeNode FindQueue(BinaryTreeNode root, int n) {
			if (root == null) {
				throw new ArgumentNullException();
			}

			int counter = n;

			FixedSizeQueue<BinaryTreeNode> visited = new FixedSizeQueue<BinaryTreeNode>(n);
			BinaryTreeNode current = root;
			bool visitedRight = false;
			while (true) {
				while (current.Right != null && !visitedRight) {
					visited.Enqueue(current);
					current = current.Right;
				}

				if (counter == 1) {
					return current;
				} else {
					counter--;
					// backstep
					if (current.Left != null) {
						current = current.Left;
						visitedRight = false;
					} else {
						// ran out of nodes - not enough nodes in tree
						if (visited.Count <= 0) {
							return null;
						}

						current = visited.Dequeue();
						visitedRight = true;
					}
				}
			}
		}


		// PRAGMA MARK - Internal
		private static BinaryTreeNode FindInOrderRecurse(BinaryTreeNode node, ref int counter) {
			// Reverse in-order traversal
			if (node.Right != null) {
				var result = FindInOrderRecurse(node.Right, ref counter);
				if (result != null) {
					// found Nth largest element in right subtree
					return result;
				}
			}

			// visit current
			if (counter == 1) {
				return node;
			}
			counter--;

			if (node.Left != null) {
				var result = FindInOrderRecurse(node.Left, ref counter);
				if (result != null) {
					// found Nth largest element in left subtree
					return result;
				}
			}

			return null;
		}
	}
}