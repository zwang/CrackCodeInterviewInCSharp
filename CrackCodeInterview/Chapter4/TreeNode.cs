using System;

namespace CrackCodeInterview
{
	public class TreeNode<T>
	{
		public TreeNode(T value)
		{
			this.Value = value;
			Left = null;
			Right = null;
		}
		
		public T Value { get; set; }
		public TreeNode<T> Left { get; set; }
		public TreeNode<T> Right { get; set; }
		public TreeNode<T> Parent { get; set; }
	}
}

