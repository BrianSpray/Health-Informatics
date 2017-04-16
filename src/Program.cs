using System;
using System.Collections.Generic;

public class Program {

    public static void Main() {
        Console.WriteLine("Launching Application...");

        // Data Set Creation
        Console.WriteLine("Creating Dataset...");
        DataSetIO dataSet = new DataSetIO();
        dataSet.CreateDataSet(1000);
        Console.WriteLine("Created dataset.");
        dataSet.ReadDataSet();

        List<Patient> patients = dataSet.getPatientsList();

        foreach (var patient in patients) {
            Console.WriteLine("The Patient Id is {0} their age is {1} their gender is {2} their disease is {3}.", patient.patientId, patient.patientAge, patient.patientGender, patient.patientDisease);
        }

        
    }
}