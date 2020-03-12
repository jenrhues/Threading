Name: Jennifer Huestis
Date: 03/12/2020
Files: Program.cs
Description: This program contains one file, Program.cs, that has two classes that work together to estimate pi. The two classes are
  Program and FindPiThread. Program contains Main() to prompt user for a dart amount to throw, a thread count to complete, and to
  calculate pi with help from FindPiThread. In FindPiThread, throwDarts() uses two randomized doubles to represent a point on the dart
  board between or at 0 and 1. Using the pythagorean theorem to calculate the hypotenuse of these two doubles, the dart will have landed
  inside a circle inscribed within a square if the hypotenuse is less than or equal to 1. A counter is updated to represent the number
  of darts within the circle. After this, the calculation of pi can be done in Main() in Program by this equation: 
    pi = 4 * ((number of darts in circle) / (total darts * total threads))
  If enough darts to threads are large enough, the estimation for pi should become more accurate.
