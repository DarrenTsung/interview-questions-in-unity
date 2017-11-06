using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewQuestions.BinaryTree {
	public class BinaryTreeNode {
		public int Value { get; }
		public BinaryTreeNode Left { get; private set; }
		public BinaryTreeNode Right { get; private set; }

		public BinaryTreeNode(int value) {
			Value = value;
		}

		public BinaryTreeNode InsertLeft(int leftValue) {
			Left = new BinaryTreeNode(leftValue);
			return Left;
		}

		public BinaryTreeNode InsertLeft(BinaryTreeNode leftNode) {
			Left = leftNode;
			return Left;
		}

		public BinaryTreeNode InsertRight(int rightValue) {
			Right = new BinaryTreeNode(rightValue);
			return Right;
		}

		public BinaryTreeNode InsertRight(BinaryTreeNode rightNode) {
			Right = rightNode;
			return Right;
		}

		public override string ToString() {
			// Breadth-First: Print each level inside brackets.
			// Example:
			//                           1
			//                     /            \
			//                   2               3
			//                 /   \           /  \
			//                4     5        6      7
			// Prints out to:
			// [1] [2 3] [4 5 6 7]
			StringBuilder sb = new StringBuilder();

			List<BinaryTreeNode> currentLevel = new List<BinaryTreeNode>();
			currentLevel.Add(this);

			List<BinaryTreeNode> nextLevel = new List<BinaryTreeNode>();

			// NOTE (darren): check against all nulls to prevent last layer of null children
			while (currentLevel.Count > 0 && currentLevel.Any(node => node != null)) {
				sb.Append("[");
				sb.Append(string.Join(" ", currentLevel.Select(node => node == null ? "*" : node.Value.ToString()).ToArray()));
				sb.Append("]");

				foreach (var node in currentLevel) {
					if (node == null) {
						// fill with empties to always draw all nodes on level
						nextLevel.Add(null);
						nextLevel.Add(null);
					} else {
						nextLevel.Add(node.Left);
						nextLevel.Add(node.Right);
					}
				}

				// Swap lists
				List<BinaryTreeNode> temp = currentLevel;
				currentLevel = nextLevel;
				nextLevel = temp;

				nextLevel.Clear();
			}

			return sb.ToString();
		}
	}
}