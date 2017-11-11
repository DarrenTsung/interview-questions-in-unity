using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace InterviewQuestions.GameOfStones {
	public enum PlayerType {
		First,
		Second,
	}

	public static class GameOfStones {
		// PRAGMA MARK - Public Interface
		public static readonly int[] kDefaultRemovals = new int[] { 2, 3, 5 };

		// Two players (numbered 1 and 2) are playing a game with N stones.
		// Player 1 always plays first, and the two players move in alternating turns. The game's rules are as follows:
		//  * In a single move, a player can remove either 2, 3, or 5 stones from the game board.
		//  * If a player is unable to make a move, that player loses the game.
		//
		// Given the number of stones, return the winner (1, or 2) on a new line.
		// Each player plays optimally, meaning they will not make a move that causes them to lose the game if some better, winning move exists.
		public static PlayerType Solve(int numberStones) {
			int[] possibleRemovals = kDefaultRemovals;

			bool[] p1Wins = new bool[numberStones + 1];
			p1Wins[0] = false;

			for (int i = 1; i <= numberStones; i++) {
				bool wins = false;
				foreach (int removal in possibleRemovals) {
					if (removal > i) {
						continue;
					}

					if (p1Wins[i - removal] == false) {
						wins = true;
						break;
					}
				}

				p1Wins[i] = wins;
			}

			return p1Wins[numberStones] ? PlayerType.First : PlayerType.Second;
		}


		// PRAGMA MARK - Internal
	}
}