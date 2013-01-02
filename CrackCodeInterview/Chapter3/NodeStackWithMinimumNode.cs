using System;

namespace CrackCodeInterview
{
	/// <summary>
	/// How would you design a stack which, in addition to push and pop, 
	/// also has a function min which returns the minimum element? 
	/// Push, pop and min should all operate in O(1) time.
	/// </summary>
	public class NodeStackWithMinimumNode : NodeStack
	{
		private Node minimum;
		public NodeStackWithMinimumNode ()
		{
		}

		public override void Push (Node n)
		{
			base.Push (n);
			if (minimum == null) {
				minimum = n;
			}
			else if (n.Data < minimum.Data) {
				minimum = n;
			}
		}

		//For Pop to be operate in O(1) time, need to use an extra sorted List.
		//And when pop, check if the pop one is the minimum, if so, assign new minimum from the list.
		public override Node Pop ()
		{
			Node n = base.Pop ();
			if (minimum  == n && minimum != null && top != null) {
				minimum = top;
				Node temp = top;
				while(temp.Next!=null){
					if(temp.Next.Data<minimum.Data){
						minimum=temp.Next;
					}
					temp = temp.Next;
				}
			}
			return n;
		}

		public Node GetMinimum()
		{
			return minimum;
		}
	}
}

