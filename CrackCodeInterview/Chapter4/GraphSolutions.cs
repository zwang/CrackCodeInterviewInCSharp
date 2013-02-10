using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace CrackCodeInterview
{
	public class GraphSolutions
	{
		/// <summary>
		/// Check if two nodes are connected in a graph.
		/// </summary>
		/// <param name="s">Source node</param>
		/// <param name="d">Destination node</param>
		/// <param name="edgesList">The edges of of the graph</param>
		/// <returns>true if from s to d there is path, otherwise false</returns>
		public static bool CheckifNodesConnectedInGraph(GraphNode<int> s, GraphNode<int> dest, List<GraphEdge<int>> edgesList)
		{
			var visitHistory = new Dictionary<GraphNode<int>, bool>();
			ExploreGraphDFS(s, edgesList, visitHistory);
			if (visitHistory.ContainsKey(dest) && visitHistory[dest])
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		private static void ExploreGraphDFS(GraphNode<int> graphNode, List<GraphEdge<int>> edgesList, Dictionary<GraphNode<int>, bool> visitHistory)
		{
			visitHistory[graphNode] = true;
			foreach (var edge in edgesList.Where(e => e.Start == graphNode))
			{
				if (!visitHistory.ContainsKey(edge.End) || visitHistory[edge.End] == false)
				{
					ExploreGraphDFS(edge.End, edgesList, visitHistory);
				}
			}
		}
	}
}

