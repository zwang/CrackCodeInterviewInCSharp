using System;
using System.Text;

namespace CrackCodeInterview
{
	/// <summary>
	/// You have two numbers represented by a linked list, where each node contains a single digit. 
	/// The digits are stored in reverse order, such that the 1’s digit is at the head of the list. 
	/// Write a function that adds the two numbers and returns the sum as a linked list.
	/// EXAMPLE
	///	Input: (3 -> 1 -> 5) + (5 -> 9 -> 2)
	///	Output: 8 -> 0 -> 8
	/// </summary>
	public class ListAddition : IRun
	{
		LinkedList listOne;
		LinkedList listTwo;
		public ListAddition (LinkedList list1, LinkedList list2)
		{
			listOne = list1;
			listTwo = list2;
		}

		public bool Run ()
		{
			Node head = new Node (-1);
			Node h = head;
			int addition = 0;
			if (listOne.Head == null || listTwo.Head == null) {
				if(listOne.Head == null){
					head = listTwo.Head;
				}
				else {
					head = listOne.Head;
				}
			} else {
				Node head1 = listOne.Head;
				Node head2 = listTwo.Head;
				head.Data = listOne.Head.Data + listTwo.Head.Data;
				if(head.Data >= 10){
					// listOne and listTwo's nodes' data should all be less than 10
					head.Data = head.Data-10;
					addition = 1;
				}
				else{
					addition = 0;
				}
				while(head1.Next!=null && head2.Next!=null){
					int newData = head1.Next.Data + head2.Next.Data + addition;
					if(newData>=10){
						newData -= 10;
						addition = 1;
					}
					else{
						addition = 0;
					}
					Node newNode = new Node(newData);
					h.Next = newNode;
					h = h.Next;
					head1 = head1.Next;
					head2 = head2.Next;
				}
				if(head1.Next==null && head2.Next == null){
					if(addition == 1){
						Node newNode = new Node(1);
						h.Next = newNode;
					}
				}
				else if(head1.Next==null){
					while(head2.Next!=null){
						int newData = head2.Next.Data + addition;
						if(newData>=10){
							newData -= 10;
							addition = 1;
						}
						else{
							addition = 0;
						}
						Node newNode = new Node(newData);
						h.Next = newNode;
						h = h.Next;
						head2 = head2.Next;
					}
				} else if(head2.Next == null) {
					while(head1.Next!=null){
						int newData = head1.Next.Data + addition;
						if(newData>=10){
							newData -= 10;
							addition = 1;
						}
						else{
							addition = 0;
						}
						Node newNode = new Node(newData);
						h.Next = newNode;
						h = h.Next;
						head1 = head1.Next;
					}
				}
			}
			Console.WriteLine("List Addition Result: ");
			Node n = head;
			while (n!=null) {
				Console.Write(n.Data);
				Console.Write(" "); 
				n=n.Next;
			}
			Console.WriteLine(" ");
			return true;
		}
	}
}

