using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace matrix
{
    class Matrix
    {
        
        public  static String emission { get; set; } = "";

        private static int count = 0;

        private static double probability;

        private static double[] initialMatrixData = new double[] { 0.9, 0.06, 0.04 };

        private static double[,] tranisitonMatrixData = new double[3, 3] {
            
            { 0.5, 0.4, 0.1 },
            { 0.3, 0.1, 0.6 },
            { 0.0, 0.1, 0.9 }
        
        };


        public static int[] RequestedEmisition(String path)
        {
            emission = path;

            String[] pathParts = emission.Split(',');

            int[] pathValues = new int[pathParts.Length];

            for (int i = 0; i < pathParts.Length; i++)
            {
                pathValues[i] = Convert.ToInt32(pathParts[i]);
            }
            return pathValues;
        } 
        
        private static double InitialProbability(int[] path)
        {
            return probability = initialMatrixData[path[0]];
        } 
        
        private static double MoreProbability(int[] path)
        {

            int previousCount;

            if (count == 0)
            {
                previousCount = 0;
            } else
            {
                previousCount = count - 1;
            }
            

            if (count == 0) {
                probability = initialMatrixData[path[0]];
                count++;
                return MoreProbability(path);
            } else if (count == path.Length) {
                return probability;
            } else {
                probability *= tranisitonMatrixData[path[previousCount], path[count]];
                count++;
                return MoreProbability(path);
            }           
        }

        public static void DisplayProbability(int[] emission)
        {
           Console.WriteLine(MoreProbability(emission));
        }            
    }
}
