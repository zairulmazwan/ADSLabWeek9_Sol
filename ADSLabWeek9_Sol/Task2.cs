
    public class City 
    {
        public string city;
        public List<City> edges = new List<City>();
        
        public City(string v) {
            city = v;
        }
    }

    public class Task2 {
	
	public List<City> dfs = new List<City>();
	
        void addNode(City n) {
            dfs.Add(n);
        }
        
        void setEdge(City n1, City n2) {
            
            if (n1.edges.Contains(n2)==false) {
                n1.edges.Add(n2);
            }
            
            if (n2.edges.Contains(n1)==false) {
                n2.edges.Add(n1);
            }
        }

        public City getNode(string  n) {
            City res = null;
            for(int i=0; i<dfs.Count; i++) {
                if(dfs[i].city == n)
                    res = dfs[i];
            }
            return res;
        }
	
        public List<City> getEdges (City n) {
            int i = dfs.IndexOf(n);
            List<City> nn = dfs[i].edges;
            return nn;
        }
	
        public void printEdges (City n) {
            foreach (City x in n.edges ) {
                Console.Write(x.city+" ");
            }
        }
	
        public void printGraphNodes() {
            
            for (int i=0; i<dfs.Count; i++) {
                Console.Write(dfs[i].city+" ");
            }
        }
	
        public Boolean containNode (string  n) {
            
            Boolean res = false;
            foreach (City x in dfs) {
                if(x.city == n)
                    res = true;
            }
            return res;
        }
	
        public void traverseBFS(string nodeValue) {
            
            //Write your code here
        }
        
	
        public List<City> traverseDFSAlgo2 (string  nodeValue, List<City> visited) {
            
            if (containNode(nodeValue))
            {
                City firstNode = getNode(nodeValue);
                if (!visited.Contains(firstNode))
                    visited.Add(firstNode);

                for (int i=0; i<firstNode.edges.Count; i++)
                {
                    if (!visited.Contains(firstNode.edges[i]))
                    {
                        visited.Add(firstNode.edges[i]);
                        traverseDFSAlgo2(firstNode.edges[i].city, visited);
                    }
                }
            }
            return visited;
        }
	
        public void traverseDFSAlgo1 (string  nodeValue) {
            
            if (containNode(nodeValue))
            {
                City firstNode = getNode(nodeValue);
                List<City> nodes = new List<City>();
                nodes.Add(firstNode);
                List<City> visited = new List<City>();
                while(nodes.Count>0)
                {
                    City n = nodes[nodes.Count-1];
                    nodes.RemoveAt(nodes.Count - 1);
                    if (!visited.Contains(n))
                    {
                        Console.Write(n.city+" ");
                        visited.Add(n);
                        List<City> edges = getEdges(n);
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
	
        public void createGraph() 
        {
            //string [] cities = {"London","Manchester","Paris","Madrid","Istanbul","Dubai","Kuala Lumpur","Singapore","Tokyo","Sydney"};
            string [] cities = Files.getCities(@"/Users/zairulmazwan/Dotnet/ADSLabWeek9_Sol/ADSLabWeek9_Sol/Dataset.csv");
            int [,] data = Files.readData(@"/Users/zairulmazwan/Dotnet/ADSLabWeek9_Sol/ADSLabWeek9_Sol/Dataset.csv"); //Reading the dataset

            foreach(string city in cities) //Create nodes for all cities in this loop
            {
                City c = new City(city);
                addNode(c);
            }

            for (int i=0; i<cities.Length; i++) //reading the cities
            {
                string city = cities[i]; //getting the city's name
                // Console.WriteLine(city);

                for (int j=0; j<cities.Length; j++) 
                {
                    if (i!=j) //We need to avoid from reading the origin of the city
                    {
                        int val = data[i,j]; //Getting the values from the dataset
                        // Console.WriteLine(val);
                        // Console.WriteLine(cities[j]);
                        if (val == 1) //If there is a route
                        {
                            City c1 = getNode(city); //get the node for city from
                            City c2 = getNode(cities[j]); //get the node for city to
                            setEdge(c1, c2); //Setting the edge for the city
                        }
                    }
                }
            }
            
        }
        
        public void printNodes () {
            foreach(City x in dfs) {
                Console.WriteLine(x.city+" ");
            }
        }

        public void printNodesDFSAlgo2(List<City> DFSAlgo2)
        {
            foreach (City x in DFSAlgo2)
            {
                Console.Write(x.city + " ");
            }
        }
    }
