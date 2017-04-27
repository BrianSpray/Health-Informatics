using System;
using System.Collections;

public class Cluster {

    public int clusterId               { get; set; }
    public Point centroid              { get; set; }
    public ArrayList clusterContents   { get; set; }

    public Cluster(int clusterId) {
        this.clusterId = clusterId;
        this.centroid = null;
        this.clusterContents = new ArrayList();
    }

    public ArrayList GetPoints() {
        return clusterContents;
    }

    public void AddPoint(Point point) {
        clusterContents.Add(point);
    }

    public void Clear()
    {
        clusterContents.Clear();
    }

    public void plotCluster() {
        Console.WriteLine("[Cluster: " + clusterId + "]");
        Console.WriteLine("[Centroid: " + centroid.xCoord + ", " + centroid.yCoord + "]");
        Console.WriteLine("[Points: \n");
        foreach (Point point in clusterContents) {
            Console.WriteLine("     Point: (" + point.xCoord + ", " + point.yCoord + ")");
        }
        Console.WriteLine("]");
    }

}

