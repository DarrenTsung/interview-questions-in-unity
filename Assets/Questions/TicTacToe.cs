using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace InterviewQuestions.TicTacToe {
	public class TicTacToe : MonoBehaviour {
		private static List<string> board;
		private static string currentPlayer;
		private static string winner;

		private static int inputRow_;
		private static int inputCol_;

		private static TicTacToeAI ai_ = new TicTacToeAI();

		private void Awake() {
			StartCoroutine(PlayGameContinuously());
		}

		private IEnumerator PlayGameContinuously() {
			while (true) {
				newGame();
				yield return playGame();
			}
		}

		private static void newGame() {
			board = new List<string>(9);
			for (int i = 0; i < 9; i++) {
				board.Add(null);
			}
			currentPlayer = "X";
			winner = null;
			ai_.Cleanup();
		}

		private static IEnumerator playGame() {
			while (true) {
				printBoard();
				yield return completeTurn();

				calculateWinner();
				if (winner != null) {
					if (winner == "Tie") {
						Debug.Log("There was a tie!");
					} else {
						ai_.HandleResult(winner: winner == "O");
						Debug.Log(winner + " wins!");
					}
					break;
				}

				if (currentPlayer == "X") {
					currentPlayer = "O";
				} else {
					currentPlayer = "X";
				}
			}
		}

		private static IEnumerator completeTurn() {
			while (true) {
				int position;

				if (currentPlayer == "O") {
					position = ai_.ChoosePosition(board);
				} else {
					yield return askForTurn();

					// get the row / col and return row * 3 + col
					position = inputRow_ * 3 + inputCol_;

					inputRow_ = -1;
					inputCol_ = -1;
				}

				if (board[position] == null) {
					board[position] = currentPlayer;
					break;
				} else {
					Debug.Log("Invalid position - already filled!");
				}
			}
		}

		private static IEnumerator askForTurn() {
			Debug.Log("Enter row number: ");

			yield return GetInput(row: true);
			yield return null;
			yield return null;

			Debug.Log("Enter col number: ");
			yield return GetInput(row: false);
			yield return null;
			yield return null;
		}

		private static IEnumerator GetInput(bool row) {
			while (true) {
				int input = -1;
				if (Input.GetKeyDown(KeyCode.Alpha0)) {
					input = 0;
				} else if (Input.GetKeyDown(KeyCode.Alpha1)) {
					input = 1;
				} else if (Input.GetKeyDown(KeyCode.Alpha2)) {
					input = 2;
				}

				if (input >= 0) {
					if (row) {
						inputRow_ = input;
					} else {
						inputCol_ = input;
					}
					break;
				}

				yield return null;
			}
		}

		// [0, 1, 2, 3, 4, 5, 6, 7, 8]
		// row 0, col 2
		// 0 * 3 + 2
		//
		// [ 0  1  2 ]
		// [ 3  4  5 ]
		// [ 6  7  8 ]


		private static void calculateWinner() {
			if (winner != null) {
				return;
			}

			// check rows
			for (int row = 0; row < 3; row++) {
				for (int col = 0; col < 3; col++) {
					string player = board[row*3 + col];
					if (player == null) {
						winner = null;
						break;
					} else if (winner == null) {
						winner = player;
					} else if (player != winner) {
						winner = null;
						break;
					}
				}

				if (winner != null) {
					return;
				}
			}

			// [ O X O ]
			// winner = O
			// winner = null

			// check columns
			for (int col = 0; col < 3; col++) {
				for (int row = 0; row < 3; row++) {
					string player = board[row*3 + col];
					if (player == null) {
						winner = null;
						break;
					} else if (winner == null) {
						winner = player;
					} else if (player != winner) {
						winner = null;
						break;
					}
				}

				if (winner != null) {
					return;
				}
			}

			// Assertion: winner is null
			// check diagonal 1 - 0 4 8
			for (int row = 0; row < 3; row++) {
				string player = board[row*4];
				if (player == null) {
					winner = null;
					break;
				} else if (winner == null) {
					winner = player;
				} else if (player != winner) {
					winner = null;
					break;
				}
			}
			if (winner != null) return;

			// check diagonal 2 - 2 4 6
			for (int row = 0; row < 3; row++) {
				string player = board[row*2 + 2];
				if (player == null) {
					winner = null;
					break;
				} else if (winner == null) {
					winner = player;
				} else if (player != winner) {
					winner = null;
					break;
				}
			}
			if (winner != null) return;

			// check for tie
			bool allFilled = true;
			for (int row = 0; row < 3; row++) {
				for (int col = 0; col < 3; col++) {
					if (board[row * 3 + col] == null) {
						allFilled = false;
						break;
					}
				}
			}

			if (allFilled) {
				winner = "Tie";
				return;
			}
		}

		private static void printBoard() {
			for (int row = 0; row < 3; row++) {
				string first = board[row*3];
				string second = board[row*3 + 1];
				string third = board[row*3 + 2];
				first = first != null ? first : " ";
				second = second != null ? second : " ";
				third = third != null ? third : " ";

				string rowStr = string.Format("{0} | {1} | {2}", first, second, third);
				string divider = "---------";

				Debug.Log(rowStr);
				if (row < 2) {
					Debug.Log(divider);
				}
			}
		}
	}
}
