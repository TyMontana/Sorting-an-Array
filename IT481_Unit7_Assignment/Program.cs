using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace IT481_Unit7_Assignment
{
	class Program
	{
		//Create the stopwatch object
		private static Stopwatch stopWatch;

		//Create a debug for printing
		public static bool debug = false;
		public static void Main(string[] args)
		{
			//Set type using number;
			//1 = bubble sort
			//2 = quicksort
			int type = 1;

			//***************************//
			//Bubble sort

			//**
			// * Small array
			//create a small integer array (10)
			int[] smallArray = GetArray(10, 100);

			//Deep copy to a new array used for removing duplicates
			int[] newSmallArray = new int[smallArray.Length];
			Array.Copy(smallArray, 0, newSmallArray, 0, newSmallArray.Length);

			//Deep copy to another array used for quick sorting
			int[] quickSmallArray = new int[newSmallArray.Length];
			Array.Copy(newSmallArray, 0, quickSmallArray, 0, quickSmallArray.Length);

			//run the mall bubble sort
			String size = "small";
			runSortArray(smallArray, size, type);

			//**
			//** Medium array

			//create a medium integer array(1000)
			int[] mediumArray = GetArray(1000, 10000);

			//Deep copy to a new array used for removing duplicates
			int[] newMediumArray = new int[mediumArray.Length];
			Array.Copy(newMediumArray, 0, newMediumArray, 0, newMediumArray.Length);

			//Deep copy to another array used for quick sorting
			int[] quickMediumArray = new int[newMediumArray.Length];
			Array.Copy(newMediumArray, 0, quickMediumArray, 0, quickMediumArray.Length);

			//run the medium bubble sort
			size = "medium";
			runSortArray(mediumArray, size, type);

			//Large array
			//create a large integer array(10,000)
			int[] largeArray = GetArray(10000, 1000000);

			//Deep copy to a new array used for removing duplicates
			int[] newLargeArray = new int[largeArray.Length];
			Array.Copy(largeArray, 0, newLargeArray, 0, newLargeArray.Length);

			//Deep copy to a new array used for quick sorting
			int[] quickLargeArray = new int[newLargeArray.Length];
			Array.Copy(newLargeArray, 0, quickLargeArray, 0, quickLargeArray.Length);

			//run the large bubble sort
			size = "large";
			runSortArray(largeArray, size, type);

			//*********************************//
			//Set to remove duplicates

			//Remove duplicates and rerun tests

			//new small array by removing duplicates
			newSmallArray = onlyUniqueElements(newSmallArray);
			size = "new small unique";
			runSortArray(newSmallArray, size, type);

			//new medium array by removing duplicates
			newMediumArray = onlyUniqueElements(newMediumArray);
			size = "new medium unique";
			runSortArray(newMediumArray, size, type);

			//new large array by removing duplicates
			newLargeArray = onlyUniqueElements(newLargeArray);
			size = "new large unique";
			runSortArray(newLargeArray, size, type);

			//*********************************//
			//Quicksort

			//Set the type to run quicksort
			type = 2;

			//Run the quick sorts with duplicates

			//Use the quick sort
			size = "quick small";

			//Run the array for timing
			runSortArray(quickSmallArray, size, type);

			//Use the quick sort
			size = "quick medium";

			//Run the array for timing
			runSortArray(quickMediumArray, size, type);

			//Use the quick sort
			size = "quick large";

			//Run the array for timing
			runSortArray(quickLargeArray, size, type);
			//Console.Read()

			int[] arr = { 44, 88, 77, 22, 66, 11, 99, 55, 00, 33 };
			int low = 0;
			int high = arr.Length - 1;
			quickSortAsc(arr, low, high);

			Console.WriteLine("Array after the quick sort");

			for (int i = 0; i < arr.Length; i++)
			{
				Console.WriteLine(arr[i] + " ");
			}
			Console.Read();
		}
		//Get array of integers of sizes as determined by parameters passed

		private static int[] GetArray(int size, int randomMaxSize)
		{
			//Create the array with size
			int[] myArray = new int[size];

			//Get the random values for the array
			for (int i = 0; i < myArray.Length; i++)
			{
				//Get the random number with randomMaxSize as the upper limit of 1 - randomMaxSize.
				myArray[i] = GetRandomNumber(1, randomMaxSize);
			}
			//Return the filled array
			return myArray;
		}
		private static void runSortArray(int[] arr, String size, int type)
		{
			long elapsedTime = 0;

			//Set the sort type as a string
			String sort = null;

			if (type == 1)
			{
				sort = "bubble";
			}
			else if (type == 2)
			{
				sort = "quick";
			}

			//print array before sorting using bubble sort algorithm
			if (debug)
			{
				Console.WriteLine("Array before the " + sort + "sort");
				for (int i = 0; i < arr.Length; i++)
				{
					Console.Write(arr[i] + " ");
				}
			}
			//Start the timer
			stopWatch = Stopwatch.StartNew();

			//sort an array using bubble sort algorithm
			if (type == 1)
			{
				bubbleSort(arr);
			}
			else if (type == 2)
			{
				//Set low and high values for a quick sort
				int low = 0;
				int high = arr.Length - 1;
				quickSortAsc(arr, low, high);
			}
			Console.WriteLine();

			//print array after sorting using bubble sort algorithm

			if (debug)
			{
				Console.WriteLine("Array after the" + sort + "sort");

				for (int i = 0; i < arr.Length; i++)
				{
					Console.WriteLine(arr[i] + " ");
				}
			}

			//Stop the wait timer
			stopWatch.Stop();

			//Get the time elapsed for waiting
			elapsedTime = stopWatch.ElapsedTicks;

			long frequency = Stopwatch.Frequency;
			long nanosecondsPerTick = (1000L * 1000L * 1000L) / frequency;
			elapsedTime = elapsedTime * nanosecondsPerTick;

			Console.WriteLine("\n");
			//Print out the time in nanoseconds
			Console.WriteLine("The run time is for the " + "array in nanoseconds is " + elapsedTime);
			Console.WriteLine("\n\n");
		}
		//Perform the bubble sort
		private static void bubbleSort(int[] intArray)
		{
			int temp = 0;
			for (int i = 0; i < intArray.Length; i++)
			{
				for (int j = 0; j < intArray.Length - 1; j++)
				{
					if (intArray[j] > intArray[j + 1])
					{
						temp = intArray[j + 1];
						intArray[j + 1] = intArray[j];
						intArray[j] = temp;
					}
				}
			}
		}
		//Remove duplicates in an array using a set
		private static int[] onlyUniqueElements(int[] inputArray)
		{
			//create the seat
			HashSet<int> set = new HashSet<int>();

			//create the temporary array
			int[] tmp = new int[inputArray.Length];
			int index = 0;

			//use the set to remove duplicates and add to new array
			foreach (int i in inputArray)
				if (set.Add(i))
					tmp[index++] = i;
			//return the array
			return set.ToArray();
		}
		//Quicksort and compare numbers
		private static void quickSortAsc(int[] x, int low, int high)
		{
			if (low < high)
			{
				//pr is partitioning index
				int pr = partition(x, low, high);
				//arr[p] is now at right place;
				quickSortAsc(x, low, pr-1);
				quickSortAsc(x, pr+1, high);
			}
		}
		private static int partition(int[] arr, int low, int high)
		{
			//pr is the pivot element to be placed at at right position
			int p = low;
			int i = low;
			int temp = 0;

			for (int j = low + 1; j <= high; j++)
			{
				if (arr[j] <= arr[p]) 
				{
					i++;
					temp = arr[i];
					arr[i] = arr[j];
					arr[j] = temp;
				}
			}
			//swap arr[i] and arr[p]
			temp = arr[i];
			arr[i] = arr[p];
			arr[p] = temp;

			return i;
		}

		//Random number methods
		private static readonly Random getrandom = new Random();

		public static int GetRandomNumber(int min, int max)
		{
			lock (getrandom)
			{
				return getrandom.Next(min, max);
			}
		}
	}
}





