using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewQuestions.SinglyLinkedList {
	public static class SinglyLinkedListStringUtil {
		// Convert a string like "1 2 3 4 10"
		// to a SinglyLinkedList that looks like: [1]->[2]->[3]->[4]->[10]
		public static SinglyLinkedListNode Create(string listRepresentation) {
			if (string.IsNullOrEmpty(listRepresentation)) {
				throw new ArgumentException("listRepresentation is null or empty!");
			}

			string[] nodeRepresentations = listRepresentation.Split(' ');

			SinglyLinkedListNode head = Deserialize(nodeRepresentations[0]);

			SinglyLinkedListNode current = head;
			foreach (string nodeRepresentation in nodeRepresentations.Skip(1)) {
				SinglyLinkedListNode next = Deserialize(nodeRepresentation);
				current.Next = next;

				current = next;
			}

			return head;
		}

		private static SinglyLinkedListNode Deserialize(string s) {
			return new SinglyLinkedListNode(Int32.Parse(s));
		}
	}
}