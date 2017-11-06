using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

namespace InterviewQuestions.BinaryTree {
	// See representation (non-compact form) here: https://github.com/saguiitay/BackToBasics/wiki/BinaryTree-string-representation
	// TL;DR:
	// The following tree:
	//
	//                     1
	//                   /   \
	//                  2     3
	//                 / \     \
	//                4   5     0
	//               / \       /
	//              7   6     8
	// Can be saved as:
	//
	// "[1] [2 3] [4 5 * 0] [7 6 * * 8 * * *]" (brackets for organizational purposes)
	//
	public static class BinaryTreeStringUtil {
		private static readonly Regex bracketRegex = new Regex(@"(\[|\])");

		public static BinaryTreeNode Create(string treeRepresentation) {
			// Remove brackets from string
			treeRepresentation = bracketRegex.Replace(treeRepresentation, "");

			string[] treeNodeRepresentations = treeRepresentation.Split(' ');
			if (treeNodeRepresentations.Length <= 0) {
				Debug.LogWarning("Invalid treeRepresentation - no length!");
				return null;
			}

			BinaryTreeNode root = Deserialize(treeNodeRepresentations[0]);
			if (root == null) {
				Debug.LogWarning("Invalid treeRepresentation - no root!");
				return null;
			}

			Queue<BinaryTreeNode> nodesToFill = new Queue<BinaryTreeNode>();
			nodesToFill.Enqueue(root);

			// NOTE (darren): possible to do this with index instead of making queue
			Queue<string> treeNodeRepresentationsQueue = new Queue<string>(treeNodeRepresentations.Skip(1));
			while (nodesToFill.Count > 0 && treeNodeRepresentationsQueue.Count > 0) {
				BinaryTreeNode currentNode = nodesToFill.Dequeue();

				BinaryTreeNode left = Deserialize(treeNodeRepresentationsQueue.Dequeue());
				if (left != null) {
					if (currentNode == null) {
						Debug.LogWarning("Invalid treeRepresentation - valid node under invalid node! Node: " + left.Value + " || treeRepresentation: " + treeRepresentation);
						return null;
					}
					currentNode.InsertLeft(left);
				}

				if (treeNodeRepresentationsQueue.Count <= 0) {
					break;
				}

				BinaryTreeNode right = Deserialize(treeNodeRepresentationsQueue.Dequeue());
				if (right != null) {
					if (currentNode == null) {
						Debug.LogWarning("Invalid treeRepresentation - valid node under invalid node! Node: " + right.Value + " || treeRepresentation: " + treeRepresentation);
						return null;
					}
					currentNode.InsertRight(right);
				}

				nodesToFill.Enqueue(left);
				nodesToFill.Enqueue(right);
			}

			return root;
		}

		private static BinaryTreeNode Deserialize(string s) {
			try {
				return new BinaryTreeNode(Int32.Parse(s));
			} catch (Exception) {
				return null;
			}
		}
	}
}