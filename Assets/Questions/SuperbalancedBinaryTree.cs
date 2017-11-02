using System;
using System.Collections;
using System.Linq;
using UnityEngine;

using InterviewQuestions.BinaryTree;

namespace InterviewQuestions.SuperbalancedBinaryTree {
	public static class SuperbalancedBinaryTree {
		public static bool IsSuperbalanced(BinaryTreeNode root) {
			if (root == null) {
				throw new ArgumentNullException();
			}

			// no children, superbalanced
			if (root.Left == null && root.Right == null) {
				return true;
			} else if (root.Right == null) {
				return IsSuperbalanced(root.Left);
			} else if (root.Left == null) {
				return IsSuperbalanced(root.Right);
			} else {
				return Math.Abs(root.Left.GetMaxDepth() - root.Right.GetMaxDepth()) <= 1;
			}
		}
	}

	public static class BinaryTreeExtensions {
		public static int GetMaxDepth(this BinaryTreeNode node, int depth = 1) {
			int maxDepth = depth;
			if (node.Left != null) {
				maxDepth = Math.Max(maxDepth, node.Left.GetMaxDepth(depth + 1));
			}

			if (node.Right != null) {
				maxDepth = Math.Max(maxDepth, node.Right.GetMaxDepth(depth + 1));
			}

			return maxDepth;
		}
	}
}