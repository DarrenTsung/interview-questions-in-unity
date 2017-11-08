using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewQuestions.SinglyLinkedList {
	public class SinglyLinkedListEqualityComparer : IEqualityComparer<SinglyLinkedListNode> {
		// PRAGMA MARK - IEqualityComparer<SinglyLinkedListNode> Implementation
		// Convert a string like "1 2 3 4 10"
		// to a SinglyLinkedList that looks like: [1]->[2]->[3]->[4]->[10]
		public bool Equals(SinglyLinkedListNode a, SinglyLinkedListNode b) {
			while (a != null && b != null) {
				if (a.Value != b.Value) {
					return false;
				}

				a = a.Next;
				b = b.Next;
			}

			return a == null && b == null;
		}

		public int GetHashCode(SinglyLinkedListNode head) {
			int hashCode = 1;

			SinglyLinkedListNode current = head;
			while (current != null) {
				hashCode ^= current.Value;

				current = current.Next;
			}

			return hashCode;
		}
	}
}