using System;

namespace CrackCodeInterview
{
	public class CircusPeople
	{
		public CircusPeople (int h, int w)
		{
			this.Weight = w;
			this.Height = h;
		}

		public int Weight {
			get;
			set;
		}

		public int Height {
			get;
			set;
		}

		public override string ToString ()
		{
			return string.Format ("(H={0}, W={1})", Height, Weight);
		}
	}
}

