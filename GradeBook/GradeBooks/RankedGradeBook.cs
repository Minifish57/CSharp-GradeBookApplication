using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            this.Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(this.Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            //get the number of students composing 20%
            int student20Percent = this.Students.Count * 20 / 100;

            List<double> orderedAverageGrade = new List<double>();
            foreach (Student student in this.Students)
            {
                orderedAverageGrade.Add(student.AverageGrade);
            }
            orderedAverageGrade = orderedAverageGrade.OrderByDescending(a => a).ToList();

            //get where the grade fit in the list
            int index = orderedAverageGrade.FindIndex(g => g <= averageGrade);

            if(index < student20Percent)
            {
                return 'A';
            }else if (index >= student20Percent && index < 2 * student20Percent)
            {
                return 'B';
            }
            else if (index >= 2 * student20Percent && index < 3 * student20Percent)
            {
                return 'C';
            }
            else if (index >= 3 * student20Percent && index < 4 * student20Percent)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
    }
}
