using System;

namespace GradeBook
{
    class Program
    {

        static void Main(string[] args)
        {

            //var book = new InMemoryBook("Mori's grade book I");
            var book = new DiskBook("Mori's grade book II");

            book.GradeAdded += OnGradeAdded;
            book.GradeAdded -= OnGradeAdded;
            
            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine(book.CATEGORY);
            Console.WriteLine($"For the book named :: {book.Name}");
            Console.WriteLine($"The lowest grade is :: {stats.Low}");
            Console.WriteLine($"The highest grade is :: {stats.High}");
            Console.WriteLine($"The average grade is :: {stats.Average:N1}"); //:Nx is a way to format floating point numbers
            Console.WriteLine($"The letter grade is :: {stats.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Finished!");
                }

            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}
