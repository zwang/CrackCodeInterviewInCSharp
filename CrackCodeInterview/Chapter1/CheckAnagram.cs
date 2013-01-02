using System;
using System.Collections.Generic;

namespace CrackCodeInterview
{
	/// <summary>
	/// Write a method to decide if two strings are anagrams or not.
	/// </summary>
	public class CheckAnagram : IRun
	{
		private char[] source;
		private char[] target;

		public CheckAnagram (char[] s, char[] t)
		{
			source = s;
			target = t;
		}

		public bool Run ()
		{
			if (source.Length != target.Length) {
				OutPutResult (false);
				return false;
			}

			var dictForS = new Dictionary<char, int> ();
			var dictForT = new Dictionary<char, int> ();

			for (var i = 0; i < source.Length; i++) {
				if (dictForS.ContainsKey (source [i])) {
					dictForS [source [i]] += 1;
				} else {
					dictForS [source [i]] = 1;
				}
			}
			for (var i = 0; i < target.Length; i++) {
				if (dictForT.ContainsKey (target [i])) {
					dictForT [target [i]] += 1;
				} else {
					dictForT [target [i]] = 1;
				}
			}
			if (dictForS.Keys.Count != dictForT.Keys.Count) {
				OutPutResult(false);
				return false;
			}
			foreach (var key in dictForS.Keys) {
				if(!dictForT.ContainsKey(key) || dictForT[key] != dictForS[key]){
					OutPutResult(false);
					return false;
				}
			}
			OutPutResult(true);
			return true;
		}

		private void OutPutResult(bool isAnagram){
			Console.WriteLine("Result for Check Anagrams");
			Console.Write("String 1:");
			foreach(char c in source) Console.Write(c);
			Console.WriteLine(" ");
			Console.Write("String 2:");
			foreach(char c in target) Console.Write(c);
			Console.WriteLine(" ");
			Console.WriteLine("Are they anagrams? " + (isAnagram ? "Yes":"No"));
		}
	}
}

