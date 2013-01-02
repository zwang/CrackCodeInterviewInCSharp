using System;
using System.Collections;
using System.Collections.Generic;

namespace CrackCodeInterview
{
	/// <summary>
	/// Write a program to sort a stack in ascending order. 
	/// You should not make any assumptions about how the stack is implemented. 
	/// The following are the only functions that should be used to write this program: push | pop | peek | isEmpty.
	/// </summary>
	public class SortStack
	{
		public SortStack ()
		{
		}

		public static Stack<int> Sort (Stack<int> stack)
		{
			var t = new Stack<int>();
			while (stack.Count > 0) {
				int temp = stack.Pop();
				while(t.Count > 0 && t.Peek() < temp){
					stack.Push(t.Pop());
				}
				t.Push(temp);
			}
			return t;
		}

		public static void PrintStack (Stack<int> stack)
		{
			while (stack.Count > 0 ) {
				int n = stack.Pop();
				Console.Write(n);
				Console.Write(" ");
			}
		}
	}
}

