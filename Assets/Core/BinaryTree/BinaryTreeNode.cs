using System;
using System.Collections;

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
			string s = "";
			if (Left != null) {
				s += string.Format("{0} ", Left.ToString());
			}

			s += Value.ToString();

			if (Right != null) {
				s += string.Format(" {0}", Right.ToString());
			}

			return s;
		}
	}
}