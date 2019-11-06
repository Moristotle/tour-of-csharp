using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class InMemoryBook : Book
    {
        public override string CATEGORY { get { return "inMemory"; } }
        private List<double> _grades;
        public InMemoryBook(string name) : base(name)
        {
            _grades = new List<double>();
            Name = name;
        }

        public void AddGrade(char letter)
        //method overloading
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public override void AddGrade(double grade)
        //method overloading
        {
            if (grade <= 100 && grade >= 0)
            {
                _grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            };

        }
        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {

            var result = new Statistics();

            for (var index = 0; index < _grades.Count; index++)
            {
                result.Add(_grades[index]);

            }

            return result;

        }
    }
}