using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDBAccess
{
    internal class Repository
    {
        //We need a connection string
        //The data source is the server name
        //The initial catalog is the database name
        const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SchoolDB";
        //SQL Connection Object
        SqlConnection connection;
        //SQL Command
        SqlCommand command;
        //We need a reader
        SqlDataReader reader;
        //now lets initialize the connection
        

        public Repository() 
        {
            connection = new SqlConnection(CONNECTION_STRING);
        }
        public List<Course> GetAllCourses()
        {
            //lets create a sql statement as a string
            string sql = "SELECT * FROM COURSE";
            List<Course> courses = new List<Course>();
            try
            {
                //Open the connection
                connection.Open();
                //we initialize the command
                command = new SqlCommand(sql, connection);
                //reader is what actually gets a response
                reader = command.ExecuteReader();
                //This reader object has a method which returns a bool IF there is more data to be read
                //we create a loop based on that bool
                while (reader.Read())
                {
                    courses.Add(new Course
                    {
                        CourseId = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Credits = reader.GetInt32(2),
                        DepartmentId = reader.GetInt32(3)
                    });
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return courses;

        }
    }
}
