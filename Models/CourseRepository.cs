using System.Collections.Generic;
using MongoDB.Driver;

namespace HeresTheGreenAPI.Models
{
    public class CourseRepository: ICourseRepository
    {
        private readonly IMongoCollection<Course> _courses;
        public CourseRepository(ICoursesDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _courses = database.GetCollection<Course>(settings.CoursesCollectionName);
        }

        public List<Course> GetCourses()
        {
            var courses = _courses.Find(course => true).ToList();
            return courses;
        }

        public Course GetCourse(string id)
        {
            var course = _courses.Find(course => course.Id == id).FirstOrDefault();
            return course;
        }

        public Course Create(Course course)
        {
            _courses.InsertOne(course);
            return course;
        }

        public Course Update(string id, Course courseIn)
        {
            _courses.ReplaceOne(course => course.Id == id, courseIn);
            return courseIn;
        }

        public void Delete(string id)
        {
            _courses.DeleteOne(course => course.Id == id);
        }
    }

    interface ICourseRepository
    {
        List<Course> GetCourses();
        Course GetCourse(string id);
        Course Create(Course course);
        Course Update(string id, Course courseIn);
        void Delete (string id);
    }
}