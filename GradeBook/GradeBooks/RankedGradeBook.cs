using System;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool weighted) : base(name, weighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException();

            int betterStudents = 0;
            
            foreach (var student in Students)
            {
                if (student.AverageGrade > averageGrade)
                    betterStudents++;
            }

            var studentsRank = (100 * betterStudents / Students.Count);

            if(studentsRank < 20)
                return 'A';
            if (studentsRank < 40)
                return 'B';
            if (studentsRank < 60)
                return 'C';
            if (studentsRank < 80)
                return 'D';
            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
    
}