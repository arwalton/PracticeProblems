/*This problem comes from interviewcake.com. There are on-demand movies on an airline.
 * Users watch two movies consecutively, but want to finish both of them.
 * Build a feature for picking two movies whose total runtime equal the flightime.
 * 
 * "Write a method that takes an integer flightLength (in minutes) and an array of integers movieLengths (in minutes)
 * and returns a boolean indicating whether there are two numbers in movieLengths whose sum equals flightLength.
 * When building your method:
 * Assume your users will watch exactly two movies
 * Don't make your users watch the same movie twice
 * Optimize for runtime over memory"
*/
using System;
using System.Collections.Generic;

namespace MovieLengthChecker
{
	class LengthChecker
	{
		public static bool HasMovieChoices(int flightLength, int[] movieLengths)
		{
			//Movies already seen
			var movieLengthSet = new HashSet<int>();

			foreach (int movieLength in movieLengths)
			{
				int targetMovieLength = flightLength - movieLength;

				if (movieLengthSet.Contains(targetMovieLength))
				{
					return true;
				}

				movieLengthSet.Add(movieLength);
			}

			return false;
		}

		public static void Main(string[] args)
		{
			//Test Cases
			int[] movieLengths = new int[50];
			int flightLength = 0;

			movieLengths[0] = 20;
			flightLength = 100;

			Console.WriteLine("Test1: Expect False");
			Console.WriteLine(HasMovieChoices(flightLength, movieLengths));

			movieLengths[1] = 30;
			Console.WriteLine("Test2: Expect False");
			Console.WriteLine(HasMovieChoices(flightLength, movieLengths));

			movieLengths[2] = 50;
			Console.WriteLine("Test3: Expect False");
			Console.WriteLine(HasMovieChoices(flightLength, movieLengths));

			movieLengths[3] = 50;
			Console.WriteLine("Test4: Expect True");
			Console.WriteLine(HasMovieChoices(flightLength, movieLengths));

			movieLengths[3] = 40;
			Console.WriteLine("Test5: Expect False");
			Console.WriteLine(HasMovieChoices(flightLength, movieLengths));

			movieLengths[4] = 70;
			Console.WriteLine("Test6: Expect True");
			Console.WriteLine(HasMovieChoices(flightLength, movieLengths));
		}
	}
}