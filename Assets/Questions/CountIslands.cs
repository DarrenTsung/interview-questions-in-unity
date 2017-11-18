using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using InterviewQuestions.Structs;

namespace InterviewQuestions.CountIslands {
	public static class CountIslands {
		public static int Count(int[,] map) {
			if (map == null) {
				throw new ArgumentNullException();
			}

			int numberIslands = 0;

			HashSet<IntVector2> visitedPositions = new HashSet<IntVector2>();
			for (int x = 0; x < map.GetLength(0); x++) {
				for (int y = 0; y < map.GetLength(1); y++) {
					// foreach position, check if it is an island
					IntVector2 currentPosition = new IntVector2(x, y);
					if (visitedPositions.Contains(currentPosition)) {
						continue;
					}

					int gridElement = AccessMap(map, currentPosition);
					// is land
					if (gridElement == 1) {
						// flood fill the land
						Queue<IntVector2> positionsToCheck = new Queue<IntVector2>();
						positionsToCheck.Enqueue(currentPosition);

						while (positionsToCheck.Count > 0) {
							IntVector2 position = positionsToCheck.Dequeue();

							if (visitedPositions.Contains(position)) {
								continue;
							}
							visitedPositions.Add(position);

							// check next to land
							if (AccessMap(map, position) == 1) {
								positionsToCheck.Enqueue(new IntVector2(position.x, position.y + 1));
								positionsToCheck.Enqueue(new IntVector2(position.x, position.y - 1));
								positionsToCheck.Enqueue(new IntVector2(position.x + 1, position.y));
								positionsToCheck.Enqueue(new IntVector2(position.x - 1, position.y));
							}
						}

						numberIslands++;
					} else if (gridElement == 0) {
						// it is water
						continue;
					} else {
						throw new ArgumentException("Grid element must be 0 (water) or 1 (land)!");
					}
				}
			}

			return numberIslands;
		}

		private static int AccessMap(int[,] map, IntVector2 position) {
			if (position.x < 0 || position.x >= map.GetLength(0)) {
				return -1;
			}

			if (position.y < 0 || position.y >= map.GetLength(1)) {
				return -1;
			}

			return map[position.x, position.y];
		}
	}
}
