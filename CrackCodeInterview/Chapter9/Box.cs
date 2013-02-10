using System;

namespace CrackCodeInterview
{
	public class Box
	{
		public int Height { get; set; }
		public int Width { get; set; }
		public int Depth { get; set; }
		public Box (int h, int w, int d)
		{
			this.Height = h;
			this.Width = w;
			this.Depth = d;
		}

		public bool CanStackAbove (Box bottomBox)
		{
			if (bottomBox == null || bottomBox == this) {
				return false;
			}
			return this.Height <= bottomBox.Height
				&& this.Width <= bottomBox.Width
				&& this.Depth <= bottomBox.Depth;
		}

		public override string ToString ()
		{
			return string.Format ("({0},{1},{2})", Height, Width, Depth);
		}
	}
}

