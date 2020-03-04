using System;


namespace Graph{

    class EdgeNode{
    VertexNode destination;
    int weight;
    EdgeNode nextEdge;


    }
    
    class VertexNode{
    string vname;
    bool mark;
    EdgeNode edgePtr;
    VertexNode nextVertex;
    }

    class Graph{
    VertexNode vertices;

    public Graph(){

    }

     ~Graph(){

    }

    void AddVertex(string v){

    }

    void AddEdge(string s, string d, int w){

    }


     bool VertexExists(string v){

     return true;
     }
    
    bool EdgeExists(string s, string d){

        return true;
    }

    int WeightIs(string s, string d){

        return 0;

    }



    }

}
