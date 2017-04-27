using System;
using System.Collections.Generic;
using kmeans;

public class Program {

    public static void Main() {

        String userInput;

        Console.WriteLine("Would you like to Run Problem 1 or Problem 2? [1/2]");
        userInput = Console.ReadLine();

        if (userInput.Equals("1")) {

            DataSetIO dataSet;

            Console.WriteLine("Would you like to create a new data set? [y/n]");
            userInput = Console.ReadLine();

            if (userInput.Equals("y")) {
                dataSet = new DataSetIO(true);
                Console.WriteLine("How many entries would you like in your data set? [Any Number]");
                userInput = Console.ReadLine();
                dataSet.CreateDataSet(Convert.ToInt32(userInput));
                Console.WriteLine("Created dataset.");
            } else {
                dataSet = new DataSetIO(false);
                Console.WriteLine("Using Existing Dataset");
            }           

            dataSet.ReadDataSet();

            KMeansAlgorithm kMeans = new KMeansAlgorithm();
            List<Patient> patients = dataSet.getPatientsList();

            kMeans.DetermineInitialValues(patients);

            foreach (var patient in patients) {
                kMeans.IntializePoints(patient);
            }

            kMeans.PlantSeeds();
            kMeans.CalculateClusterContents();
            kMeans.DetermineOutliers();

        } else {

        }       
    }
}