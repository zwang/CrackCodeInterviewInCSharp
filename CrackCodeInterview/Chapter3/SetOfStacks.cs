using System;
using System.Collections.Generic;

namespace CrackCodeInterview
{
	/// <summary>
	/// Imagine a (literal) stack of plates. If the stack gets too high, it might topple. 
	/// Therefore, in real life, we would likely start a new stack when the previous stack exceeds some threshold. 
	/// Implement a data structure SetOfStacks that mimics this. 
	/// SetOfStacks should be composed of several stacks, and should create a new stack once the previous one exceeds capacity. 
	/// SetOfStacks.push() and SetOfStacks.pop() should behave identically to a single stack 
	/// (that is, pop() should return the same values as it would if there were just a single stack). 
	/// FOLLOW UP: Implement a function popAt(int index) which performs a pop operation on a specific sub-stack.
	/// </summary>
	public class SetOfStacks
	{
		List<Stack<int>> listOfStacks;
		int currentIndex;
		int maxItemPerStack;
		public SetOfStacks (int maxItemInStack)
		{
			listOfStacks = new List<Stack<int>>();
			listOfStacks.Add(new Stack<int>());
			currentIndex = 0;
			maxItemPerStack = maxItemInStack;
		}

		public int Pop ()
		{
			if (currentIndex == -1 || listOfStacks.Count == 0) {
				Console.WriteLine("Error: Stacks are empty");
				return int.MinValue;
			}
			var stack = listOfStacks [currentIndex];
			int data = stack.Pop ();
			if (stack.Count == 0) {
				listOfStacks.RemoveAt(currentIndex);
				currentIndex -= 1;
			}
			return data;
		}

		public int PopAt (int index)
		{
			if (currentIndex == -1 || listOfStacks.Count == 0 || listOfStacks.Count < index+1) {
				Console.WriteLine ("Error: the specified Stacks can not be found.");
				return int.MinValue;
			}
			var stack = listOfStacks [index];
			int data = stack.Pop ();
			if (stack.Count == 0) {
				listOfStacks.RemoveAt(index);
				currentIndex -= 1;
			}
			return data;
		}

		public void Push (int data)
		{
			if (listOfStacks.Count == 0) {
				listOfStacks.Add (new Stack<int> ());
				currentIndex = 0;
			}
			if (listOfStacks [currentIndex].Count == maxItemPerStack) {
				listOfStacks.Add (new Stack<int> ());
				currentIndex += 1;
			}
			listOfStacks [currentIndex].Push(data);
		}

		public bool IsEmpty(){
			return listOfStacks.Count == 0;
		}
	}
}

