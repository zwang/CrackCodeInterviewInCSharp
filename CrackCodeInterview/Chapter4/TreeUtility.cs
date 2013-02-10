using System;
using System.Collections.Generic;

namespace CrackCodeInterview
{
	public class TreeUtility
	{
		/// <summary>
		/// Build a tree for testing purpose.
		/// </summary>
		/// <returns>The root node of the tree</returns>
		public static TreeNode<int> BuildTree()
		{
			TreeNode<int> root = new TreeNode<int>(5);
			TreeNode<int> l2l = new TreeNode<int>(3);
			TreeNode<int> l2r = new TreeNode<int>(6);
			root.Left = l2l;
			root.Right = l2r;
			
			TreeNode<int> l31 = new TreeNode<int>(1);
			TreeNode<int> l32 = new TreeNode<int>(4);
			TreeNode<int> l33 = new TreeNode<int>(7);
			
			l2l.Left = l31;
			l2l.Right = l32;
			l2r.Right = l33;
			
			TreeNode<int> l41 = new TreeNode<int>(2);
			TreeNode<int> l51 = new TreeNode<int>(3);
			TreeNode<int> l61 = new TreeNode<int>(4);
			TreeNode<int> l62 = new TreeNode<int>(5);
			
			l31.Left = l41;
			l41.Left = l51;
			l51.Left = l61;
			l51.Right = l62;
			
			return root;
		}
		
		/// <summary>
		/// Build a Binary search tree for testing purpose
		/// </summary>
		/// <returns>The root node of the tree</returns>
		public static TreeNode<int> BuildBinarySearchTree()
		{
			TreeNode<int> root = new TreeNode<int>(15);
			TreeNode<int> l2l = new TreeNode<int>(13);
			TreeNode<int> l2r = new TreeNode<int>(20);
			root.Left = l2l;
			root.Right = l2r;
			
			TreeNode<int> l31 = new TreeNode<int>(11);
			TreeNode<int> l32 = new TreeNode<int>(14);
			TreeNode<int> l33 = new TreeNode<int>(17);
			
			l2l.Left = l31;
			l2l.Right = l32;
			l2r.Right = l33;
			
			TreeNode<int> l41 = new TreeNode<int>(9);
			TreeNode<int> l51 = new TreeNode<int>(6);
			TreeNode<int> l61 = new TreeNode<int>(5);
			TreeNode<int> l62 = new TreeNode<int>(7);
			
			l31.Left = l41;
			l41.Left = l51;
			l51.Left = l61;
			l51.Right = l62;
			
			return root;
		}
		
		public static void PrintTreeByInOrder(TreeNode<int> root)
		{
			if (root == null) return;
			PrintTreeByInOrder(root.Left);
			Console.Write("{0} ", root.Value);
			PrintTreeByInOrder(root.Right);
		}
		
		public static void PrintTreeByPreOrder(TreeNode<int> root)
		{
			if (root == null) return;
			Console.Write("{0} ", root.Value);
			PrintTreeByPreOrder(root.Left);
			PrintTreeByPreOrder(root.Right);
		}
		
		public static void PrintTreeByPostOrder(TreeNode<int> root)
		{
			if (root.Left != null)
			{
				PrintTreeByPostOrder(root.Left);
			}
			if (root.Right != null)
			{
				PrintTreeByPostOrder(root.Right);
			}
			Console.Write("{0} ", root.Value);
		}
		
		public static void PrintTreeByLevel(TreeNode<int> root)
		{
			var newLevelNode = new TreeNode<int>(int.MinValue);
			Console.WriteLine("\nLevel by Level Travesal: ");
			var queue = new Queue<TreeNode<int>>();
			queue.Enqueue(root);
			queue.Enqueue(newLevelNode);
			while (queue.Count > 0)
			{
				TreeNode<int> n = queue.Dequeue();
				if (n == null)
				{
					Console.Write("- ");
				}
				else if (n == newLevelNode)
				{
					Console.WriteLine(" ");
					if (queue.Count > 0)
					{
						queue.Enqueue(newLevelNode);
					}
				}
				else
				{
					Console.Write("{0} ", n.Value);
					queue.Enqueue(n.Left);
					queue.Enqueue(n.Right);
				}
			}
		}


//TreeNode<int> root = BuildTree();
//bool isBalanced = TreeAndGraph.CheckIfBalanceTree(root);
//Console.WriteLine("Is balanced: {0}", isBalanced);
//
//PrintTreeByLevel(root);
//Console.WriteLine("In-Order Travesal: ");
//PrintTreeByInOrder(root);
//Console.WriteLine("\nPre-Order Travesal: ");
//PrintTreeByPreOrder(root);
//Console.WriteLine("\nPost-Order Travesal: ");
//PrintTreeByPostOrder(root);
//
//var bst = BuildBinarySearchTree();
//PrintTreeByLevel(bst);
//
//var node = TreeAndGraph.SearchInBST(bst, 11);
//if (node != null)
//{
//	PrintTreeByLevel(node);
//}
//
//TreeAndGraph.InsertNodeToBinarySearchTree(bst, 12);
//TreeAndGraph.InsertNodeToBinarySearchTree(bst, 13);
//PrintTreeByLevel(bst);
//
//node = TreeAndGraph.SearchInBST(bst, 12);
//if (node != null)
//{
//	PrintTreeByLevel(node);
//}
//
//int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
//var bstRoot = TreeAndGraph.BuildMinimumHeightBSTWithSortedArray(array, 0, array.Length - 1);
//PrintTreeByLevel(bstRoot);
	}
}

