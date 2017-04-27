using System;
using System.Collections.Generic;

public class Program {

    public static void Main() {
        Console.WriteLine("Launching Application...");

        // Data Set Creation
        Console.WriteLine("Creating Dataset...");
        DataSetIO dataSet = new DataSetIO();
        dataSet.CreateDataSet(25);

        Console.WriteLine("Created dataset.");
        dataSet.ReadDataSet();

        Console.WriteLine("Initializing K-Means Algorithm with default Values");
        KMeansAlgorithm kMeans = new KMeansAlgorithm();
        List<Patient> patients = dataSet.getPatientsList();

        kMeans.DetermineInitialValues(patients);

        foreach (var patient in patients) {
            kMeans.IntializePoints(patient);
        }

        kMeans.PlantSeeds();
        kMeans.CalculateClusterContents();
        kMeans.DetermineOutliers();
    }
}