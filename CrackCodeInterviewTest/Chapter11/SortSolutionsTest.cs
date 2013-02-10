using System;
using NUnit.Framework;
using CrackCodeInterview;

namespace CrackCodeInterviewTest
{
	[TestFixture]
	public class SortSolutionsTest
	{
		[TestCase()]
		public void TestMergeTwoSortedArray ()
		{
			int[] A = new int[]{2,4,6,9,12,int.MinValue,int.MinValue,int.MinValue,int.MinValue,int.MinValue};
			int[] B = new int[]{1,3,5,7,8};
			SortSolutions.MergeTwoSortedArray (A,B,5,5);
			for (int i=0; i<A.Length-1; i++) {
				Assert.IsTrue(A[i]<=A[i+1]);
				Assert.IsTrue(A[i]!=int.MinValue);
			}
		}

		[TestCase()]
		public void TestFindANumberInARotatedSortedArray ()
		{
			int[] A = new int[]{6,9,12,1,2,3,5};
			int index12 = SortSolutions.FindANumberInARotatedSortedArray(A, 12, 0, A.Length-1);
			Assert.AreEqual(2, index12, "Index of 12 should be 2");

			int index1 = SortSolutions.FindANumberInARotatedSortedArray(A, 1, 0, A.Length-1);
			Assert.AreEqual(3, index1, "Index of 1 should be 3");

			int index8 = SortSolutions.FindANumberInARotatedSortedArray(A, 8, 0, A.Length-1);
			Assert.AreEqual(-1, index8, "Index of 8 should be -1");
		}

		[TestCase()]
		public void TestFindStringInSortedArrayWithSpace()
		{
			string[] array = new string[]{"at", "", "", "", "ball", "", "", "car", "", "", "dad", "", ""};
			int indexOfBall = SortSolutions.FindStringInASortedArray(array, "ball", 0, array.Length -1);

			Assert.AreEqual(4, indexOfBall);

			int indexOfCar = SortSolutions.FindStringInASortedArray(array, "car", 0, array.Length -1);
			Assert.AreEqual(7,indexOfCar, "Index of Card should be 7");

			int indexOfNonExist = SortSolutions.FindStringInASortedArray(array, "add-car", 0, array.Length -1);
			Assert.AreEqual(-1,indexOfNonExist, "Index of NotExist should be -1");
		}

		[TestCase()]
		public void TestFindInTwoDSortedMatrix(){
			int[,] matrix = new int[,]{
				{1,2,3,4,5,6,7},
				{8,9,10,11,12,13,14},
				{15,16,17,18,19,20,21},
				{22,23,24,25,26,27,28},
			};
			var index = SortSolutions.FindValueInTwoDSortedMatrix(matrix, 1);
			Assert.AreEqual(0, index.Row);
			Assert.AreEqual(0,index.Column);
		}

		[TestCase()]
		public void TestSortStringArrayByAnagrams ()
		{
			string[] strings = new string[]{
				"hello", "dear","china","eard","deer", "reed"
			};
			SortSolutions.SortArrayOfStringByAnagrams (strings, 0, strings.Length - 1);
			//foreach (var s in strings) {
			//	Console.WriteLine(s);
			//}
			for (int i = 0; i<strings.Length-1; i++) {
				Assert.IsTrue(SortSolutions.CompareString(strings[i],strings[i+1])<=0);
			}
		}

		[TestCase()]
		public void TestRankTree()
		{
			RankTree tree = new RankTree();
			Assert.AreEqual(-1, tree.GetRank(2));
			tree.Track(1);
			Assert.AreEqual(-1, tree.GetRank(2));
			Assert.AreEqual(0, tree.GetRank(1));
			tree.Track(1);
			Assert.AreEqual(1, tree.GetRank(1));
			tree.Track(0);
			Assert.AreEqual(2, tree.GetRank(1));
			tree.Track(3);
			Assert.AreEqual(2, tree.GetRank(1));
			Assert.AreEqual(3, tree.GetRank(3));
		}
	}
}

