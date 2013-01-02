using System;

namespace CrackCodeInterview
{
	public class GetCircularStartNodeInList
	{
		LinkedList Lst;
		public GetCircularStartNodeInList (LinkedList list)
		{
			if (list == null) {
				throw new ArgumentNullException("List can not be null");
			}
			this.Lst = list;
		}

		public Node Run ()
		{
			Node h1 = Lst.Head;
			Node h2 = Lst.Head;
			while (h2!=null) {
				h1 = h1.Next;
				h2 = h2.Next;
				if (h2 != null) {
					h2 = h2.Next;
				}
				if (h2 == null || h2 == h1) {
					break;
				}
			}
			if (h2 == null)
				return null;
			h1 = Lst.Head;
			while (h1!=h2) {
				h1 = h1.Next;
				h2 = h2.Next;
			}
			Console.WriteLine("Loop start at " + h2.Data);
			return h2;
		}
	}
}

