// Graphs graph = new Graphs();
// graph.createGraph();

// Console.WriteLine("Number of nodes in the graph : " + graph.dfs.Count);
// Console.WriteLine("Nodes in the graph are : ");
// graph.printNodes();

// Console.WriteLine("\nThe graph contains 60 ? : " + graph.containNode(60));

// Console.WriteLine("\nEdges in 20 : ");
// graph.printEdges(graph.dfs[1]);

// Console.WriteLine("\nEdges in 30 : ");
// graph.printEdges(graph.dfs[graph.dfs.IndexOf(graph.getNode(30))]);

// Console.WriteLine();

// Console.WriteLine("\nDFS Traverse starts from node 60 Algo 1 : ");
// graph.traverseDFSAlgo1(60);

// //Console.WriteLine("\nBFS Traverse starts from node 50 : ");
// //graph.traverseBFS(60);

// Console.WriteLine("\nDFS Traverse starts from node 60 Algo 2 : ");
// List<Node> visited = new List<Node>();
// graph.traverseDFSAlgo2(60, visited);
// graph.printNodesDFSAlgo2(visited);

//graph.printNodes();
//Console.WriteLine();

/*
//Windows - Can use this to read the file
string workingDirectory = Environment.CurrentDirectory;
string projectDir = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
string filePath = "\\Dataset.csv";
Console.WriteLine(projectDir+filePath);
*/

// int [,] data = Files.readData(@"/Users/zairulmazwan/Dotnet/ADSLabWeek9_Sol/ADSLabWeek9_Sol/Dataset.csv");
// string [] c = Files.getCities(@"/Users/zairulmazwan/Dotnet/ADSLabWeek9_Sol/ADSLabWeek9_Sol/Dataset.csv");
// Files.printHeader(c);
// Files.printData(data);
Task2 cities = new Task2();
cities.createGraph();
Console.WriteLine("Is there Kuala Lumpur in the graph? "+cities.containNode("Kuala Lumpur"));
Console.WriteLine("You can travel from KL to the following cities: ");
City KL = cities.getNode("Kuala Lumpur");
cities.printEdges(KL);


//©ZairulMazwan©