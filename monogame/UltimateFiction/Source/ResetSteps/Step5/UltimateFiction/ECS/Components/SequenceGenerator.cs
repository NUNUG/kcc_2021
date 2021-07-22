using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFiction.ECS.Components
{
	public static class SequenceGenerator
	{
		private static double ToRadians(this double angleInDegrees)
		{
			return angleInDegrees * Math.PI / 180d;
		}

		public static IEnumerable<double> ScaleBy(this IEnumerable<double> sequence, double scale)
		{
			return sequence.Select(x => x * scale);
		}

		public static IEnumerable<double> ScaleBy(this IEnumerable<double> sequence, float scale)
		{
			return sequence.ScaleBy(Convert.ToDouble(scale));
		}

		public static IEnumerable<double> ScaleBy(this IEnumerable<double> sequence, int scale)
		{
			return sequence.ScaleBy(Convert.ToDouble(scale));
		}

		public static IEnumerable<double> OffsetBy(this IEnumerable<double> sequence, int offset)
		{
			//return sequence.Select(x => x + offset);
			return sequence.OffsetBy((float)offset);
		}

		public static IEnumerable<float> ToFloats(this IEnumerable<double> sequence)
		{
			return sequence.Select(x => Convert.ToSingle(x));
		}

		public static IEnumerable<float> ToFloats(this IEnumerable<int> sequence)
		{
			return sequence.Select(x => Convert.ToSingle(x));
		}

		public static IEnumerable<double> OffsetBy(this IEnumerable<double> sequence, float offset)
		{
			return sequence.Select(x => x + offset);
		}

		public static IEnumerable<T> WithGaps<T>(this IEnumerable<T> sequence, int skip, int take, int firstGapIndex = 0)
		{
			int skipCount = 0;
			int takeCount = 0;
			int i = -1;

			foreach (T x in sequence)
			{
				i++;
				if (i < firstGapIndex)
					yield return x;
				else if (i == firstGapIndex)
				{
					skipCount++;
				}
				else
				{
					if (skipCount == skip)
					{
						// Start taking
						skipCount = 0;
						takeCount++;
						yield return x;
					}
					else if (takeCount == take)
					{
						// Start skipping
						takeCount = 0;
						skipCount++;
					}
					else if (takeCount > 0)
					{
						// We are in taking mode.  Take one.
						takeCount++;
						yield return x;
					}
					else if (skipCount > 0)
					{
						skipCount++;
						// We are in skipping mode.  Do nothing.
					}
				}
			}
		}

		public static IEnumerable<int> Linear(int zeroTo)
		{
			return Linear(0, zeroTo);
		}

		public static IEnumerable<int> Linear(int start, int end)
		{
			return Enumerable.Range(start, end - start + 1);
		}

		public static IEnumerable<int> LinearAndBack(int start, int end)
		{
			int count = end - start + 1;
			return Linear(start, end)
				.Concat(Linear(start, end)
					// We have doubled up on the first and last entries, so we remove those from the second sequence.
					.Reverse().Skip(1).Take(count - 2));
		}

		public static IEnumerable<double> SinewaveByAngles(double startingAngle, double endingAngle)
		{
			var result = Enumerable.Range(Convert.ToInt32(startingAngle), Convert.ToInt32(endingAngle - startingAngle))
				.Select(degree => Convert.ToDouble(degree))
				.Select(degree => Math.Sin(degree.ToRadians()));
			return result;
		}

		public static IEnumerable<double> SinewaveByPhases(int quarterPhaseOffset, int totalQuarterPhases)
		{
			double startingAngle = Convert.ToDouble(quarterPhaseOffset * 90);
			double endingAngle = Convert.ToDouble(totalQuarterPhases * 90 + startingAngle);
			var result = SinewaveByAngles(startingAngle, endingAngle);
			return result;
		}
	}
}
