using System;
using CrackCodeInterview;
using NUnit.Framework;
using System.Linq;
namespace CrackCodeInterviewTest
{
	[TestFixture]
	public class RecursiveSolutionsTest
	{
		[TestCase()]
		public void TestPermunateString ()
		{
			string s= "hello";
			var list = RecursiveSolutions.PermulateString(s);
			Assert.AreEqual(60, list.Count);
		}
	}
}

