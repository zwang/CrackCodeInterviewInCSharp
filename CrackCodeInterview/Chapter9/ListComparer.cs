using System;
using System.Collections.Generic;
using System.Text;


namespace CrackCodeInterview
{
	public class ListComparer: IEqualityComparer<List<int>>
	{
		public bool Equals(List<int> list1, List<int> list2)
		{
			list1.Sort();
			list2.Sort();
			if (list1 == null || list2 == null)
			{
				return list1 == list2;
			}
			if (list1.Count == list2.Count)
			{
				for (var i = 0; i < list1.Count; i++)
				{
					if (list1[i] != list2[i])
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}
		
		public int GetHashCode(List<int> list)
		{
			list.Sort();
			StringBuilder sb = new StringBuilder("");
			foreach (var s in list)
			{
				sb.Append(s);
			}
			return sb.ToString().GetHashCode();
		}
	}
}

