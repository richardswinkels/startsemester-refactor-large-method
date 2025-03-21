﻿using System;

namespace GradeCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            double[] assignmentScores = HandleScoreInput("Enter assignment scores (separated by spaces): ");
            double[] quizScores = HandleScoreInput("Enter quiz scores (separated by spaces): ");
            double[] examScores = HandleScoreInput("Enter exam scores (separated by spaces): ");

            double assignmentAverage = CalculateAverage(assignmentScores);
            double quizAverage = CalculateAverage(quizScores);
            double examAverage = CalculateAverage(examScores);
            
            double assignmentWeight = HandleWeightInput("Enter an assignment weight (decimal between 0 and 1): ");
            double quizWeight = HandleWeightInput("Enter a quiz weight (decimal between 0 and 1): ");
            double examWeight = HandleWeightInput("Enter an exam weight (decimal between 0 and 1):  ");

            double finalGrade = CalculateFinalGrade(assignmentAverage, quizAverage, examAverage, assignmentWeight, quizWeight, examWeight);

            DisplayFinalGrade(finalGrade);
        }

        public static double[] HandleScoreInput(string message)
        {
            double[]? scores = null;

            while (scores == null)
            {
                Console.WriteLine(message);
                string[] input = Console.ReadLine().TrimEnd().Split(' ');

                try
                {
                    scores = Array.ConvertAll(input, double.Parse);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter valid numeric scores separated by spaces.");
                }
            }

            return scores;
        }

        public static double HandleWeightInput(string message)
        {
            double number = 0;
            bool isValid = false;

            Console.WriteLine(message);

            while (!isValid)
            {
                string? input = Console.ReadLine();

                if (!Double.TryParse(input, out number))
                {
                    Console.WriteLine("ERROR: Ongeldige invoer! Voer een geldig getal in.");
                    continue;
                }

                if (number < 0 || number > 1)
                {
                    Console.WriteLine("ERROR: Voer een getal in dat kleiner dan of gelijk aan 0 is, of groter dan of gelijk aan 1.");
                    continue;
                }

                isValid = true;
            }

            return number;
        }

        public static double CalculateFinalGrade(double assignmentAverage, double quizAverage, double examAverage, double assignmentWeight, double quizWeight, double examWeight)
        {
            return (assignmentAverage * assignmentWeight) + (quizAverage * quizWeight) + (examAverage * examWeight);
        }

        public static double CalculateAverage(double[] scores)
        {
            double sum = 0;
            foreach (var score in scores)
            {
                sum += score;
            }
            return sum / scores.Length;
        }

        public static void DisplayFinalGrade(double finalGrade)
        {
            Console.WriteLine($"The final grade is: {finalGrade}");
        }
    }
}
