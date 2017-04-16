namespace Data {

    using System;
    using System.IO;
    using System.Text;

    public class DataSetIO {

        private static String dataSetPath = @"data/dataset.txt";
        
        public DataSetIO() {
            CreateDataSetFile();
        }

        // Only to be called upon during Instantiation of a new DataSetIO object. 
        // This method will clear the existing dataset.txt file and put in a file
        // Header listing off what each entry in the data set consists of.
        private void CreateDataSetFile() {
            String writeHeader = "patientId,age,gender,disease" + Environment.NewLine;

            if (!File.Exists(dataSetPath)) {            
                File.WriteAllText(dataSetPath, writeHeader);
            } else {
                File.WriteAllText(dataSetPath, String.Empty);
                File.WriteAllText(dataSetPath, writeHeader);
            }   
        }

        // Writes the contents of the String parameter contents to the
        // dataset.txt file.
        private void WriteDataSetToFile(String contents) {        
            String appendText = contents + Environment.NewLine;
            File.AppendAllText(dataSetPath, appendText);
        }

        // Creates the data to write to the dataset.txt file.
        // Patient Id is set based on the index of the for-loop.
        // Patient age is randomly determined from 0 to 100 years old.
        // Randomly selects gender and diseases from a string array.
        // Data is then passed to the WriteDataSetToFile function.
        public void CreateDataSet(int DataSetSize) {
            
            String[] gender  = { "Male", "Female"};

            String[] disease = { "Cancer", "Heart Disease", "Diabetes", "Kidney Disease", "NULL"};
            
            Random random = new Random();

            for (int i =0; i < DataSetSize; i++) {
                WriteDataSetToFile((String) (i + "," + random.Next(0, 100) + "," + gender[random.Next(0, gender.Length)] + "," + disease[random.Next(0, disease.Length)]));
            }
        }

        public void ReadDataSet() {
            var lines = File.ReadLines(dataSetPath);
            foreach (var line in lines) {
                String[] dataSegments = line.split(",");
                Console.WriteLine(line);
            }
        }
    }
}
