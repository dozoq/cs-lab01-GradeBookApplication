using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException();
            double highestScore = (from student in Students select student.AverageGrade).Max();
            char grade = 'F';
            if(averageGrade > highestScore/5*4)
            {
                grade = 'A';
            }
            else if(averageGrade > highestScore/5*3)
            {
                grade =  'B';
            }
            else if(averageGrade > highestScore/5*2)
            {
                grade = 'C';
            }
            else if(averageGrade > highestScore/5)
            {
                grade = 'D';
            }

            return grade;
        }
    }
}