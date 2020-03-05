using System;
using System.Collections.Generic;

namespace Graph
{

    class EdgeNode
    {
        public VertexNode Destination;
        public int Weight;

        public EdgeNode(VertexNode d, int w){
            Destination = d;
            Weight = w;
        }
    }

    class VertexNode
    {
        public string vname;
        public bool mark;
        public Dictionary<string,EdgeNode> edges = new Dictionary<string, EdgeNode>();
        
        public VertexNode(string v){
            vname = v;
        }
    }

    public class Graph
    {
        Dictionary<string,VertexNode> vertices = new Dictionary<string, VertexNode>();

        public Graph()
        {

        }


        void AddVertex(string v)
        {
            vertices.Add(v, new VertexNode(v));
        }

        public void AddEdge(string s, string d, int w)
        {
            vertices[s].edges.Add(d, new EdgeNode(vertices[d],w));
        }

        public void MarkVertex(string v)
        {
            vertices[v].mark = true;
        }

        public void ClearMarks()
        {
            foreach(string key in vertices.Keys){
                vertices[key].mark = false;
            }
        }

        public bool IsMarked(string vertex)
        {
            return  vertices[vertex].mark;
        }

        public bool VertexExists(string v)
        {

            return vertices.ContainsKey(v);
        }

        public void GetToVertices(string v, Queue<string> q)
        {
            foreach(string key in vertices[v].edges.Keys){
                q.Enqueue(key);
            }

        }

        public bool EdgeExists(string s, string d)
        {

           return vertices[s].edges.ContainsKey(d);
        }

        public int WeightIs(string s, string d)
        {

            return vertices[s].edges[d].Weight;

        }

        public void Print()
        {
            Console.WriteLine("*******************************");
            Console.WriteLine("Vertex: Adjecent Vertices");
            Console.WriteLine("------------------------------");
            foreach(string vertexKey in vertices.Keys){
                string output = vertexKey+" : ";
                foreach(string edgeKey in vertices[vertexKey].edges.Keys){
                    output +=edgeKey +" ";
                }
                Console.WriteLine(output);
            }
            Console.WriteLine("*******************************");
        }

        public void DepthFirstSearch(string start, string end, Queue<string> q)
        {
        }

        public void BreadthFirstSearch(string start, string end, Queue<string> q)
        {

        }
    }



}
