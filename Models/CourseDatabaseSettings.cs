namespace HeresTheGreenAPI.Models
{
    public class CoursesDatabaseSettings : ICoursesDatabaseSettings
    {
        public string CoursesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ICoursesDatabaseSettings
    {
        string CoursesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}