using System;
using System.Linq;
using System.Collections.Generic;


namespace CrackCodeInterview
{
	public class SortSolutions
	{
		//Assume array A has enough space hold Array B;
		/// <summary>
		/// Merges the two sorted array.
		/// </summary>
		/// <param name="A">A.</param>
		/// <param name="B">B.</param>
		/// <param name="lengthA">the number of elements currently in A.</param>
		/// <param name="lengthB">the number of elements currently in B.</param>
		public static void MergeTwoSortedArray (int[] A, int[] B, int lengthA, int lengthB)
		{
			int mergeIndex = lengthA + lengthB - 1;
			int indexB = lengthB - 1;
			int indexA = lengthA - 1;
			int countOfA = A.Length;
			while (indexB >=0 && indexA>=0) {
				if (B [indexB] >= A [indexA]) {
					A [mergeIndex] = B [indexB];
					indexB--;
				} else {
					A [mergeIndex] = A [indexA];
					indexA--;
				}
				mergeIndex--;
			}
			while (indexB>=0) {
				A[mergeIndex] = B[indexB];
				mergeIndex--;
				indexB--;
			}
		}

		/// <summary>
		/// Finds A number in A rotated sorted array.
		/// </summary>
		/// <returns>The index of the number in the rotated sorted array.</returns>
		/// <param name="array">Array.</param>
		/// <param name="numberToFind">Number to find.</param>
		public static int FindANumberInARotatedSortedArray (int[] array, int numberToFind, int startIndex, int endIndex)
		{

			//Assume the array is sorted in increasing order.
			if (startIndex > endIndex)
				return -1;
			int mid = startIndex + (endIndex - startIndex) / 2;
			if (array [mid] == numberToFind) {
				return mid;
			}

			//There is at least one side is natrually sorted. 
			if (array [startIndex] < array [mid]) { // Left side is natrually sorted.
				if (array [startIndex] <= numberToFind && numberToFind < array [mid]) {
					return FindANumberInARotatedSortedArray (array, numberToFind, startIndex, mid - 1);
				} else {
					return FindANumberInARotatedSortedArray (array, numberToFind, mid + 1, endIndex);
				}
			} else if (array [startIndex] > array [mid]) { // Right side is natrually sorted
				if (array [endIndex] >= numberToFind && numberToFind > array [mid]) {
					return FindANumberInARotatedSortedArray (array, numberToFind, mid + 1, endIndex);
				} else {
					return FindANumberInARotatedSortedArray (array, numberToFind, startIndex, mid - 1);
				}
			} else if(array[startIndex] == array[mid] ) {
				if(array[mid] != array[endIndex]){
					return FindANumberInARotatedSortedArray(array, numberToFind, mid+1, endIndex);
				}
				else {
					int i = FindANumberInARotatedSortedArray(array, numberToFind, startIndex, mid-1);
					if(i==-1){
						return FindANumberInARotatedSortedArray(array, numberToFind, mid+1, endIndex);
					}
					return i;
				}
			}
			return -1;
		}


		/// <summary>
		/// Finds the string in A sorted array with interspersed space.
		/// Given a sorted array of strings which is interspersed with empty strings, 
		/// write a method to find the location of a given string.
		/// Example: find “ball” in [“at”, “”, “”, “”, “ball”, “”, “”, “car”, “”, “”, “dad”, “”, “”] will return 4
		/// Example: find “ballcar” in [“at”, “”, “”, “”, “”, “ball”, “car”, “”, “”, “dad”, “”, “”] will return -1
		/// </summary>
		/// <returns>The index of string in the array</returns>
		/// <param name="array">Array.</param>
		/// <param name="toFind">To find.</param>
		/// <param name="startIndex">Start index.</param>
		/// <param name="endIndex">End index.</param>
		public static int FindStringInASortedArray (string[]array, string toFind, int startIndex, int endIndex)
		{
			if (array == null || toFind == string.Empty || toFind == null) {
				return -1;
			}
			if (startIndex > endIndex) {
				return -1;
			}
			int mid = startIndex + (endIndex - startIndex) / 2;
			if (array [mid] == toFind) {
				return mid;
			}
			int topMid = mid, botMid = mid;
			while (array[topMid] == "" && topMid++<=endIndex)
				;
			while (array[botMid] == "" && botMid-->=startIndex)
				;
			if (topMid > endIndex && botMid < startIndex) {
				return -1;
			}

			if (topMid > endIndex) {
				if (toFind.CompareTo (array [botMid]) > 0) {
					return -1;
				} else if (toFind == array [botMid]) {
					return botMid;
				} else {
					return FindStringInASortedArray (array, toFind, startIndex, botMid-1);
				}
			} else if (botMid < startIndex) {
				if (toFind.CompareTo (array [topMid]) < 0) {
					return -1;
				} else if (toFind == array [topMid]) {
					return topMid;
				} else {
					return FindStringInASortedArray (array, toFind, topMid+1, endIndex);
				}
			} else {
				if(toFind.CompareTo(array[botMid])>0 
				   && toFind.CompareTo(array[topMid])<0){
					return -1;
				}
				else if(toFind.CompareTo(array[botMid])<=0){
					return toFind==array[botMid] ? botMid : FindStringInASortedArray(array, toFind, startIndex, botMid -1);
				}
				else{
					return toFind== array[topMid] ? topMid : FindStringInASortedArray(array, toFind, topMid+1, endIndex);
				}
			}
		}

		public static TwoDIndex FindValueInTwoDSortedMatrix (int[,] matrix, int toFind)
		{
			int row = 0;
			int column = matrix.GetLength (1) - 1;
			while (row<matrix.GetLength(0) && column >=0) {
				if(matrix[row, column] == toFind){
					return new TwoDIndex{Row = row, Column = column};
				}
				else if(matrix[row,column] >toFind){
					column--;
				}
				else{
					row++;
				}
			}
			return new TwoDIndex(){Row = -1, Column = -1};
		}


		public static void SortArrayOfStringByAnagrams (string[] strings, int start, int end)
		{
			if (start >= end)
				return;
			int mid = start + (end-start)/2;
			int part = Partition (strings, start, end, mid);
			SortArrayOfStringByAnagrams (strings, start, part - 1);
			SortArrayOfStringByAnagrams (strings, part + 1, end);
		}

		static int Partition (string[] strings, int start, int end, int pivot)
		{
			string pivotValue = strings[pivot];
			SwapStringsInArray(strings, pivot, end);
			int swapIndex = start;
			for (int i=start; i<end;i++) {
				if (CompareString (strings [i], pivotValue) < 0) {
					SwapStringsInArray (strings, i, swapIndex);
					swapIndex+=1;
				}
			}
			SwapStringsInArray (strings, swapIndex, end);
			return swapIndex;
		}

		public static int CompareString (string one, string two)
		{
			string sortedOne = one.ToLower().OrderBy (c => c).Aggregate("", (c,s)=>c+s);
			string sortedTwo = two.ToLower().OrderBy (c => c).Aggregate("", (c,s)=>c+s);
			return string.Compare (sortedOne, sortedTwo);
		}

		static void SwapStringsInArray (string[] strings, int indexOne, int indexTwo)
		{
			if (indexOne != indexTwo) {
				string t = strings [indexOne];
				strings [indexOne] = strings [indexTwo];
				strings [indexTwo] = t;
			}
		}

		public static List<CircusPeople> BuildCircusTowerBySorting (List<CircusPeople> people)
		{
			people = people.OrderByDescending (p => p.Weight).ThenByDescending (p => p.Height).ToList();
			int maxCount = 0;
			var result = new List<CircusPeople> ();
			var temp = new List<CircusPeople> ();
			for (int i = 0; i< people.Count - maxCount; i++) {
				temp.Clear();
				temp.Add(people[i]);
				for(int j = i+1; j< people.Count; j++){
					var last = temp.Last();
					if(people[j].Weight< last.Weight 
					   && people[j].Height < last.Height){
						temp.Add(people[j]);
					}
				}
				if(temp.Count>result.Count){
					result = new List<CircusPeople>(temp);
					maxCount = result.Count;
				}
			}
			return result;
		}
	}
}

