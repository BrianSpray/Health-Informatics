using System;
using System.Collections;
using System.Collections.Generic;


public class KMeansAlgorithm {

    private int numberOfClusters { get; set; }
    private int numberOfPoints   { get; set; }
    private int minimumCoord     { get; set; }
    private int maximumCoord     { get; set; }
    private int clusterThreshold { get; set; }


    private ArrayList outliers;
    private ArrayList points;
    private ArrayList clusters;

    public KMeansAlgorithm() {
        this.outliers = new ArrayList();
        this.points = new ArrayList();
        this.clusters = new ArrayList();
    }

    public void DetermineInitialValues(List<Patient> patients) {
        numberOfClusters = 4;
        numberOfPoints   = patients.Count;
        minimumCoord     = 0;
        maximumCoord     = 100;
        clusterThreshold = 5;
    }

    public void IntializePoints(Patient patient) {
        points.Add(new Point(patient.PatientGenderToInteger(patient.patientGender), patient.patientAge));
    }

    public void PlantSeeds() {        

        Random random = new Random();

        for (int i = 0; i < numberOfClusters; i++) {
            Cluster cluster = new Cluster(i);
            Point centroid = new Point(2 * random.Next(minimumCoord, 15), random.Next(0, maximumCoord * random.Next(0, 3)));
            cluster.centroid = centroid;
            clusters.Add(cluster);
        }
        printClusters();

    }

    public void DetermineOutliers() {

        foreach (Cluster cluster in clusters) {
            points = cluster.GetPoints();
            for (int i = 0; i < points.Count; i++) {
                if (Point.EuclideanDistance((Point) points[i], cluster.centroid) > clusterThreshold) {
                    outliers.Add(points[i]);
                    points.Remove(points[i]);
                }
            }  
        }
        printClusters();
    }

    private void clearClusters() {
        foreach (Cluster cluster in clusters) {
            cluster.Clear();
        }
    }

    private ArrayList getCentroids() {
        ArrayList centroids = new ArrayList(numberOfClusters);
        foreach(Cluster cluster in clusters) {
            Point auxillary = cluster.centroid;
            Point point = new Point(auxillary.xCoord, auxillary.yCoord);
            centroids.Add(point);
        }
        return centroids;
    }

    private void assignCluster() {
        double max = Double.MaxValue;
        double min = max;
        int cluster = 0;
        double distance = 0.0;

        foreach (Point point in points) {
            min = max;
            for (int i = 0; i < numberOfClusters; i++) {
                Cluster clus = (Cluster) clusters[i];
                distance = Point.EuclideanDistance(point, clus.centroid);
                if (distance < min) {
                    min = distance;
                    cluster = i;
                }
            }
            point.clusterId = cluster;
            ((Cluster)clusters[cluster]).AddPoint(point);           
        }
    }


    private void calculateCentroids() {
        foreach (Cluster cluster in clusters) {
            int sumX = 0;
            int sumY = 0;
            ArrayList temp = cluster.GetPoints();
            int numberOfPoints = temp.Count;

            foreach (Point point in temp) {
                sumX += point.xCoord;
                sumY += point.yCoord;
            }

            Point centroid = cluster.centroid;
            if (numberOfPoints > 0)
            {
                int newX = sumX / numberOfPoints;
                int newY = sumY / numberOfPoints;
                centroid.xCoord = newX;
                centroid.yCoord = newY;
            }
        }
    }

    public void CalculateClusterContents() {

        bool finish = false;
        int iteration = 0;

        while (!finish) {

            clearClusters();

            ArrayList lastCentroids = getCentroids();

            assignCluster();

            calculateCentroids();

            iteration++;

            ArrayList currentCentroids = getCentroids();

            double distance = 0;

            for (int i = 0; i < lastCentroids.Count; i++) {
                distance += Point.EuclideanDistance(((Point) lastCentroids[i]), ((Point) currentCentroids[i]));
            }
            Console.WriteLine("###################");
            Console.WriteLine("Iteration " + iteration);
            Console.WriteLine("Centroid distances " + distance);
            printClusters();

            if (distance == 0 ) {
                finish = true;
            }
        }

    }


    private void printClusters()
    {
        for (int i = 0; i < numberOfClusters; i++) {
            Cluster cluster = (Cluster) clusters[i];
            cluster.plotCluster();
        }
    }


}

