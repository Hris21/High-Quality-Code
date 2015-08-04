using System;

public class SimpleMathExam : Exam
{
    private const int MinGrade = 2;

    private const int MaxGrade = 6;

    private int problemsSolved;

    private int maximumProblemsToSolve = 2;

    private int minimumProblemstoSolve = 0;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get
        {
            return this.problemsSolved;
        }

        private set
        {
            if (value > maximumProblemsToSolve || value < minimumProblemstoSolve)
            {
                throw new ArgumentOutOfRangeException(string.Format("The number of problems to be solved must be between {0} and {1} .", this.minimumProblemstoSolve, this.maximumProblemsToSolve));
            }
            this.problemsSolved = value;
        }

    }
    public override ExamResult Check()
    {
        string examOverview = string.Empty;
        int actualGrade = 0;

        if (this.ProblemsSolved == this.minimumProblemstoSolve)
        {
            actualGrade = MinGrade;
            examOverview = "Failed the exam";
        }
        else if (this.ProblemsSolved == 1)
        {
            actualGrade = 4;
            examOverview = "Passed with average result.";
        }
        else if (this.ProblemsSolved == this.maximumProblemsToSolve)
        {
            actualGrade = MaxGrade;
            examOverview = "Excellent result: all done.";
        }

        var result = new ExamResult(actualGrade, MinGrade, MaxGrade, examOverview);
        return result;
    }
}
