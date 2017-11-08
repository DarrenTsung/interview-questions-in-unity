using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using InterviewQuestions.SinglyLinkedList;

namespace InterviewQuestions.ReverseSinglyLinkedList {
	public static class ReverseSinglyLinkedList {
		// PRAGMA MARK - Public Interface
		public static SinglyLinkedListNode ReverseInPlace(SinglyLinkedListNode head) {
			if (head == null) {
				throw new ArgumentNullException();
			}

			if (head.Next == null) {
				return head;
			}

			SinglyLinkedListNode previous = null;
			SinglyLinkedListNode current = head;
			while (current != null) {
				SinglyLinkedListNode next = current.Next;
				current.Next = previous;

				previous = current;
				current = next;
			}

			return previous;
		}
	}
}
