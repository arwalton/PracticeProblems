using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* This problem comes from interviewcake.com.
 * I want to learn some big words so people think I'm smart.
 * I opened up a dictionary to a page in the middle and started flipping through, 
 * looking for words I didn't know. I put each word I didn't know at increasing
 * indices in a huge array I created in memory. When I reached the end of the
 * dictionary, I started from the beginning and did the same thing until I reached
 * the page I started at.
 * 
 * Now I have an array of words that are mostly alphabetical, except they start
 * somewhere in the middle of the alphabet, reach the end, and then start from the 
 * beginning of the alphabet. In other words, this is an alphabetically ordered 
 * array that has been "rotated."
 * 
 * Write a method for finding the index of the "rotation point," which is where 
 * I started working from the beginning of the dictionary. This array is huge 
 * (there are lots of words I don't know) so we want to be efficient here.
 */

namespace Solution
{
	class Solution
	{
		public static int FindReflectionIndex(string[] words)
		{
			int bottomIndex = 0;
			int topIndex = words.Length - 1;
			while (topIndex > bottomIndex + 1)
			{
				int testIndex = bottomIndex + ((topIndex - bottomIndex) / 2);
				if (words[bottomIndex].CompareTo(words[testIndex]) == 1)
				{
					topIndex = testIndex;
				}
				else {
					bottomIndex = testIndex;
				}

			}

			if (words[bottomIndex].CompareTo(words[topIndex]) == 1)
			{
				return topIndex;
			}
			else if (words[bottomIndex].CompareTo(words[topIndex]) == -1)
			{
				return 0;
			}
			else {
				return bottomIndex;
			}
		}

		public static void Main(string[] args)
		{
			string[] test1 = { "bat", "cat", "dat", "at" };
			string[] test2 = { "cat", "dat", "eat", "at", "bat" };
			string[] test3 = { "at", "bat", "cat", "dat", "eat" };
			Console.WriteLine("Testing test1");
			Console.WriteLine("Expected answer: 3");
			Console.WriteLine("Actual answer: " + FindReflectionIndex(test1).ToString());
			Console.WriteLine("Testing test2");
			Console.WriteLine("Expected answer: 3");
			Console.WriteLine("Actual answer: " + FindReflectionIndex(test2).ToString());
			Console.WriteLine("Testing test3");
			Console.WriteLine("Expected answer: 0");
			Console.WriteLine("Actual answer: " + FindReflectionIndex(test3).ToString());
		}
	}
}

/*
 * 
 * My first attempt, just getting a brute force solution.
        
        public static int FindReflectionIndex(string[] words)
        {
            string currentFirstWord = "";
            for (int i = 0; i < words.Length; i++){
                if (currentFirstWord == ""){
                    currentFirstWord = words[i];
                }else if (currentFirstWord.CompareTo(words[i]) == 1){
                    return i;
                }
                
            }
            return 0;
        }

        public static void Main(string[] args)
        {
            var words = new string[]{
                "time",
                "up",
                "very",
                "apple",
                "boat",
                "cow"
            };
            
            Console.WriteLine("Testing FindReflectionIndex() with words.");
            Console.WriteLine("Expected Output: 3");
            Console.WriteLine("Actual Output: " + FindReflectionIndex(words).ToString());
        }
        */
