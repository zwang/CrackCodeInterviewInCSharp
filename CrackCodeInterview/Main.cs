using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace CrackCodeInterview
{
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
		}
	}
}
