using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaxFlow
{
    class Graph<T>
    {
        private List<Node<T>> myNodes;

        private Edge<T>[,] myEdges;
        private int mySize;
        private List<Tuple<Node<T>, Node<T>>> myMatches;
        const int SOURCE = 0;
        const int SINK = 1;

        public Node<T> Source
        {
            get { return myNodes[SOURCE]; }
            set { myNodes[SOURCE] = value; }
        }
        public Node<T> Sink
        {
            get { return myNodes[SINK]; }
            set { myNodes[SINK] = value; }
        }

        public List<Tuple<Node<T>, Node<T>>> Matches
        {
            get
            {
                return myMatches;
            }
        }

        public Graph()
        {
            myNodes = new List<Node<T>>();
            myNodes.Add(new Node<T>());
            myNodes.Add(new Node<T>());
            myMatches = new List<Tuple<Node<T>, Node<T>>>();
        }

        public void AddNode(Node<T> n)
        {
            myNodes.Add(n);
        }

        public bool CreateEdge(Node<T> start, Node<T> end)
        {
            int x = myNodes.IndexOf(start);
            int y = myNodes.IndexOf(end);
            if (myEdges == null)
            {
                mySize = myNodes.Count;
                myEdges = new Edge<T>[mySize, mySize];
                for (int i = 0; i < mySize; i++)
                {
                    for (int j = 0; j < mySize; j++)
                    {
                        myEdges[i, j] = new Edge<T>();
                    }
                }
            }
            else if (myEdges[SOURCE, y].Capacity > 0 || myEdges[SINK, x].Capacity > 0)
                return false; //tried to add edge between two nodes on same side, did not work to remain bipartite

            //connection between start node(x) and end node(y)
            myEdges[x, y].Capacity = 1;
            myEdges[y, x].Capacity = -1;
            //connection between source och start node(x)
            myEdges[SOURCE, x].Capacity = 1;
            myEdges[x, SOURCE].Capacity = -1;
            //connection between sink och end node(y)
            myEdges[SINK, y].Capacity = -1;
            myEdges[y, SINK].Capacity = 1;

            return true;
        }

        public List<Edge<T>> DepthFirstSearch()
        {
            Stack<int> tempPath = new Stack<int>();
            DFS(SOURCE, tempPath);

            List<Edge<T>> path = new List<Edge<T>>();

            while (tempPath.Count > 1)
            {
                int value = tempPath.Pop();
                int key = tempPath.Peek();
                path.Add(myEdges[key, value]);
                if (key != SOURCE && value != SINK)
                    myMatches.Add(new Tuple<Node<T>, Node<T>>(myNodes[key], myNodes[value]));
            }

            return path;
        }

        private bool DFS(int current, Stack<int> aPath)
        {
            aPath.Push(current);
            if (current != SINK)
            {
                foreach (int granne in GetAdjacentNode(current))
                {
                    if (DFS(granne, aPath))
                        return true;
                }
                aPath.Pop();
                return false;
            }
            else
                return true;
        }


        private List<int> GetAdjacentNode(int current)
        {
            List<int> grannar = new List<int>();
            for (int next = 0; next < mySize; next++)
            {
                if (myEdges[current, next].CF > 0)//if capacity[current, next] > 0
                {
                    grannar.Add(next);
                }
            }
            return grannar;
        }

        public int FordFulkerson()
        {
            int f = 0;
            List<Edge<T>> path = DepthFirstSearch();
            while (path.Count > 0)
            {
                int minCF = int.MaxValue;
                foreach (Edge<T> edge in path)
                    if (edge.CF < minCF) minCF = edge.CF;

                foreach (Edge<T> edge in path)
                    edge.Flow += minCF;

                f += minCF;
                path = DepthFirstSearch();
            }

            return f; //max match
        }
    }
}