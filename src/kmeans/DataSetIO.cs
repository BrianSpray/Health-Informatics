using System;
using System.Collections.Generic;
using System.IO;

namespace kmeans
{
    public class DataSetIO
    {

        private String dataSetPath = @"./data/dataset.txt";

        private List<Patient> patients = new List<Patient>();

        public DataSetIO(bool newFile)
        {
            if (newFile)
            {
                CreateDataSetFile();
            }
        }

        // Only to be called upon during Instantiation of a new DataSetIO object. 
        // This method will clear the existing dataset.txt file and put in a file
        // Header listing off what each entry in the data set consists of.
        private void CreateDataSetFile()
        {
            String writeHeader = "patientId,age,gender,disease" + Environment.NewLine;

            if (!File.Exists(dataSetPath))
            {
                File.WriteAllText(dataSetPath, String.Empty);
            }
            else
            {
                File.WriteAllText(dataSetPath, String.Empty);
            }
        }

        // Writes the contents of the String parameter contents to the
        // dataset.txt file.
        private void WriteDataSetToFile(String contents)
        {
            String appendText = contents + Environment.NewLine;
            File.AppendAllText(dataSetPath, appendText);
        }

        // Creates the data to write to the dataset.txt file.
        // Patient Id is set based on the index of the for-loop.
        // Patient age is randomly determined from 0 to 100 years old.
        // Randomly selects gender and diseases from a string array.
        // Data is then passed to the WriteDataSetToFile function.
        public void CreateDataSet(int DataSetSize)
        {

            String[] gender = { "Male", "Female" };

            String[] disease = { "Cancer", "Heart Disease", "Diabetes", "Kidney Disease", "NULL" };

            Random random = new Random();

            for (int i = 0; i < DataSetSize; i++)
            {
                WriteDataSetToFile((String)(i + "," + random.Next(0, 100) + "," + gender[random.Next(0, gender.Length)] + "," + disease[random.Next(0, disease.Length)]));
            }
        }

        // Reads in the dataset and creates a Patient object from the data
        // The Patient object is then added to a list of patients.
        public void ReadDataSet()
        {
            var lines = File.ReadLines(dataSetPath);
            foreach (var line in lines)
            {
                String[] dataSegments = line.Split(',');
                patients.Add(new Patient(Convert.ToInt32(dataSegments[0]), Convert.ToInt32(dataSegments[1]), dataSegments[2], dataSegments[3]));
            }
        }

        // Returns the Patients List created by ReadDataSet
        public List<Patient> getPatientsList()
        {
            return patients;
        }
    }

}

