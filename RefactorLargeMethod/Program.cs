using System;

namespace GradeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] assignmentScores = HandleScoreInput("Enter assignment scores (separated by spaces): ");
            double[] quizScores = HandleScoreInput("Enter quiz scores (separated by spaces): ");
            double[] examScores = HandleScoreInput("Enter exam scores (separated by spaces): ");

            double assignmentAverage = CalculateAverage(assignmentScores);
            double quizAverage = CalculateAverage(quizScores);
            double examAverage = CalculateAverage(examScores);

            double finalGrade = CalculateFinalGrade(assignmentAverage, quizAverage, examAverage);

            DisplayFinalGrade(finalGrade);
        }

        static double[] HandleScoreInput(string message)
        {
            Console.WriteLine(message);
            string[] input = Console.ReadLine().Split(' ');
            double[] scores = Array.ConvertAll(input, double.Parse);

            return scores;
        }

        static double CalculateFinalGrade(double assignmentAverage, double quizAverage, double examAverage)
        {
            return (assignmentAverage * 0.4) + (quizAverage * 0.2) + (examAverage * 0.4);
        }

        static double CalculateAverage(double[] scores)
        {
            double sum = 0;
            foreach (var score in scores)
            {
                sum += score;
            }
            return sum / scores.Length;
        }

        static void DisplayFinalGrade(double finalGrade)
        {
            Console.WriteLine($"The final grade is: {finalGrade}");
        }
    }
}
