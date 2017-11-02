using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace InterviewQuestions.MergeMeetingTimes {
	public class Meeting {
		public readonly int StartTime;
		public readonly int EndTime;

		public override string ToString() {
			return string.Format("[{0}, {1}]", StartTime, EndTime);
		}

		public override bool Equals(object obj) {
			// Check for null values and compare run-time types.
			if (obj == null || GetType() != obj.GetType()) {
				return false;
			}

			Meeting m = (Meeting)obj;
			return (m.StartTime == StartTime) && (m.EndTime == EndTime);
		}

		public override int GetHashCode() {
			return StartTime ^ EndTime;
		}

		public Meeting(int startTime, int endTime) {
			if (startTime > endTime) {
				throw new ArgumentException();
			}

			StartTime = startTime;
			EndTime = endTime;
		}
	}

	public static class MergeMeetingTimes {
		public static Meeting[] Merge(Meeting[] meetings) {
			if (meetings == null) {
				throw new ArgumentNullException();
			}

			if (meetings.Length <= 1) {
				return meetings;
			}

			var copiedMeetings = new List<Meeting>(meetings);
			copiedMeetings.Sort((a, b) => a.StartTime.CompareTo(b.StartTime));

			var mergedMeetings = new List<Meeting>();

			int currentStartTime = copiedMeetings[0].StartTime;
			int currentEndTime = copiedMeetings[0].EndTime;

			for (int i = 1; i < copiedMeetings.Count; i++) {
				Meeting next = copiedMeetings[i];
				if (next.StartTime > currentEndTime) {
					mergedMeetings.Add(new Meeting(currentStartTime, currentEndTime));

					currentStartTime = next.StartTime;
					currentEndTime = next.EndTime;
				} else {
					currentEndTime = Math.Max(currentEndTime, next.EndTime);
				}
			}

			// flush the last meeting
			mergedMeetings.Add(new Meeting(currentStartTime, currentEndTime));

			return mergedMeetings.ToArray();
		}
	}
}