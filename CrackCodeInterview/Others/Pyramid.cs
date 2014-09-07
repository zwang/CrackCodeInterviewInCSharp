using System;

namespace CrackCodeInterview
{
	public class Pyramid
	{
		/// <summary>
		///		 			1
		/// 			1		1
		/// 		1		2		1
		/// 	1		3		3		1
		/// 1		4		6		4		1
		/// </summary>
		/// <returns>The pyramid level.</returns>
		/// <param name="level">Level.</param>
		public static int[] GetPyramidLevel(int level)
		{
			int[] result = new int[level+1];
			for(int k=0;k<=level;k++){
				result[k]=1;
			}
			int i = 2;
			while(i<=level){
				int j = 1;
				int temp = result[j-1];
				for(;j<i;j++){
					int temp2 = temp+result[j];
					temp = result[j];
					result[j]= temp2;
				}
				i++;
			}
			return result;
		}
	}
}

