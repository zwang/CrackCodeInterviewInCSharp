using System;

namespace CrackCodeInterview
{
	/// <summary>
	/// Assume you have a method isSubstring which checks if one word is a substring of another. 
	/// Given two strings, s1 and s2, write code to check if s2 is a rotation of s1 using only 
	/// one call to isSubstring (i.e., “waterbottle” is a rotation of “erbottlewat”).
	/// </summary>
	public class CheckRotationWithIsSubstringMethod
	{
		string s1;
		string s2;

		public CheckRotationWithIsSubstringMethod (string str1, string str2)
		{
			if(str1 == null)
				throw new ArgumentNullException("str1 can not be null");
			if(str2 == null)
				throw new ArgumentNullException("str2 can not be null");
			s1 = str1;
			s2 = str2;
		}


		public bool Run ()
		{
			if (s1.Length > 0 && s2.Length > 0 && s1.Length == s2.Length) {
				bool result = isSubString(s1, s2+s2);
				if(result){
					Console.WriteLine(string.Format("{0} is a rotation of {1}.", s1, s2));
				}
				else{
					Console.WriteLine(string.Format("{0} is NOT a rotation of {1}.", s1, s2));
				}
				return result;
			}
			Console.WriteLine(string.Format("{0} is NOT a rotation of {1}.", s1, s2));
			return false;
		}

		//check if s1 is a substring of s2;
		private bool isSubString(string s1, string s2)
		{
			return s2.IndexOf(s1) > 0;
		}
	}
}

