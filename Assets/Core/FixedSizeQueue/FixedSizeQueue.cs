using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace InterviewQuestions.FixedSizeQueue {
	public class FixedSizeQueue<T> {
		// PRAGMA MARK - Public interface
		public FixedSizeQueue(int n) {
			values_ = new T[n];
		}

		public int Count {
			get { return validCount_; }
		}

		public void Enqueue(T obj) {
			values_[index_] = obj;
			index_ = (index_ + 1) % values_.Length;
			validCount_ = Math.Min(validCount_ + 1, values_.Length);
		}

		public T Dequeue() {
			index_ = (index_ - 1) % values_.Length;
			// wrap mod through negative numbers
			if (index_ < 0) {
				index_ += values_.Length;
			}

			T obj = values_[index_];

			if (validCount_ == 0) {
				// invalid - Dequeue without enough history
				Debug.LogWarning("FixedSizeQueue - too many Dequeues in a row, will not return correct value!");
			}
			validCount_ = Math.Max(validCount_ - 1, 0);

			return obj;
		}


		// PRAGMA MARK - Internal
		private T[] values_;
		private int index_ = 0;

		// NOTE (darren): used to keep track of how many valid elements exist in buffer
		// because Dequeue() invalidates elements in the buffer
		private int validCount_ = 0;
	}
}