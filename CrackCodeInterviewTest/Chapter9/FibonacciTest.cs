using System;
using NUnit.Framework;
using CrackCodeInterview;


namespace CrackCodeInterviewTest
{
	[TestFixture()]
	public class FibonacciTest
	{
		[Test()]
		public void GetFibonacciRecussiveTest ()
		{
			int resultR = Fibonacci.GetFibonacciRecussive (3);
			int resultRDP = Fibonacci.GetFibonacciDP (3);

			Assert.AreEqual (2, resultR);
			Assert.AreEqual (2, resultRDP);

			for (int i=0; i <10; i++) {
				resultR = Fibonacci.GetFibonacciRecussive (i);
				resultRDP = Fibonacci.GetFibonacciDP (i);
				Assert.AreEqual(resultR, resultRDP, "Two methods are returning same result");
			}
		}
	}
}

