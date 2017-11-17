using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewQuestions.ZigZag {
	public class ZigZag {
		// Given: Convert("PAYPALPAYPAL", numberRows: 5)
		// Imagine that the text is rendered in zig zag like:
		//
		// P       Y
		// A     A P
		// Y   P   A
		// P L     L
		// A
		//
		// And return string that is read from left->right, top->bottom
		// "PYAAPYPAPLLA"
		public static string Convert(string input, int numberRows) {
			if (input == null) {
				throw new ArgumentNullException();
			}

			if (numberRows <= 0) {
				throw new ArgumentException("Number rows must be positive integer greater than 0!");
			}

			if (numberRows == 1) {
				return input;
			}

			StringBuilder zigZagged = new StringBuilder();

			// The pattern repeats after wrap
			int wrap = ((2 * numberRows) - 2);
			for (int n = 0; n < numberRows; n++) {
				for (int i = n; i < input.Length; i += wrap) {
					zigZagged.Append(input[i]);

					if (n != 0 && n != numberRows - 1) {
						// ie. for 01234321 as wrap then
						// for n = 1, reflected = 7
						int reflectedIndex = i + (wrap - (2 * n));
						if (reflectedIndex < input.Length) {
							zigZagged.Append(input[reflectedIndex]);
						}
					}
				}
			}

			return zigZagged.ToString();
		}
	}
}
