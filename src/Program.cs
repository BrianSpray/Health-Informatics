using System;
using System.IO;
using System.Text;
using Data;

public class Program {

    public static void Main() {
        Console.WriteLine("Launching Application...");

        DataSetIO dataSet = new DataSetIO();
        dataSet.CreateDataSet(1000);
    }
}