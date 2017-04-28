using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;

namespace kmeans
{
    class ClusterIO
    {

        private static String kMeansOutput = @"./data/output.txt";

        private static String kMeansOutliersOutput = @"./data/outliers.txt";

        public static void ClearDataSet()
        {
            File.WriteAllText(kMeansOutput, String.Empty);
            File.WriteAllText(kMeansOutliersOutput, String.Empty);
        }

        public static void WriteClusters(int numberOfClusters, ArrayList clusters, int iteration, double distance)
        {
            for (int i = 0; i < numberOfClusters; i++)
            {
                Cluster cluster = (Cluster) clusters[i];
                plotCluster(cluster, iteration, distance);
            }
        }

        public static void WriteOutliers(ArrayList outliers)
        {
            for (int i = 0; i < outliers.Count; i++)
            {
                File.AppendAllText(kMeansOutliersOutput, "Outlier: " + ((Point) outliers[i]).xCoord + ", " + ((Point) outliers[i]).yCoord + Environment.NewLine);
            }
        }

        private static void plotCluster(Cluster cluster, int iteration, double distance)
        {
            File.AppendAllText(kMeansOutput, "=====Iteration: " + iteration + " Centroid Distance: " + distance + "=====" + Environment.NewLine);

            File.AppendAllText(kMeansOutput, "Cluster ID: " + cluster.clusterId + " Cluster Centroid: " + cluster.centroid.xCoord + ", " + cluster.centroid.yCoord + " Cluster Points: " + Environment.NewLine);
            foreach (Point point in cluster.clusterContents)
            {
               File.AppendAllText(kMeansOutput, "     Point: (" + point.xCoord + ", " + point.yCoord + ")" + Environment.NewLine);
            }
            File.AppendAllText(kMeansOutput, Environment.NewLine);
        }
    }
}
