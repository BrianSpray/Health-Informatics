using System;
using System.IO;
using System.Text;
using Data;

public class Program {

    public static void Main() {
        Console.WriteLine("Launching Application...");

        // Data Set Creation
        Console.WriteLine("Creating Dataset...");
        DataSetIO dataSet = new DataSetIO();
        dataSet.CreateDataSet(1000);
        Console.WriteLine("Created dataset.");
        dataSet.ReadDataSet();
    }
}