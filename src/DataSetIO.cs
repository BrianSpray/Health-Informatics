
namespace Data {

    using System;
    using System.IO;
    using System.Text;

    public class DataSetIO {

        private static String dataSetPath = @"data/dataset.txt";


        public DataSetIO() {
            CreateDataSetFile();
        }

        private void CreateDataSetFile() {
            String writeHeader = "patientId,age,gender,disease" + Environment.NewLine;

            if (!File.Exists(dataSetPath)) {            
                File.WriteAllText(dataSetPath, writeHeader);
            } else {
                File.WriteAllText(dataSetPath, String.Empty);
                File.WriteAllText(dataSetPath, writeHeader);
            }   
        }

        private void WriteDataSetToFile(String contents) {        
            String appendText = contents + Environment.NewLine;
            File.AppendAllText(dataSetPath, appendText);
        }

        public void CreateDataSet(int DataSetSize) {
            
            String[] gender  = { "Male", "Female"};

            String[] disease = { "Cancer", "Heart Disease", "Diabetes", "Kidney Disease", "NULL"};
            
            Random random = new Random();

            for (int i =0; i < DataSetSize; i++) {
                WriteDataSetToFile((String) (i + "," + random.Next(0, 100) + "," + gender[random.Next(0, gender.Length)] + "," + disease[random.Next(0, disease.Length)]));
            }
        }
    }
}
