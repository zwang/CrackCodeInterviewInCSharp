using System;

namespace CrackCodeInterview
{
	public class Node
	{
		public Node (int data, Node next = null)
		{
			Data = data;
			Next = null;
		}

		public int Data { get; set; }
		public Node Next { get; set;}

		/// <summary>
		/// Deletes the self from linked list.
		/// 2.3 Implement an algorithm to delete a node in the middle of a single linked list, 
		/// given only access to that node. 
		/// EXAMPLE
		///	Input: the node ‘c’ from the linked list a->b->c->d->e
		///	Result: nothing is returned, but the new linked list looks like a->b->d->e
		/// </summary>
		/// <returns>
		/// The self. If self is the last one in the list, return null
		/// </returns>
		public Node DeleteSelfFromLinkedList ()
		{
			if (Next == null) {
				return null;
			} else {
				this.Data = Next.Data;
				this.Next = Next.Next;
			}
			return this;
		}
	}
}

