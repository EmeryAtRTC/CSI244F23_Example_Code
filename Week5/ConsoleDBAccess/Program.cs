// See https://aka.ms/new-console-template for more information
using ConsoleDBAccess;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");


//now we try to run
Repository repo = new Repository();
List<Course> courses = repo.GetAllCourses();
foreach (Course course in courses)
{
    Console.WriteLine($"{course.CourseId} {course.Title} {course.DepartmentId} {course.Credits}");
}
Console.ReadLine();