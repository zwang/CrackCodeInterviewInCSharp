using System;
using System.Collections.Generic;

namespace CrackCodeInterview
{
	public class SearchArray
	{
		public static HashSet<int> FindNumbersAppearedOnce(int[] array)
		{
			if(array.Length == 0) return null;
			var onlyOnce = new HashSet<int>();
			var moreThanOnce = new HashSet<int>();
			foreach(int num in array){
				if(!moreThanOnce.Contains(num)){
					if(onlyOnce.Contains(num)){
						onlyOnce.Remove(num);
						moreThanOnce.Add(num);
					}
					else{
						onlyOnce.Add(num);
					}
				}
			}
			return onlyOnce;
		}
	}
}

