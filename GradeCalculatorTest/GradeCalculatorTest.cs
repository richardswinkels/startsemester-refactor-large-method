using GradeCalculator;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace GradeCalculatorTest;

[TestClass]
public class GradeCalculatorTest
{
   [TestMethod]
    public void CalculateFinalGrade_WithValidAverages_And_ValidWeights_ReturnsCorrectFinalGrade()
    {
        double assignmentAverage = 8.0;
        double quizAverage = 6.0;
        double examAverage = 4.0;
        double assignmentWeight = 0.5;
        double quizWeight = 0.2;
        double examWeight = 0.3;

        double result = Program.CalculateFinalGrade(assignmentAverage, quizAverage, examAverage, assignmentWeight, quizWeight, examWeight);

        Assert.AreEqual(6.4, result, "Final grade is incorrent.");
    }

    [TestMethod]
    public void CalculateAverage_WithValidScores_ReturnsCorrectAverage()
    {
        double[] scores = {5, 10, 6};

        double result = Program.CalculateAverage(scores);

        Assert.AreEqual(7, result, "Average calculation is incorrect.");
    }
}
