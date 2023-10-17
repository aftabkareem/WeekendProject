using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.CourseModel;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly string _connectionString;

        public CourseController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }



        //Task 7: Implement CRUD Operations


        //Reading Data
        [HttpGet]
        public IActionResult GetAllCourses()
        {
            List<Course> courses = new List<Course>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetAllCourses", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Course emp = new Course();
                        emp.CourseID = (int)reader["CourseID"];
                        emp.CourseName = reader["CourseName"].ToString();

                        courses.Add(emp);
                    }
                }
            }
            return Ok(courses);
        }


        ////Create
        [HttpPost]
        public IActionResult CourseAdd(Course courses)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("CourseAdd", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CourseID", courses.CourseID);
                    command.Parameters.AddWithValue("@CourseName", courses.CourseName);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return Ok();
        }


        ////Update
        [HttpPut]
        [Route("UpdateCourse")]
        public IActionResult UpdateCourseName(int id, Course courses)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("UpdateCourse", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CourseID", courses.CourseID);
                    command.Parameters.AddWithValue("@CourseName", courses.CourseName);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return Ok(courses);
        }




        ////Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("DeleteCourse", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CourseID", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return Ok();
        }

        //Task 9: Advanced API Calls







        //3.	Create an API method to find the most popular course.

        [HttpGet]
        [Route("mostPopularCourse")]
        public IActionResult mostPopularCourse()
        {
            List<Course> courses = new List<Course>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("mostPopularCourse", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Course emp = new Course();

                        emp.CourseID = (int)reader["CourseID"];
                        emp.CourseName = reader["CourseName"].ToString();

                        courses.Add(emp);
                    }
                }
            }
            return Ok(courses);
        }
    }
}

   
