using System;
using System.Collections;
using System.Collections.Generic;

namespace kmeans
{
    public class KMeansAlgorithm
    {

        private int numberOfClusters { get; set; }
        private int numberOfPoints { get; set; }
        private int minimumCoord { get; set; }
        private int maximumCoord { get; set; }
        private int clusterThreshold { get; set; }


        private ArrayList outliers;
        private ArrayList points;
        private ArrayList clusters;

        public KMeansAlgorithm()
        {
            this.outliers = new ArrayList();
            this.points = new ArrayList();
            this.clusters = new ArrayList();
        }

        public void DetermineInitialValues(List<Patient> patients)
        {
            numberOfClusters = 4;
            numberOfPoints = patients.Count;
            minimumCoord = 0;
            maximumCoord = 100;
            clusterThreshold = 9;
        }

        public void IntializePoints(Patient patient)
        {
            points.Add(new Point(patient.PatientGenderToInteger(patient.patientGender), patient.patientAge));
        }

        public void PlantSeeds()
        {

            Random random = new Random();

            for (int i = 0; i < numberOfClusters; i++)
            {
                Cluster cluster = new Cluster(i);
                Point centroid = new Point(2 * random.Next(minimumCoord, 15), random.Next(0, maximumCoord * random.Next(0, 3)));
                cluster.centroid = centroid;
                clusters.Add(cluster);
            }
            ClusterIO.WriteClusters(numberOfClusters, clusters, 0, 0);
        }

        public void DetermineOutliers()
        {

            foreach (Cluster cluster in clusters)
            {
                points = cluster.GetPoints();
                for (int i = 0; i < points.Count; i++)
                {
                    if (Point.EuclideanDistance((Point)points[i], cluster.centroid) > clusterThreshold)
                    {
                        outliers.Add(points[i]);
                        points.Remove(points[i]);
                    }
                }
            }
            ClusterIO.WriteClusters(numberOfClusters, clusters, 0, 0);
            ClusterIO.WriteOutliers(outliers);
        }


        private ArrayList GetCentroids()
        {
            ArrayList centroids = new ArrayList(numberOfClusters);
            foreach (Cluster cluster in clusters)
            {
                Point original = cluster.centroid;
                Point newPoint = new Point(original.xCoord, original.yCoord);
                centroids.Add(newPoint);
            }
            return centroids;
        }

        private void DeterminePointsInCluster()
        {
            int clusterId = 0;

            double maxValueInCluster = Double.MaxValue;
            double minValueInCluster = maxValueInCluster;
            double distance = 0.0;

            foreach (Point point in points)
            {
                minValueInCluster = maxValueInCluster;
                for (int i = 0; i < numberOfClusters; i++)
                {
                    Cluster clus = (Cluster)clusters[i];
                    distance = Point.EuclideanDistance(point, clus.centroid);
                    if (distance < minValueInCluster)
                    {
                        minValueInCluster = distance;
                        clusterId = i;
                    }
                }
                point.clusterId = clusterId;
                ((Cluster) clusters[clusterId]).AddPoint(point);
            }
        }


        private void SetClusters()
        {
            foreach (Cluster cluster in clusters)
            {
                int sumOfXCoords = 0;
                int SumOfYCoords = 0;
                ArrayList temp = cluster.GetPoints();
                int numberOfPoints = temp.Count;

                foreach (Point point in temp)
                {
                    sumOfXCoords += point.xCoord;
                    SumOfYCoords += point.yCoord;
                }

                Point centroid = cluster.centroid;
                if (numberOfPoints > 0)
                {
                    int newAverageXCoord = sumOfXCoords / numberOfPoints;
                    int newAverageYCoord = SumOfYCoords / numberOfPoints;
                    centroid.xCoord = newAverageXCoord;
                    centroid.yCoord = newAverageYCoord;
                }
            }
        }

        public void CalculateClusterContents()
        {

            bool exit = false;
            int iteration = 0;

            while (!exit)
            {

                foreach (Cluster cluster in clusters)
                {
                    cluster.Clear();
                }

                ArrayList lastCentroids = GetCentroids();

                DeterminePointsInCluster();
                SetClusters();
                iteration++;

                ArrayList currentCentroids = GetCentroids();

                iteration++;
                double distance = 0;
                for (int i = 0; i < lastCentroids.Count; i++)
                {
                    distance += Point.EuclideanDistance(((Point) lastCentroids[i]), ((Point) currentCentroids[i]));
                }
                ClusterIO.WriteClusters(numberOfClusters, clusters, iteration, distance);

                if (distance == 0)
                {
                    exit = true;
                }
            }
        }       
    }
}

