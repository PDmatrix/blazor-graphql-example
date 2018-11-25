using System.Collections.Generic;

namespace BlazorDB.App.Models
{
	public abstract class Node
	{
		public string NodeId { get; set; }
	}
	
	public class ConnectionGraphQl<T>
	{
		public ICollection<T> Nodes { get; set; }
		public ICollection<Edge<T>> Edges { get; set; }
		public PageInfo PageInfo { get; set; }
		public int TotalCount { get; set; }
	}

	public class PageInfo
	{
		public bool HasNextPage { get; set; }
		public bool HasPreviousPage { get; set; }
		public string StartCursor { get; set; }
		public string EndCursor { get; set; }
	}

	public class Edge<T>
	{
		public string Cursor { get; set; }
		public T Node { get; set; }
	}
}