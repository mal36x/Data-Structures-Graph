using System;
using System.Collections.Generic;

namespace Graph
{

    class EdgeNode
    {
        VertexNode destination;
        int weight;
        EdgeNode nextEdge;


    }

    class VertexNode
    {
        string vname;
        bool mark;
        EdgeNode edgePtr;
        VertexNode nextVertex;
    }

    class Graph
    {
        VertexNode vertices;

        public Graph()
        {

        }


        void AddVertex(string v)
        {

        }

        public void AddEdge(string s, string d, int w)
        {

        }

        public void MarkVertex(string v)
        {

        }

        public void ClearMarks()
        {

        }

        public bool IsMarked(string vertex)
        {
            return true;
        }

        public bool VertexExists(string v)
        {

            return true;
        }

        public void GetToVertices(string v, Queue<string> q)
        {

        }

        public bool EdgeExists(string s, string d)
        {

            return true;
        }

        public int WeightIs(string s, string d)
        {

            return 0;

        }

        public void Print()
        {

        }

        public void DepthFirstSearch(string start, string end, Queue<string> q)
        {
        }

        public void BreadthFirstSearch(string start, string end, Queue<string> q)
        {
        }
    }



}
