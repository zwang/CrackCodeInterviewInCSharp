using System;
using System.Collections.Generic;

namespace CrackCodeInterview
{
	public class TreeSolutions
	{
		/// <summary>
		/// Find all the path in a tree that node values' sum equals to certain value
		/// </summary>
		/// <param name="root">Root node of tree</param>
		/// <param name="sum">sum to look for</param>
		/// <param name="level">the lever of tree reached</param>
		/// <param name="buff">buff list to store current values in this path</param>
		public static void FindSumInATree(TreeNode<int> root, int sum, int level, List<int> buff)
		{
			if (root == null) return;
			buff.Add(root.Value);
			int tmp = sum;
			for (int i = level; i >= 0; i--)
			{
				tmp -= buff[i];
				if (tmp == 0) Output(buff, i, level);
			}
			//make copies
			var leftBuff = new List<int>(buff);
			var rightBuff = new List<int>(buff);
			FindSumInATree(root.Left, sum, level + 1, leftBuff);
			FindSumInATree(root.Right, sum, level + 1, rightBuff);
		}
		
		private static void Output(List<int> buff, int startLevel, int endLevel)
		{
			for (int i = startLevel; i <= endLevel; i++)
			{
				Console.Write("{0} ", buff[i]);
			}
			Console.WriteLine("");
		}
		
		
		/// <summary>
		/// Find the closest common ancestor of two nodes in a tree
		/// </summary>
		/// <param name="root">root noad of tree</param>
		/// <param name="target1">Target Node 1</param>
		/// <param name="target2">Target Node 2</param>
		/// <returns>The closest common ancestor node, null if not found.</returns>
		public static TreeNode<int> FindCommonAncestor(TreeNode<int> root, TreeNode<int> target1, TreeNode<int> target2)
		{
			if (target1 == null || target2 == null) return null;
			if (target1 == target2) return target1;
			if (target1 == root || target2 == root)
			{
				if (target1 == root)
				{
					bool isTarget2InTree = CheckIfInTheTree(target1, target2);
					if (isTarget2InTree) return root;
				}
				if (target2 == root)
				{
					bool isTarget1InTree = CheckIfInTheTree(target2, target1);
					if (isTarget1InTree) return root;
				}
				return null;
			}
			bool target1InLeftSubTree = CheckIfInTheTree(root.Left, target1);
			bool target2InLeftSubTree = CheckIfInTheTree(root.Left, target2);
			bool target1InRightSubTree = CheckIfInTheTree(root.Right, target1);
			bool target2InRightSubTree = CheckIfInTheTree(root.Right, target2);
			if ((target1InLeftSubTree && target2InRightSubTree)
			    || (target1InRightSubTree && target2InLeftSubTree))
			{
				return root;
			}
			else if (target1InLeftSubTree && target2InLeftSubTree)
			{
				return FindCommonAncestor(root.Left, target1, target2);
			}
			else if (target1InRightSubTree && target2InRightSubTree)
			{
				return FindCommonAncestor(root.Right, target1, target2);
			}
			return null;
		}
		
		private static bool CheckIfInTheTree(TreeNode<int> treeRoot, TreeNode<int> targetNode)
		{
			if (treeRoot == null)
			{
				return false;
			}
			else
			{
				return CheckIfInTheTree(treeRoot.Left, targetNode) || CheckIfInTheTree(treeRoot.Right, targetNode);
			}
		}

		/// <summary>
		/// Find a  node with the specified value in a binary search tree
		/// </summary>
		/// <param name="root">Root order of the tree</param>
		/// <param name="valueToSearch">The int value to search for</param>
		/// <returns>The found TreeNode or null if not found</returns>
		public static TreeNode<int> SearchInBST(TreeNode<int> currentNode, int valueToSearch)
		{
			if (currentNode == null) return null;
			if (currentNode.Value == valueToSearch)
			{
				return currentNode;
			}
			else if (currentNode.Value < valueToSearch)
			{
				return SearchInBST(currentNode.Right, valueToSearch);
			}
			else
			{
				return SearchInBST(currentNode.Left, valueToSearch);
			}
		}
		
		/// <summary>
		/// Insert a node to a Binary Search tree
		/// </summary>
		/// <param name="root">Root of the binary search tree</param>
		/// <param name="value">The value to insert</param>
		public static void InsertNodeToBinarySearchTree(TreeNode<int> root, int value)
		{
			if (root == null)
			{
				throw new ArgumentException("Tree root can not be null");
			}
			else if (root.Value > value)
			{
				if (root.Left != null)
				{
					InsertNodeToBinarySearchTree(root.Left, value);
				}
				else
				{
					root.Left = new TreeNode<int>(value);
				}
			}
			else if (root.Value < value)
			{
				if (root.Right != null)
				{
					InsertNodeToBinarySearchTree(root.Right, value);
				}
				else
				{
					root.Right = new TreeNode<int>(value);
				}
			}
			else
			{
				//For case: root.Value == value;
			}
		}

		/// <summary>
		/// Build a BST with minimum height from a sorted int array.
		/// </summary>
		/// <param name="array">Int array contains the data to build tree</param>
		/// <param name="startIndex">Start index</param>
		/// <param name="endIndex">End index</param>
		/// <returns>The root node of the tree</returns>
		public static TreeNode<int> BuildMinimumHeightBSTWithSortedArray(int[] array, int startIndex, int endIndex)
		{
			if (startIndex == endIndex)
			{
				return new TreeNode<int>(array[startIndex]);
			}
			else if (startIndex == endIndex - 1)
			{
				var n = new TreeNode<int>(array[endIndex]);
				n.Left = new TreeNode<int>(array[startIndex]);
				return n;
			}
			else if (startIndex == endIndex - 2)
			{
				var n = new TreeNode<int>(array[endIndex - 1]);
				n.Left = new TreeNode<int>(array[startIndex]);
				n.Right = new TreeNode<int>(array[endIndex]);
				return n;
			}
			else if (startIndex < endIndex - 2)
			{
				int midIndex = (endIndex - startIndex) / 2 + startIndex;
				var n = new TreeNode<int>(array[midIndex]);
				n.Left = BuildMinimumHeightBSTWithSortedArray(array, startIndex, midIndex - 1);
				n.Right = BuildMinimumHeightBSTWithSortedArray(array, midIndex + 1, endIndex);
				return n;
			}
			return null;
		}
		
		/// <summary>
		/// Check if a tree is a balance tree, of which the difference between max height and minimum height of leaves are no more than 1
		/// </summary>
		/// <param name="root">root node of tree</param>
		/// <returns>True if the tree is a balanced tree, otherwise false</returns>
		public static bool CheckIfBalanceTree(TreeNode<int> root)
		{
			int maxLevel = int.MinValue, minLevel = int.MaxValue;
			Queue<TreeNode<int>> queue = new Queue<TreeNode<int>>();
			queue.Enqueue(root);
			queue.Enqueue(null);
			int currentLevel = 0;
			while (queue.Count > 0)
			{
				TreeNode<int> n = queue.Dequeue();
				if (n != null)
				{
					if (n.Left == null && n.Right == null)
					{
						if (minLevel > currentLevel) minLevel = currentLevel;
						if (maxLevel < currentLevel) maxLevel = currentLevel;
					}
					else
					{
						if (n.Left != null)
						{
							queue.Enqueue(n.Left);
						}
						if (n.Right != null)
						{
							queue.Enqueue(n.Right);
						}
					}
				}
				else
				{
					if (queue.Count > 0)
					{
						queue.Enqueue(null);
					}
					currentLevel += 1;
				}
			}
			
			Console.WriteLine("MaxDepth: {0}; MinDepth: {1}", maxLevel, minLevel);
			if (maxLevel - minLevel > 1)
			{
				return false;
			}
			else
			{
				return true;
			}
		}


		/// <summary>
		/// Check if tree2 (hundred nodes) is a sub tree of tree1(millions nodes)
		/// </summary>
		/// <param name="tree1">Big tree 1</param>
		/// <param name="tree2">Small tree 2</param>
		/// <returns>true if tree2 is a sub tree of tree1</returns>
		public static bool CheckIfSubTree(TreeNode<int> tree1, TreeNode<int> tree2)
		{
			if (tree1 == null || tree2 == null) return false;
			if (tree1 == tree2)
			{
				bool match = CheckIfTree1ContainsTree2FromCurrentNode(tree1, tree2);
				if (match) return match;
			}
			return CheckIfSubTree(tree1.Left, tree2) || CheckIfSubTree(tree1.Right, tree2);
		}
		
		private static bool CheckIfTree1ContainsTree2FromCurrentNode(TreeNode<int> tree1, TreeNode<int> tree2)
		{
			if (tree2 == null) return true;
			if (tree1 == tree2 && tree1 == null)
			{
				return true;
			}
			bool isRootMatch = tree1 == tree2;
			return isRootMatch && CheckIfTree1ContainsTree2FromCurrentNode(tree1.Left, tree2.Left) && CheckIfTree1ContainsTree2FromCurrentNode(tree1.Right, tree2.Right);
		}
		
		/// <summary>
		/// Create a list of list of nodes from a Binary Search Tree(BST), that the list of nodes are the nodes at a certain level of BST.
		/// </summary>
		/// <param name="root">Root node of the BST</param>
		/// <returns>The result list</returns>
		public static List<List<TreeNode<int>>> CreateDepthListFromBST(TreeNode<int> root)
		{
			if (root == null) return null;
			var list = new List<List<TreeNode<int>>>();
			var levelQueue = new Queue<TreeNode<int>>();
			var flagNode = new TreeNode<int>(int.MinValue);
			var tempList = new List<TreeNode<int>>();
			levelQueue.Enqueue(root);
			levelQueue.Enqueue(flagNode);
			while (levelQueue.Count > 0)
			{
				var node = levelQueue.Dequeue();
				if (node == flagNode)
				{
					list.Add(tempList);
					if (levelQueue.Count > 0)
					{
						levelQueue.Enqueue(flagNode);
						tempList = new List<TreeNode<int>>();
					}
					else if (node != null)
					{
						tempList.Add(node);
						levelQueue.Enqueue(node.Left);
						levelQueue.Enqueue(node.Right);
					}
				}
			}
			return list;
		}
		
		public static TreeNode<int> FindNextNodeInOrder(TreeNode<int> root, TreeNode<int> target)
		{
			if (root == target)
			{
				// return root.Parent or root.Left or root.Left's rightest leaf
				if (root.Left != null)
				{
					TreeNode<int> temp = root.Left;
					while (temp.Left != null)
					{
						temp = temp.Left;
					}
					return temp;
				}
				else
				{
					if (root.Parent != null && root.Parent.Left == root)
					{
						return root.Parent;
					}
					else
					{
						return null;
					}
				}
			}
			TreeNode<int> node = FindNextNodeInOrder(root.Left, target);
			if (node == null) node = FindNextNodeInOrder(root.Right, target);
			return node;
		}
		

	}
}

