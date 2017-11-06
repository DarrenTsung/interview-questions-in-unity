using System;
using System.Collections;
using System.Linq;
using UnityEngine;

using InterviewQuestions.BinaryTree;

namespace InterviewQuestions.IsBinarySearchTree {
	public static class IsBinarySearchTree {
		public static bool ValidateBinarySearchTree(BinaryTreeNode root) {
			if (root == null) {
				throw new ArgumentNullException();
			}

			return ValidateBinarySearchTreeRecurse(root);
		}

		// Values are non-inclusive according to the definition of a binary search tree
		private static bool ValidateBinarySearchTreeRecurse(BinaryTreeNode node, int minValue = int.MinValue, int maxValue = int.MaxValue) {
			// This is only valid when used in a recursive context
			if (node == null) {
				return true;
			}

			// not valid binary search tree if doesn't follow parent values
			if (node.Value <= minValue || node.Value >= maxValue) {
				return false;
			}

			// going into the left node, we must clamp the max value (left nodes must be less than value)
			if (!ValidateBinarySearchTreeRecurse(node.Left, minValue, Math.Min(maxValue, node.Value))) {
				return false;
			}

			if (!ValidateBinarySearchTreeRecurse(node.Right, Math.Max(minValue, node.Value), maxValue)) {
				return false;
			}

			// if both nodes validate, then this is a valid binary search tree
			return true;
		}
	}
}