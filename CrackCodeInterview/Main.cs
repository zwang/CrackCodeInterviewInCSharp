using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
namespace CrackCodeInterview
{
	abstract class Hello{

		public Hello(){
		}

		public abstract void TestMethod();
	}

	class Program
	{
		static void TestCheckAnagram ()
		{
			var testCheckAnagram = new CheckAnagram ("hello".ToCharArray (), "llohe".ToCharArray ());
			testCheckAnagram.Run ();
			testCheckAnagram = new CheckAnagram ("hellow".ToCharArray (), "llohe".ToCharArray ());
			testCheckAnagram.Run ();
			testCheckAnagram = new CheckAnagram ("hellow".ToCharArray (), "llohee".ToCharArray ());
			testCheckAnagram.Run ();
			testCheckAnagram = new CheckAnagram ("".ToCharArray (), "".ToCharArray ());
			testCheckAnagram.Run ();
		}

		static void TestReplaceSpace ()
		{
			var testReplaceSpace = new ReplaceSpace ("I love programming, how about your?".ToCharArray ());
			testReplaceSpace.Run ();
		}

		static void TestClearRowAndColumn ()
		{
			int [,] matrix = new int[,]{
				{0,1,2,3,4},
				{2,1,2,3,4},
				{5,1,0,3,4}
			};
			var test = new ClearRowAndColumn(matrix);
			test.Run();
		}

		static void TestCheckRotation ()
		{
			string str1 = "helloworld";
			string str2 = "worldhello";
			var test1 = new CheckRotationWithIsSubstringMethod(str1, str2);
			test1.Run();

			str1 = "helloworld";
			str2 = "worldhell";
			test1 = new CheckRotationWithIsSubstringMethod(str1, str2);
			test1.Run();

			str1 = "helloworld";
			str2 = "worlehello";
			test1 = new CheckRotationWithIsSubstringMethod(str1, str2);
			test1.Run();

			str1 = "erbottlewat";
			str2 = "waterbottle";
			test1 = new CheckRotationWithIsSubstringMethod(str1, str2);
			test1.Run();

			str2 = "erbottlewat";
			str1 = "waterbottle";
			test1 = new CheckRotationWithIsSubstringMethod(str1, str2);
			test1.Run();
		}

		static void TestRotateImage ()
		{
			int[,] image = new int[,]{
				{0,1,1,1,4},
				{2,6,6,6,3},
				{2,9,10,7,3},
				{2,8,8,7,3},
				{16,5,5,5,8},
			};
			var test2 = new RotateImage(image);
			test2.Run();
		}

		//Chapter 2
		static void TestLinkedList ()
		{
			Node head= new Node(1);
			LinkedList list = new LinkedList(head);
			list.AppendNewNode(new Node(2));
			list.AppendNewNode(new Node(3));
			list.AppendNewNode(new Node(4));
			list.AppendNewNode(new Node(5));
			list.AppendNewNode(new Node(2));
			list.AppendNewNode(new Node(7));
			list.AppendNewNode(new Node(8));
			list.ToString();

			list.RemoveDuplicateNode();
			list.ToString();

			list.AppendNewNode(new Node(2));
			list.AppendNewNode(new Node(7));
			list.ToString();

			list.RemoveDuplicateNodeWithoutHashTable();
			list.ToString();

			//Find the Node which is Nth to the last node
			Node result = list.FindTheNthToLastNode(4);
			Console.WriteLine(result.Data);
			result = list.FindTheNthToLastNode(14);
			Console.WriteLine(result == null);

			result = list.FindTheNthToLastNode(0);
			Console.WriteLine(result.Data);

			result = list.FindTheNthToLastNode(1);
			Console.WriteLine(result.Data);

			Node s = null;
			LinkedList list2 = new LinkedList(s);
			result = list2.FindTheNthToLastNode(2);
			Console.WriteLine(result == null);
		}

		static void TestRemoveNodeFromLinkedList ()
		{
			Node head = new Node (1);
			LinkedList list = new LinkedList (head);
			list.AppendNewNode (new Node (2));
			list.AppendNewNode (new Node (3));
			list.AppendNewNode (new Node (4));
			Node five = new Node(5);
			list.AppendNewNode (five);
			list.AppendNewNode (new Node (2));
			list.AppendNewNode (new Node (7));
			list.AppendNewNode (new Node (8));
			list.ToString ();
			//Node newHead = head.DeleteSelfFromLinkedList ();
			//while (newHead!=null) {
			//	Console.Write(newHead.Data);
			//	Console.Write(" ");
			//	newHead = newHead.Next;
			//}
			//Console.WriteLine(" ");

			five.DeleteSelfFromLinkedList();
			list.ToString();

			//Test single node list
			Node one = new Node(2);
			LinkedList list2 = new LinkedList(one);
			list2.Head = one.DeleteSelfFromLinkedList();
			list2.ToString();
		}

		static void TestListAddition ()
		{
			LinkedList list1 = new LinkedList(new List<Node>{
				new Node(3),
				new Node(0),
				new Node(5)
			});
			list1.ToString();
			LinkedList list2 = new LinkedList(new List<Node>{
				new Node(7),
				//new Node(0),
				//new Node(3)
			});
			list2.ToString();
			var test1 = new ListAddition(list1, list2);
			test1.Run();
		}

		static void TestCircularList ()
		{
			Node start = new Node (99);
			LinkedList list1 = new LinkedList (new List<Node>{
				new Node(3),
				new Node(0),
				new Node(5),
				new Node(6),
				new Node(7),
				new Node(9),
				new Node(12),
				new Node(33),
				new Node(11),
				new Node(13),
				new Node(54)
			});
			var list = new List<Node>{
				new Node(3),
				new Node(0),
				new Node(5),
				new Node(6),
				new Node(7),
				new Node(9),
				new Node(12),
				new Node(33),
				new Node(11),
				new Node(13),
				new Node(54),
			};
			Node h = list1.Head;
			while (h.Next!=null) {
				h = h.Next;
			}
			h.Next = start;
			h = h.Next;
			foreach (var node in list) {
				h.Next = node;
				h=h.Next;
			}
			h.Next = start;
			var test1 = new GetCircularStartNodeInList(list1);
			test1.Run();
		}

		static void TestNodeStackWithMinimumNode ()
		{
			var stack = new NodeStackWithMinimumNode ();
			Debug.Assert (stack.GetMinimum () == null);
			Debug.Assert (stack.Peek () == null);
			Debug.Assert (stack.Pop () == null);
			stack.Push (new Node (2));
			Debug.Assert (stack.GetMinimum ().Data == 2);
			Debug.Assert (stack.Peek ().Data == 2);
			stack.Push (new Node (1));
			Debug.Assert (stack.GetMinimum ().Data == 1);
			Debug.Assert (stack.Peek ().Data == 1);
			stack.Push (new Node (-3));
			Debug.Assert (stack.GetMinimum ().Data == -3);
			Debug.Assert (stack.Peek ().Data == -3);
			stack.Push (new Node (5));
			Debug.Assert (stack.GetMinimum ().Data == -3);
			Debug.Assert (stack.Peek ().Data == -3);

			while (stack.Peek()!=null) {
				Node n = stack.Pop();
				Console.Write(n.Data);
				Console.Write(" ");
			}
		}

		static void TestQueueByStack ()
		{
			QuueByStack queue = new QuueByStack ();
			var list = new List<Node>{
				new Node(3),
				new Node(0),
				new Node(5),
				new Node(6),
				new Node(7),
				new Node(9),
				new Node(12),
				new Node(33),
				new Node(11),
				new Node(13),
				new Node(54),
			};
			foreach (var n in list) {
				queue.Enqueue (n);
			}
			while (!queue.IsEmpty()) {
				Console.Write(queue.Dequeue().Data);
				Console.Write(" ");
			}
		}

		static void TestSortStack ()
		{
			Stack<int> stack = new Stack<int>();
			var list = new List<int>{3,0,5,6,7,9,12,33,11,13,54};
			foreach (var n in list) {
				stack.Push(n);
			}
			var st = SortStack.Sort(stack);
			SortStack.PrintStack(st);
		}

		static void TestHanoi ()
		{
			TowerOfHanoi t = new TowerOfHanoi(5);
			t.StartMove();
		}

		static void TestSetOfStacks ()
		{
			var st = new SetOfStacks(3);
			var list = new List<int>{3,0,5,6,7,9,12,33,11,13,54,123,134};
			foreach (var n in list) {
				st.Push(n);
			}
			Console.WriteLine(st.PopAt(3));
			while (!st.IsEmpty()) {
				int s = st.Pop();
				Console.Write(s);
				Console.Write(" ");
			}
		}

		delegate int Sq(int x);

		public static void Main (string[] args)
		{
			//Chapter 1
			//TestReplaceSpace ();
			//TestCheckAnagram ();
			//TestClearRowAndColumn();
			//TestCheckRotation();
			//TestRotateImage();

			//Chapter 2
			//TestLinkedList();
			//TestRemoveNodeFromLinkedList();
			//TestListAddition();
			//TestCircularList();

			//Chapter 3
			//TestNodeStackWithMinimumNode();
			//TestQueueByStack();
			//TestSortStack();
			//TestHanoi();
			//TestSetOfStacks();

			//Chapter 4 
			/*SortedSet<int> set = new SortedSet<int> ();
			set.Add (2);
			set.Add (5);
			set.Add (23);
			set.Add (11);
			Console.WriteLine (set.Min);
			foreach (var s in set) {
				Console.WriteLine (s);
			}

			LinkedList<int> list = new LinkedList<int> (new List<int>{1,2,3,4,5});

			var first =  list.AddFirst(55);


			while (first!=null) {
				Console.WriteLine(first.Value);
				first = first.Next;
			}

			var last = list.AddLast(23);
			list.Remove(3);
			while (last!=null) {
				Console.WriteLine(last.Value);
				last = last.Previous;
			}*/

			//Print p = Hello;
			//p+=Hello2;
			//Debug.Assert(p.GetInvocationList().Length ==2);
			//p=Hello2;
			//Debug.Assert(p.GetInvocationList().Length ==1);
			//p("Hello");
			//
			//Action<string> a = Hello;
			//a.Invoke("Test action");
			//
			//Func<int,int, int> f = Sum;
			//var s = f.Invoke(2,3);
			//Debug.Assert(s==5, "s is not 5");
			//
			//Print2<string> p2 = Hello;
			//p2.Invoke("Test method");
			//
			//TestDelegate(Hello2, "Test delegate as parameter");
			//
			//Thread t = new Thread (Go);
			//t.Start();
			//t.Join();
			//Console.WriteLine ("Thread t has ended!");
			//
			//int[] A = new int[]{2,4,6,9,12,0,0,0,0,0};
			//int[] B = new int[]{1,3,5,7,8};
			//SortSolutions.MergeTwoSortedArray (A, B, 5, 5);
			//foreach (int i in A) {
			//	Console.WriteLine (i);
			//}

			//var strings = RecursiveSolutions.PermulateString ("hellefff");
			//Console.WriteLine(strings.Count);

			//Console.WriteLine(RecursiveSolutions.GetCountOfPermulationsOfString("hellefff"));
//			foreach (var s in strings) {
//				Console.WriteLine(s);
//			}

			//RecursiveSolutions.PrintParentheses("",3,3);

			//RecursiveSolutions.RepresentingCents(25, new List<int>());
			//RecursiveSolutions.OutPutListOfCents();

			//RecursiveSolutions.CountStepsOfClimingStairs(13, new List<int>());

			//int[,] matrix = new int[,]{
			//	{1,1,0,1},
			//	{0,1,1,0},
			//	{1,0,1,1},
			//	{1,1,1,1}
			//};
			//RecursiveSolutions.OutPutPathOfRobotInMatrix(matrix, new TwoDIndex(0,0), null, new TwoDIndex(3,3));

			//Find magic index
			//int[] array = {0,0,1,2,2,4,4,5,5,5,7,8,13,14};
			//Console.WriteLine(RecursiveSolutions.FindMagicIndex(array, 0, array.Length-1));

			//var intList = new List<int>{1,1,1,1,2};
			//var result = RecursiveSolutions.GetAllSubSets (intList);
			//foreach (var l in result) {
			//	RecursiveSolutions.Output(l);
			//}

			//RecursiveSolutions.PlaceQueuesInChessBoard();

			//Get the stack with the greatest height
			//var boxes = new List<Box>{
			//	new Box(10,12,14),
			//	new Box(11,12,14),
			//	new Box(11,11,14),
			//	new Box(3,4,5),
			//	new Box(12,12,14),
			//};
			//RecursiveSolutions.PrintStacks(boxes);

			//Console.WriteLine ("hello".OrderBy (c => c).Aggregate ("", (s,c) => s + c));

			//var people = new List<CircusPeople>{
			//	new CircusPeople(65,100),
			//	new CircusPeople(70,80),
			//	new CircusPeople(56,90),
			//	new CircusPeople(70,100),
			//	new CircusPeople(75,190),
			//	new CircusPeople(60,95),
			//	new CircusPeople(68,110),
			//	new CircusPeople(69, 97),
			//};
			//var result = SortSolutions.BuildCircusTowerBySorting (people);
			//foreach (var p in result) {
			//	Console.WriteLine(p.ToString());
			//}

			//RankTree tree = new RankTree();
			//Console.WriteLine(tree.GetRank(2));
			//tree.Track(1);
			//Console.WriteLine( tree.GetRank(2));
			//Console.WriteLine(tree.GetRank(1));
			//tree.Track(1);
			//Console.WriteLine(tree.GetRank(1));
			//tree.Track(0);
			//Console.WriteLine(tree.GetRank(1));
			//tree.Track(3);
			//Console.WriteLine(tree.GetRank(1));
			//Console.WriteLine(tree.GetRank(3));

			//Test Random Set
			var set = new RandomSet<int> ();
			set.Insert (2);
			set.Insert (4);
			set.Insert (3);
			set.Insert (4);
			set.Insert (1);
			Console.WriteLine(set.GetRandomValue ());
			Console.WriteLine(set.GetRandomValue ());
			Console.WriteLine(set.GetRandomValue ());
			Console.WriteLine(set.GetRandomValue ());
			Console.WriteLine (set.Contains (4));
			set.Delete (4);
			Console.WriteLine (set.Contains (4));
			Console.WriteLine(set.GetRandomValue ());
			Console.WriteLine(set.GetRandomValue ());
			Console.WriteLine(set.GetRandomValue ());
			Console.WriteLine(set.GetRandomValue ());

			Console.WriteLine(AddWithOutOperator(int.MaxValue,int.MaxValue));

		}

		static void Go()
		{
			Console.WriteLine("Thread Start time: {0}", DateTime.UtcNow);
			for (int i = 0; i < 1000; i++) Console.Write ("y");
			Console.WriteLine("Thread End time: {0}", DateTime.UtcNow);
		}

		private static void Hello(string s)
		{
			Console.WriteLine("1");
			Console.WriteLine(s);
		}

		private static void Hello2(string s)
		{
			Console.WriteLine("2");
			Console.WriteLine(s);
		}

		private static int Sum(int a, int b){
			return a+b;
		}

		delegate void Print(string s);

		delegate void Print2<T>(T s);

	    static void TestDelegate( Print function, string s)
		{
			function(s);
		}

		static int AddWithOutOperator(int a, int b)
		{
			if (b == 0) {
				return a;
			}
			int resultWithOutExtra = a ^ b;
			int extra = (a & b) << 1;
			return  AddWithOutOperator (extra, resultWithOutExtra);

		}
	}
}
