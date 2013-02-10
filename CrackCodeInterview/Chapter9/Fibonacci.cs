using System;
using System.Linq;

namespace CrackCodeInterview
{
	public class Fibonacci
	{
		public static int GetFibonacciRecussive (int n)
		{
			if(n<0) return -1;
			if(n<=1) return n;
			return GetFibonacciRecussive(n-1) + GetFibonacciRecussive(n-2);
		}

		public static int GetFibonacciDP (int n)
		{
			int[] list = new int[n+1];
			foreach (int i in Enumerable.Range(0,n+1)) 
			{
				if(i<=1)
				{ 
					list[i] = i;
				}
				else
				{
					list[i] = list[i-1] + list[i-2];
				}
			}
			return list[n];
		}
	}
}

