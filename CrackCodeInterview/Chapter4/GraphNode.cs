using System;

namespace CrackCodeInterview
{
	public class GraphNode<T>
	{
		public T Value { get; set; }
	}
	
	public class GraphEdge<T>
	{
		public GraphNode<T> Start { get; set; }
		public GraphNode<T> End { get; set; }
		
		public GraphEdge(GraphNode<T> start, GraphNode<T> end)
		{
			this.Start = start;
			this.End = end;
		}
	}
}

