using System;

namespace CrackCodeInterview
{
	public class TwoDIndex :IEquatable<TwoDIndex>
	{
		public TwoDIndex ()
		{
		}

		public TwoDIndex (int r, int c)
		{
			Row = r;
			Column = c;
		}

		public int Row {
			get;
			set;
		}

		public int Column {
			get;
			set;
		}

		public string ToStringSimple ()
		{
			return string.Format ("({0},{1})", Row, Column);
		}

		public override string ToString ()
		{
			return string.Format ("[TwoDIndexResult: Row={0}, Column={1}]", Row, Column);
		}

		#region IEquatable implementation
		
		public bool Equals (TwoDIndex other)
		{
			return Row == other.Row && Column == other.Column;
		}
		
		#endregion
	}
}

