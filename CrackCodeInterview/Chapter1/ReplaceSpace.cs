using System;

namespace CrackCodeInterview
{
	/// <summary>
	/// Write a method to replace all spaces in a string with ‘%20’.
	/// </summary>
	public class ReplaceSpace : IRun
	{
		private char[] source;
		public ReplaceSpace (char[] s) 
		{
			source = s;
		}

		public bool Run ()
		{
			int countOfSpace = 0;
			for (var i=0; i< source.Length; i++) {
				if (source [i] == ' ') {
					countOfSpace ++;
				}
			}
			var newS = new char[source.Length + countOfSpace * 2];
			int j = 0;
			for (var i=0; i < source.Length; i++) {
				if(source[i]==' '){
					newS[j++] = '%';
					newS[j++] = '2';
					newS[j++] = '0';
				}
				else{
					newS[j++] = source[i];
				}
			}

			Console.WriteLine("Result for Replace Space with %20");
			Console.Write("Original String:");
			foreach(char c in source) Console.Write(c);
			Console.WriteLine(" ");
			Console.Write("Result String:");
			foreach(char c in newS) Console.Write(c);
			Console.WriteLine(" ");
			return true;
		}
	}
	//TODO: Write a method to replace all '%20' in a string with space.
}

