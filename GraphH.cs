using System;


namespace GraphH{

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


     VertexNode VertexExists(string v){

     return VertexExists;
     }
    
    EdgeNode EdgeExists(string s, string d){

        return 0;
    }

    int WeightIs(string s, string d){

        return 0;

    }



    }

}
