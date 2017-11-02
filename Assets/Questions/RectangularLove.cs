using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace InterviewQuestions.RectangularLove {
	public class Rectangle {
		// Coordinates of bottom left corner
		public int LeftX { get; set; }
		public int BottomY { get; set; }

		// Dimensions
		public int Width { get; set; }
		public int Height { get; set; }

		public Rectangle() {}

		public Rectangle(int leftX, int bottomY, int width, int height) {
			LeftX = leftX;
			BottomY = bottomY;
			Width = width;
			Height = height;
		}

		public override bool Equals(object obj) {
			// Check for null values and compare run-time types.
			if (obj == null || GetType() != obj.GetType()) {
				return false;
			}

			Rectangle r = (Rectangle)obj;
			return (LeftX == r.LeftX)
				&& (BottomY == r.BottomY)
				&& (Width == r.Width)
				&& (Height == r.Height);
		}

		public override int GetHashCode() {
			return LeftX ^ BottomY ^ Width ^ Height;
		}
	}

	public static class RectangleExtensions {
		public static int GetRightX(this Rectangle r) {
			return r.LeftX + r.Width;
		}

		public static int GetTopY(this Rectangle r) {
			return r.BottomY + r.Height;
		}
	}

	public static class RectangularLove {
		public static Rectangle GetIntersection(Rectangle a, Rectangle b) {
			if (a == null || b == null) {
				throw new ArgumentNullException();
			}

			int maxLeft = Math.Max(a.LeftX, b.LeftX);
			int minRight = Math.Min(a.GetRightX(), b.GetRightX());

			// no intersection if no width
			if (maxLeft >= minRight) {
				return null;
			}

			int maxBottom = Math.Max(a.BottomY, b.BottomY);
			int minTop = Math.Min(a.GetTopY(), b.GetTopY());

			if (maxBottom >= minTop) {
				return null;
			}

			return new Rectangle(maxLeft, maxBottom, minRight - maxLeft, minTop - maxBottom);
		}
	}
}
