using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace InterviewQuestions.TicTacToe {
	public class TicTacToeAI {
		// static int GetHash(List<string> board)
		// static int GetHash(List<string> board, int position, string newValue)
		//
		// Dictionary<int /* Board Hash */, int> boardHashScores
		// HashSet<int> boardHashesSeenThisGame
		private static readonly Dictionary<int, int> boardHashScores_ = new Dictionary<int, int>();
		private string kAIPlayer = "O";

		private static int GetScoreForBoardHash(int boardHash) {
			if (!boardHashScores_.ContainsKey(boardHash)) {
				return 0;
			}
			return boardHashScores_[boardHash];
		}

		private static int GetHash(List<string> board) {
			return GetHash(board.Count, (pos) => {
				return board[pos];
			});
		}

		private static int GetHash(List<string> board, int position, string newValue) {
			return GetHash(board.Count, (pos) => {
				if (pos == position) {
					return newValue;
				} else {
					return board[pos];
				}
			});
		}

		private static int GetHash(int boardLength, Func<int, string> boardValueTransformation) {
			int hash = 0;
			for (int i = 0; i < boardLength; i++) {
				string boardValue = boardValueTransformation.Invoke(i);
				hash += GetStringValue(boardValue) * (int)Mathf.Pow(10, i);
				// board [ O, X, null ]
				//         2, 3,  1
				//         2, 30, 100  == 121
			}
			return hash;
		}

		private static int GetStringValue(string boardPositionString) {
			if (boardPositionString == null) {
				return 1;
			} else if (boardPositionString == "O") {
				return 2;
			} else if (boardPositionString == "X") {
				return 3;
			} else {
				Debug.LogWarning("Invalid string for position in board: " + boardPositionString);
				return 4;
			}
		}


		public void HandleResult(bool winner) {
			int scoreChange = winner ? 1 : -1;
			foreach (int boardHash in boardsSeen_) {
				boardHashScores_[boardHash] = GetScoreForBoardHash(boardHash) + scoreChange;
			}
		}

		public void Cleanup() {
			boardsSeen_.Clear();
		}

		public int ChoosePosition(List<string> board) {
			int? bestScore = null;
			int? bestPosition = null;
			foreach (int validPosition in ValidPositionsFromBoard(board)) {
				int newBoardHash = GetHash(board, validPosition, kAIPlayer);
				int score = GetScoreForBoardHash(newBoardHash);

				if ((bestScore == null || bestPosition == null) || (bestScore.Value < score)) {
					bestPosition = validPosition;
					bestScore = score;
				}
			}

			if (bestPosition == null) {
				Debug.LogWarning("No valid positions exist to choose from!");
				return 0;
			}

			boardsSeen_.Add(GetHash(board, bestPosition.Value, kAIPlayer));
			return bestPosition.Value;
		}


		// Internal
		private HashSet<int> boardsSeen_ = new HashSet<int>();

		private IEnumerable<int> ValidPositionsFromBoard(List<string> board) {
			for (int i = 0; i < board.Count; i++) {
				// if not taken
				if (board[i] == null) {
					yield return i;
				}
			}
		}
	}
}
