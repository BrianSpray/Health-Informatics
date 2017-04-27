using System;

namespace kmeans
{
    public class Point
    {

        public int xCoord { set; get; } = 0;
        public int yCoord { set; get; } = 0;
        public int clusterId { set; get; } = 0;

        public Point(int xCoord, int yCoord)
        {
            this.xCoord = xCoord;
            this.yCoord = yCoord;
        }

        // Returns the Euclidian Distance between two points.
        public static double EuclideanDistance(Point point, Point centroid)
        {
            return Math.Sqrt(Math.Pow((centroid.yCoord - point.yCoord), 2) + Math.Pow((centroid.xCoord - point.xCoord), 2));
        }
    }
}
