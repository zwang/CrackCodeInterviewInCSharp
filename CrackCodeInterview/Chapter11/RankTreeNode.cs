using System;

namespace CrackCodeInterview
{
	public class RankTreeNode
	{
		public int Value { get; set; }
		public int LeftSize { get; set; }
		public RankTreeNode Left { get; set; }
		public RankTreeNode Right { get; set; }

		public RankTreeNode(int newValue)
		{
			this.Value = newValue;
		}

		public void InsertValue (int newValue)
		{
			if (newValue <= Value) {
				LeftSize++;
				if (Left == null) {
					Left = new RankTreeNode (newValue);
				} else {
					Left.InsertValue (newValue);
				}
			} else {
				if(Right == null){
					Right = new RankTreeNode(newValue);
				}
				else{
					Right.InsertValue(newValue);
				}
			}
		}

		public int GetRankOfValue (int value)
		{
			if (Value == value) {
				return LeftSize;
			}
			if (value < Value) {
				if(Left==null) return -1;
				return Left.GetRankOfValue(value);
			} else {
				int rightRank = Right == null ? -1 : Right.GetRankOfValue(value);
				if(rightRank ==-1) return -1;
				return rightRank + 1 + LeftSize;
			}
		}
	}
}

