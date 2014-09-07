using System;

namespace CrackCodeInterview
{
	public class RotateArray
	{
		public static void RotateCharsArray(char[] array, int k)
		{
			int count = 0;
			foreach(var c in array){
				Console.Write(c);
			}
			Console.WriteLine("");
			int len = array.Length;
			k = k % len;
			for(int i=0;i<k;i++)
			{
				char tempC = array[i];
				int ti = i;
				int tiAdvance = i + k;
				while(tiAdvance%len != i){
					count ++;
					array[ti%len]= array[tiAdvance%len];
					ti+=k;
					tiAdvance+=k;
				}
				count++;
				array[ti%len] = tempC;
			}
			Console.WriteLine("Array after rotated");
			foreach(var c in array){
				Console.Write(c);
			}
			Console.WriteLine("\nExchange {0} times", count);
		}

		public static void RotateCharsArrayImproved(char[] array, int k)
		{
			foreach(var c in array){
				Console.Write(c);
			}
			Console.WriteLine("");
			int len = array.Length;
			k= k % len;
			reverseArray(array, 0, k-1);
			reverseArray(array, k, len-1);
			reverseArray(array, 0, len-1);
			Console.WriteLine("Array after rotated");
			foreach(var c in array){
				Console.Write(c);
			}
			Console.WriteLine("");
		}

		private static void reverseArray(char[] array, int start, int end)
		{
			while(start<end){
				char temp = array[start];
				array[start] = array[end];
				array[end] = temp;
				start +=1;
				end -=1;
			}
		}
	}
}

