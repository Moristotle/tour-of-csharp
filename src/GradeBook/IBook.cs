namespace GradeBook 
{
    public interface IBook
    {
        string Name { get; }
     
        event GradeAddedDelegate GradeAdded;
      
        void AddGrade(double grade);
 
        Statistics GetStatistics();

    }
}
