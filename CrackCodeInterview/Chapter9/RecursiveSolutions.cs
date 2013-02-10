using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrackCodeInterview
{
	public class RecursiveSolutions
	{
		#region Permulate Strings
		/// <summary>
		/// Write a function to permunate a string
		/// </summary>
		/// <returns>The string.</returns>
		/// <param name="s">S.</param>
		public static List<string> PermulateString (string s)
		{
			if(s.Length == 1) return new List<string>{s};
			List<string> results = new List<string>();
			foreach (var c in s) {
				foreach(var subS in PermulateString(s.Remove(s.IndexOf(c),1))){
					results.Add(c+subS);
					results.Add(subS+c);
				}
			}
			return  results.Distinct().ToList();
		}

		public static int GetFactor (int n)
		{
			int result = 1;
			for (int i = 2; i<=n; i++) {
				result = result * i;
			}
			return result;
		}

		public static int GetCountOfPermulationsOfString (string s)
		{
			int length = s.Length;
			var counts = s.GroupBy (c => c, (ch, items) => items.Count());
			int result = GetFactor (length);
			foreach (var i in counts.Where(c=>c>1)) {
				result /= GetFactor (i);
			}
			return result;
		}
		#endregion

		#region Calculate the ways for a chidren to clime a step
		public static void Output (List<int> steps)
		{
			StringBuilder sb = new StringBuilder ();
			foreach (var step in steps) {
				sb.Append(step);
				sb.Append(", ");
			}
			Console.WriteLine(sb.ToString());
		}

		/// <summary>
		/// Assume Child climb either 1/2/3 steps at a time.
		/// </summary>
		/// <param name="totalSteps">Total steps of the stair</param>
		/// <param name="steps">List to store each step</param>
		public static void CountStepsOfClimingStairs (int totalSteps, List<int> steps)
		{
			if (steps == null) {
				steps = new List<int> ();
			}
			if (totalSteps == 0) {
				Output (steps);
			}
			foreach (var i in Enumerable.Range(1,3)) {
				if (totalSteps >= i) {
					var newSteps = new List<int> (steps);
					newSteps.Add (i);
					CountStepsOfClimingStairs (totalSteps - i, newSteps);
				}
			}
		}
		#endregion

		#region Calculate the ways for a robot go from (0,0) to (x,y) in a matrix
		static void Output (List<TwoDIndex> steps)
		{
			StringBuilder sb = new StringBuilder ();
			foreach (var step in steps) {
				sb.Append(step.ToStringSimple());
				sb.Append(", ");
			}
			Console.WriteLine(sb.ToString());
		}

		public static void OutPutPathOfRobotInMatrix (int[,]matrix, 
		                                              TwoDIndex startIndex,
		                                              List<TwoDIndex> pathSteps,
		                                              TwoDIndex endIndex)
		{
			if (pathSteps == null) {
				pathSteps = new List<TwoDIndex> ();
			}
			pathSteps.Add(startIndex);
			if (startIndex.Equals(endIndex)) {
				Output (pathSteps);
			}
			if (startIndex.Row < endIndex.Row
			    && matrix[startIndex.Row+1, startIndex.Column]!=0) {
				var newSteps = new List<TwoDIndex>(pathSteps);
				var newIndex = new TwoDIndex (startIndex.Row + 1, startIndex.Column);
				OutPutPathOfRobotInMatrix (matrix, newIndex, newSteps, endIndex);
			}
			if (startIndex.Column < endIndex.Column
			    && matrix[startIndex.Row, startIndex.Column+1]!=0) {
				var newSteps = new List<TwoDIndex>(pathSteps);
				var newIndex = new TwoDIndex (startIndex.Row, startIndex.Column + 1);
				OutPutPathOfRobotInMatrix (matrix, newIndex, newSteps, endIndex);
			}
		}
		#endregion

		#region Find A Magic Index
		/// <summary>
		/// Finds a magic index in a sorted array, that A[i] == i;
		/// Assume array has duplicate records
		/// </summary>
		/// <returns>The magic index.</returns>
		/// <param name="array">Array.</param>
		/// <param name="start">Start.</param>
		/// <param name="end">End.</param>
		public static int FindMagicIndex (int[] array, int start, int end)
		{
			if (array.Length == 0 || start > end) {
				return -1;
			}
			int mid = start + (end - start) / 2;
			if (array [mid] == mid)
				return mid;
			int topMid = mid + 1;
			while (topMid<=end && array[topMid]==array[mid]) {
				if (array [topMid] == topMid) {
					return topMid;
				}
				topMid++;
			}
			if(topMid>end) topMid=end;
			int botMid = mid - 1;
			while (botMid>=start && array[botMid]==array[mid]) {
				if (array [botMid] == botMid) {
					return botMid;
				}
				botMid--;
			}
			if(botMid<start) botMid = start;
			int botIndex = FindMagicIndex (array, start, botMid);
			if (botIndex != -1) {
				return botIndex;
			}
			return FindMagicIndex (array, topMid, end);
		}
		#endregion

		#region Get All sub sets of a set of integers
		/// <summary>
		/// Gets all sub sets of a set
		/// </summary>
		/// <returns>The all sub sets.</returns>
		/// <param name="superSet">Super set.</param>
		public static List<List<int>> GetAllSubSets (List<int> superSet)
		{
			List<List<int>> resultList = new List<List<int>> {};
			int count = superSet.Count;
			foreach (var l in superSet.Distinct().Select(v=>new List<int>{v})) {
				resultList.Add (l);
			}
			int i = 2;
			while (i<=count) {
				foreach (int v in superSet) {
					int countOfV = superSet.Count (j => j == v);
					var tempList = resultList.Where (l => l.Count == i - 1 
						&& l.Count (j => j == v) < countOfV).ToList ();
					foreach (var list in tempList) {
						var newList = new List<int> (list);
						newList.Add (v);
						if (!resultList.Contains (newList, new ListComparer ())) {
							resultList.Add (newList);
						}
					}
				}
				i++;
			}
			return resultList;
		}
		#endregion


		#region Print properly open and closed n pair parentheses
		public static void PrintParentheses (string s, int open, int close)
		{
			if (close < open)
				return;
			if (open > 0) {
				PrintParentheses (s + "(", open - 1, close);
				if (open < close) {
					PrintParentheses (s + ")", open, close - 1);
				}
			} else if (close > 0) {
				PrintParentheses (s + ")", open, close - 1);
			}
			if (open == close && open == 0) {
				Console.WriteLine (s);
			}
		}
		#endregion

		#region Caculate the way of representing coins
		public static void OutPutListOfCents ()
		{
			StringBuilder sb = new StringBuilder ();
			foreach (var l in allTheList.OrderBy(c=>c.Count)) {
				sb.Clear();
				foreach (var c in l.OrderByDescending(c=>c)) {
					sb.Append (c);
					sb.Append (", ");
				}
				Console.WriteLine(sb.ToString());
			}
		}

		private static List<List<int>> allTheList = new List<List<int>>();

		/// <summary>
		/// Representings the cents.
		/// </summary>
		/// <param name="totalCents">Total cents.</param>
		/// <param name="cents">Cents.</param>
		public static void RepresentingCents (int totalCents, List<int> cents)
		{
			if (totalCents == 0) {
				if (!allTheList.Contains (cents, new ListComparer ())) {
					allTheList.Add (cents);
				}
				return;
			}
			foreach (int cent in new List<int>{25,10,5,1}) {
				if (totalCents >= cent) {
					var newCentsList = new List<int> (cents);
					newCentsList.Add (cent);
					RepresentingCents (totalCents - cent, newCentsList);
				}
			}
		}

		#endregion

		#region Place 8 Queues in a Chess board
		/// <summary>
		/// This solution is in correct. Need to think about when there is no solution and come back to recalculate. 
		/// </summary>
		static int gridSize = 8;

		public static void PlaceQueuesInChessBoard ()
		{
			var results = new List<int[]> ();

			int[] initColumns = new int[gridSize];
			int i = 0;
			while (results.Count==0 && i < gridSize) {
				initColumns[0] = i;
				PlaceQueues (initColumns, 1, ref results);
				i++;
			}
			foreach (var r in results) {
				Output (r.ToList ());
			}
		}

		static bool PlaceQueues (int[] columns, int row, ref List<int[]> results)
		{
			if (row == gridSize) {
				results.Add (columns);
				return true;
			} else {
				int i = 0;
				for (; i<gridSize; i++) {
					if (isValidPlace (columns, row, i)) {
						columns [row] = i;
						PlaceQueues (columns, row + 1, ref results);
						break;
					}
				}
				if(i==gridSize){
					return false;
				}
			}
			return false;
		}

		static bool isValidPlace(int[] columns, int row, int col)
		{
			for (int i=0; i<row; i++) {
				int tempCol = columns[i];
				if(tempCol==col){
					return false;
				}
				int colDifference = Math.Abs(col-tempCol);
				if(colDifference == row -i){
					return false;
				}
			}
			return true;
		}
		#endregion

		#region Place Stack Of box
		public static void PrintStacks (List<Box> boxes)
		{
			foreach (var box in boxes) {
				var dict = new Dictionary<Box, List<Box>>();
				var stack = GetStackWithHighestHeight (boxes, box, dict);
				Console.WriteLine ("For {0} ----", box.ToString ());
				Output(stack);
				//Console.WriteLine("Output current dictionary map:");
				//foreach(var key in dict.Keys){
				//	Output(dict[key]);
				//	Console.WriteLine("-----");
				//}
			}
		}

		static List<Box> GetStackWithHighestHeight (List<Box> boxes, Box bottom, Dictionary<Box, List<Box>> dict)
		{
			if (bottom != null && dict.ContainsKey (bottom)) {
				return dict [bottom];
			}
			List<Box> maxStack = new List<Box> ();
			int maxStackHeight = 0;
			foreach (var box in boxes.Where(b => b != bottom || bottom==null)) {
				if (box.CanStackAbove (bottom)) {
					var tempStack = GetStackWithHighestHeight (boxes, box, dict);
					int tempHeight = GetHeightOfStack (tempStack);
					if (tempHeight > maxStackHeight) {
						maxStack = tempStack;
						maxStackHeight = tempHeight; 
					}
				}
			}
			if (bottom != null) {
				maxStack.Add (bottom);
			}
			dict.Add(bottom, maxStack);
			return new List<Box>(maxStack);
		}

		static int GetHeightOfStack (List<Box> boxes)
		{
			int height = 0;
			foreach (var b in boxes) {
				height+=b.Height;
			}
			return height;
		}

		static void Output(List<Box> boxes){
			foreach (var b in boxes) {
				Console.WriteLine(b.ToString());
			}
		}
		#endregion
	}
}

