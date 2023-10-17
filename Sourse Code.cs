using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Weekend_Project
{
    internal class DbContext
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=DESKTOP-SCRSLVQ\\SQLEXPRESS;Database=WeekendProject;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))

            // 1. Add a Student in Students Table
            using (SqlCommand command = new SqlCommand("StudentAdd", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StudentID", 11);
                command.Parameters.AddWithValue("@FirstName", "Babar");
                command.Parameters.AddWithValue("@LastName", "Azam");
                command.Parameters.AddWithValue("@Age", 35);
                command.Parameters.AddWithValue("@CourseID", 4);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            // 2. Add a Course in Courses Table
            using (SqlCommand command = new SqlCommand("CourseAdd", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CourseID", 6);
                command.Parameters.AddWithValue("@CourseName", "Programming Fundamentals");
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }


            //3.Updating a Student Age
            using (SqlCommand command = new SqlCommand("UpdateStudentAge", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StudentID", 4);
                command.Parameters.AddWithValue("@NewAge", 63);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            //4.Updating a Course Name
            using (SqlCommand command = new SqlCommand("UpdateCourseName", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CourseID", 4);
                command.Parameters.AddWithValue("@NewCourseName", "Machine learning algorithms");
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }


            // 5. Delete a Student
            using (SqlCommand command = new SqlCommand("DeleteStudent", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StudentID", 4);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }


            // 6. Delete a Course
            using (SqlCommand command = new SqlCommand("DeleteCourse", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CourseID", 3);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }



            //7. Retrieving All Data from students Table
            using (SqlCommand command = new SqlCommand("GetAllStudents", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("StudentID" + " " + "FirstName" + " " + "LastName" + " " + "Age" + " " + "CourseID");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["StudentID"]}        {reader["FirstName"]}   {reader["LastName"]}     {reader["Age"]}        {reader["CourseID"]}");
                }
                connection.Close();
                Console.Read();
            }


            //8. Retrieving All Data from Courses Table
            using (SqlCommand command = new SqlCommand("GetAllCourses", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("CourseID" + "  " + "CourseName");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["CourseID"]}         {reader["CourseName"]}");
                }
                connection.Close();
                Console.Read();
            }


        }
    }
}
