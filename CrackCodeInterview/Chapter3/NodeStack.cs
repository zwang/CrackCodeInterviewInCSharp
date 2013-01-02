using System;

namespace CrackCodeInterview
{
	public class NodeStack
	{
		protected Node top;
		public NodeStack ()
		{
			top = null;
		}

		public virtual void Push (Node n)
		{
			n.Next = top;
			top = n;
		}

		public virtual Node Pop ()
		{
			if (top == null) {
				return null;
			} else {
				Node d = new Node(top.Data);
				top = top.Next;
				return d;
			}
		}

		public Node Peek()
		{
			return top;
		}

		public bool IsEmpty(){
			return top == null;
		}
	}
}

