using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewQuestions.SinglyLinkedList {
	public class SinglyLinkedListNode {
		public int Value { get; }
		public SinglyLinkedListNode Next { get; set; }

		public SinglyLinkedListNode(int value) {
			Value = value;
		}

		public override string ToString() {
			StringBuilder sb = new StringBuilder();

			SinglyLinkedListNode current = this;
			while (current != null) {
				sb.Append(string.Format("[{0}]", current.Value));
				if (current.Next != null) {
					sb.Append("->");
				}

				current = current.Next;
			}

			return sb.ToString();
		}
	}
}