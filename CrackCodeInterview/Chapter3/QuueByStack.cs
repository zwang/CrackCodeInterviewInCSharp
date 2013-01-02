using System;

namespace CrackCodeInterview
{
	/// <summary>
	/// Implement a MyQueue class which implements a queue using two stacks.
	/// </summary>
	public class QuueByStack
	{
		private NodeStack head;
		private NodeStack tail;
		public QuueByStack ()
		{
			head = new NodeStack();
			tail = new NodeStack();
		}

		public Node Dequeue ()
		{
			if (head.Peek () == null && tail.Peek()!=null) {
				//Copy from tail stack to head status in reverse order
				while(tail.Peek()!=null){
					head.Push(tail.Pop());
				}
			}
			return head.Pop();
		}

		public void Enqueue(Node newNode){
			tail.Push(newNode);
		}

		public bool IsEmpty(){
			return head.Peek() == null && tail.Peek() == null;
		}
	}
}

