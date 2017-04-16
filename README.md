# Health-Informatics
Health Informatics Programming Assignment

Problem # 1. Write a K-means high level algorithm and program for clustering the N-dimensional data
point in your own language. The algorithm should be able to read the data from a data file that has data
in the following form. Note: you can use software library for sorting if needed.
Dimensions = <integer>
<Patient-id> <age><gender><disease>
Generate a data file . The <disease> will be a word for example ‘diabetes’, ‘kidney problem’, ‘acidity’ etc.
If the <disease> column is missing, it would mean no disease is associated with that value.
The distance measure will be Euclidean that means it is square root of squares of difference of coordinate
and centeroids. Your program should display the coordinates of the centroid on the screen, the threshold
value you gave, and the maximum distance from the centroid to the farthest point in a cluster for all the
clusters. It should also give the coordinates of the 'Outliers' in a separate output file. Outliers are those
points that do not belong to any cluster. Note that there may be more than one clusters for the same
disease. 
Problem #2. Write a program for finding out the most probable path given a transition matrix, observation
matrix, and initialization matrix in a data file. The emitted string should be given by the user, and the
program should return all the probable sequence of states that would emit the given signals along with
their probabilities, and then print out the maximum probable path. 
