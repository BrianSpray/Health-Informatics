using System;
using System.IO;

namespace matrix
{
    class MatrixIO
    {

        private static String matrixPath = @"./data/matrix.txt";

        public static double[] initialMatrixData { get; set; }

        public static void ReadMatrixData()
        {
            var lines = File.ReadLines(matrixPath);

            foreach (var line in lines)
            {

                String[] dataSegments = line.Split(',');

                for (int i = 0; i < dataSegments.Length; i++)
                {

                    Console.WriteLine(dataSegments[i].Trim() + "\n");
                }

            }
        }
    }
}
