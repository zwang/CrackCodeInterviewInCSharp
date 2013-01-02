using System;
using System.Collections.Generic;

namespace CrackCodeInterview
{
	public class TowerOfHanoi
	{
		Stack<int>[] stacks = new Stack<int>[3];
		public TowerOfHanoi (int n)
		{
			stacks = new Stack<int>[3];
			for (var i = 0; i<3; i++) {
				stacks[i] = new Stack<int>();
			}
			for (var i = n; i>0; i--)
			{
				stacks[0].Push(i);
			}
		}

		public void StartMove()
		{
			Move(stacks[0].Count, 0, 2, 1);
			//Output
			while(stacks[0].Count > 0){
				Console.Write(stacks[2].Pop());
				Console.Write(" ");
			}
			Console.WriteLine(" ");
			while(stacks[1].Count > 0){
				Console.Write(stacks[2].Pop());
				Console.Write(" ");
			}
			Console.WriteLine(" ");
			while(stacks[2].Count > 0){
				Console.Write(stacks[2].Pop());
				Console.Write(" ");
			}
		}

		public void Move (int n, int source, int target, int buffer)
		{
			if (n > 0) {
				Move (n-1, source, buffer, target);
				MoveTopTo(source, target);
				Move (n-1, buffer, target, source);
			}
		}

		public void MoveTopTo (int source, int target)
		{
			int top = stacks [source].Pop ();
			if (stacks [target].Count > 0 && stacks [target].Peek () < top) {
				Console.WriteLine(string.Format("Error for move. {0} < {1}", stacks [target].Peek (), top));
			} else {
				stacks [target].Push (top);
			}
			string msg = string.Format("Move {0} from {1} to {2}", top, source+1, target+1);
			Console.WriteLine(msg);
		}
	}
}

