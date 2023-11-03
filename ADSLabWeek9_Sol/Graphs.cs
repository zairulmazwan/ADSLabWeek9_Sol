
using System.Collections.Generic;
using System.Dynamic;

public class Node {
	
	public int value;
	public List<Node> edges = new List<Node>();
	
	public Node(int v) {
		value = v;
	}
}

public class Graphs {
	
	public List<Node> dfs = new List<Node>();
	
    void addNode(Node n) {
		dfs.Add(n);
	}
	
	void setEdge(Node n1, Node n2) {
		
		if (n1.edges.Contains(n2)==false) {
			n1.edges.Add(n2);
		}
		
		if (n2.edges.Contains(n1)==false) {
			n2.edges.Add(n1);
		}
	}

	public Node getNode(int n) {
		Node res = null;
		for(int i=0; i<dfs.Count; i++) {
			if(dfs[i].value == n)
				res = dfs[i];
		}
		return res;
	}
	
	public List<Node> getEdges (Node n) {
		int i = dfs.IndexOf(n);
		List<Node> nn = dfs[i].edges;
		return nn;
	}
	
	public void printEdges (Node n) {
		foreach (Node x in n.edges ) {
			Console.Write(x.value+" ");
		}
	}
	
	public void printGraphNodes() {
		
		for (int i=0; i<dfs.Count; i++) {
			Console.Write(dfs[i].value+" ");
		}
	}
	
	public Boolean containNode (int n) {
		
		Boolean res = false;
		foreach (Node x in dfs) {
			if(x.value == n)
				res = true;
		}
		return res;
	}
	
	public void traverseBFS(int nodeValue) {
		
		//Write your code here
	}
	
	
	public List<Node> traverseDFSAlgo2 (int nodeValue, List<Node> visited) {
		
		if (containNode(nodeValue))
		{
			Node firstNode = getNode(nodeValue);
			if (!visited.Contains(firstNode))
				visited.Add(firstNode);

			for (int i=0; i<firstNode.edges.Count; i++)
			{
				if (!visited.Contains(firstNode.edges[i]))
				{
					visited.Add(firstNode.edges[i]);
					traverseDFSAlgo2(firstNode.edges[i].value, visited);
				}
			}
		}
		return visited;
	}
	
	public void traverseDFSAlgo1 (int nodeValue) {
		
		if (containNode(nodeValue))
		{
			Node firstNode = getNode(nodeValue);
			List<Node> nodes = new List<Node>();
			nodes.Add(firstNode);
			List<Node> visited = new List<Node>();
			while(nodes.Count>0)
			{
				Node n = nodes[nodes.Count-1];
				nodes.RemoveAt(nodes.Count - 1);
				if (!visited.Contains(n))
				{
					Console.Write(n.value+" ");
					visited.Add(n);
					List<Node> edges = getEdges(n);
					for (int i=0; i<edges.Count; i++)
					{
						nodes.Add(edges[i]);
					}
				}
			}
		}
		else
		{
			Console.WriteLine("There is no node"+nodeValue);
		}
	}
	
	public void createGraph() {

		Node a = new Node(10);
		Node b = new Node(20);
		Node c = new Node(30);
		Node d = new Node(40);
		Node e = new Node(50);
		Node f = new Node(60);
		
		addNode(a);
		addNode(b);
		addNode(c);
		addNode(d);
		addNode(e);
		addNode(f);
		
		//edges for a - 10
		setEdge(a,b);
		setEdge(a,e);
		
		//edges for b - 20
		setEdge(b,a);
		setEdge(b,c);
		setEdge(b,f);
		
		//edges for c - 30
		setEdge(c,b);
		setEdge(c,d);
		setEdge(c,e);
		
		//edges for d - 40
		setEdge(d,c);
		
		//edges for e - 50
		setEdge(e,a);
		setEdge(e,c);
		
		//edges for f - 60
		setEdge(f,b);
		
	}
	
	public void printNodes () {
		foreach(Node x in dfs) {
			Console.WriteLine(x.value+" ");
		}
	}

    public void printNodesDFSAlgo2(List<Node> DFSAlgo2)
    {
        foreach (Node x in DFSAlgo2)
        {
            Console.Write(x.value + " ");
        }
    }

}