using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace CrackCodeInterview
{
	public class LinkedList
	{
		public LinkedList (Node node)
		{
			Head = node;
		}

		public LinkedList (List<Node> nodes)
		{
			if (nodes.Count == 0) {
				Head = null;
			} else {
				Head = nodes [0];
				for(var i = 1; i<nodes.Count; i++){
					AppendNewNode(nodes[i]);
				}
			}
		}

		public Node Head { get; set; }

		public void AppendNewNode (Node newNode)
		{
			if (Head == null) {
				Head = newNode;
			} else {
				Node n = Head;
				while(n.Next!=null){
					n=n.Next;
				}
				n.Next = newNode;
			}
		}

		public void DeleteNodeByValue (int data)
		{
			if (Head != null && Head.Data == data) {
				Head = Head.Next;
			} else if (Head != null) {
				Node n = Head;
				while(n.Next!=null){
					if(n.Next.Data==data){
						n.Next = n.Next.Next;
					}
					else{
						n=n.Next;
					}
				}
			}
		}

		public override string ToString ()
		{
			StringBuilder sb = new StringBuilder();
			Node n = Head;
			while (n!=null) {
				sb.Append(n.Data);
				sb.Append(" ");
				Console.Write(n.Data);
				Console.Write(" "); 
				n=n.Next;
			}
			sb.Append('\n');
			Console.WriteLine(" "); 
			return sb.ToString();
		}


		public void RemoveDuplicateNode(){
			//Check if Header is null
			if(Head==null) return;
			Hashtable table = new Hashtable();
			Node n = Head;
			table.Add(n.Data, n.Data);
			while(n.Next!=null){
				if(table.ContainsKey(n.Next.Data)){
					n.Next = n.Next.Next;
				}
				else {
					table.Add(n.Next.Data, n.Next.Data);
					n = n.Next;
				}
			}
		}

		public void RemoveDuplicateNodeWithoutHashTable ()
		{
			//Check if Header is null
			if (Head == null)
				return;
			Node n = Head;
			while (n!=null) {
				Node j = n.Next;
				while(j!=null && j.Data == n.Data){
					n.Next = n.Next.Next;
					j = n.Next;
				}
				while(j!=null && j.Next!=null){		
					if(j.Next.Data == n.Data){
						j.Next = j.Next.Next;
					}
					else {
						j = j.Next;
					}
				}
				n = n.Next;
			}
		}

		public Node FindTheNthToLastNode (int n)
		{
			if (Head == null) {
				return null;
			}
			Node h = Head;
			Node t = Head;
			int i = 0;
			while (i < n && t.Next!=null) {
				t = t.Next;
				i++;
			}
			if (i < n)
				return null;
			while (t.Next!=null) {
				t= t.Next;
				h = h.Next;
			}
			return h;
		}
	}
}

