using System;

namespace CrackCodeInterview
{
	public class RankTree
	{
		RankTreeNode root;

		public void Track (int newValue)
		{
			if (root == null) {
				root = new RankTreeNode (newValue);
			} else {
				root.InsertValue (newValue);
			}
		}

		public int GetRank (int value)
		{
			if (root == null) {
				return -1;
			}
			return root.GetRankOfValue(value);
		}
	}
}

