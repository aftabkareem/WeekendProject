using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using WebApplication6.StudentModel;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly string _connectionString;

        public StudentController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }



        //Task 7: Implement CRUD Operations


        //Reading Data

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetAllStudents", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Student emp = new Student();
                        emp.StudentID = (int)reader["StudentID"];
                        emp.FirstName = reader["FirstName"].ToString();
                        emp.LastName = reader["LastName"].ToString();
                        emp.Age = (int)reader["Age"];
                        emp.CourseID = (int)reader["CourseID"];

                        students.Add(emp);
                    }
                }
            }
            return Ok(students);
        }



        ////Create
        [HttpPost]
        public IActionResult StudentAdd(Student students)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("StudentAdd", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StudentID", students.StudentID);
                    command.Parameters.AddWithValue("@FirstName", students.FirstName);
                    command.Parameters.AddWithValue("@LastName", students.LastName);
                    command.Parameters.AddWithValue("@Age", students.Age);
                    command.Parameters.AddWithValue("@CourseID", students.CourseID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return Ok();
        }


        ////Update
        [HttpPut("{id}")]
        
        public IActionResult UpdateStudent(int id, Student students)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("UpdateStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StudentID", id);
                    command.Parameters.AddWithValue("@FirstName", students.FirstName);
                    command.Parameters.AddWithValue("@LastName", students.LastName);
                    command.Parameters.AddWithValue("@Age", students.Age);
                    command.Parameters.AddWithValue("@CourseID", students.CourseID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return Ok(students);
        }




        ////Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("DeleteStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StudentID", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return Ok();
        }





        //Task 9: Advanced API Calls



        //1.	Create an API method to list all students older than 20.


        [HttpGet]
        [Route("studentsolderthan20")]
        public IActionResult studentsOlderthan20()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("studentsOlderthan20", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Student emp = new Student();
                        emp.StudentID = (int)reader["StudentID"];
                        emp.FirstName = reader["FirstName"].ToString();
                        emp.LastName = reader["LastName"].ToString();
                        emp.Age = (int)reader["Age"];
                        emp.CourseID = (int)reader["CourseID"];

                        students.Add(emp);
                    }
                }
            }
            return Ok(students);
        }




        //2.	Create an API method to list all students enrolled in a specific course.
        
        [HttpGet]
        [Route("specificCourse")]

        public IActionResult specificCourse(string CourseName)
        {
            List<Student> students = new List<Student>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("specificCourse", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Student emp = new Student();                      
                        emp.FirstName = reader["FirstName"].ToString();
                        emp.LastName = reader["LastName"].ToString();
                        emp.CourseID = (int)reader["CourseID"];

                        students.Add(emp);
                    }
                }
            }
            return Ok(students);
        }




    }
}
