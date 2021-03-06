﻿using System;
using System.Collections;
namespace kmeans
{

    public class Cluster
    {

        public int clusterId { get; set; }
        public Point centroid { get; set; }
        public ArrayList clusterContents { get; set; }

        public Cluster(int clusterId)
        {
            this.clusterId = clusterId;
            this.centroid = null;
            this.clusterContents = new ArrayList();
        }

        public ArrayList GetPoints()
        {
            return clusterContents;
        }

        public void AddPoint(Point point)
        {
            clusterContents.Add(point);
        }

        public void Clear()
        {
            clusterContents.Clear();
        }

    }
}