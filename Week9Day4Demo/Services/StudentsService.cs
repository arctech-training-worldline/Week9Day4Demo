﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

using Week9Day4Demo.Models;

namespace Week9Day4Demo.Services
{
    public class StudentsService
    {
        private const string ConnectionString =
            @"Data Source=.;Initial Catalog=WorldLineDatabase;User ID=worldline;Password=Test@123";

        #region Synchronous Methods

        public List<Student> GetAllStudents()
        {
            var students = new List<Student>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("select * from students", connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var student = new Student
                            {
                                RollNo = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                DateOfBirth = reader.GetDateTime(2),
                                Percentage = reader.GetDouble(3)
                            };

                            students.Add(student);
                        }
                    }
                }
            }

            // If college has < 50% students passing, then don't show any students at all
            // as college is blacklisted.
            var studentSummaryService = new StudentSummaryService();
            var passingCount = studentSummaryService.GetPassingCount(students);

            if(passingCount < students.Count / 2)
                students.Clear();

            return students;
        }

        public void Insert(Student student)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                // Terrible programmer to write query inside of aspx source code
                var query = $"insert into Students values({student.RollNo}, {student.Name}, {student.DateOfBirth}, {student.Percentage})";
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Student student)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("UpdateStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@RollNo", student.RollNo);
                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                    command.Parameters.AddWithValue("@Percentage", student.Percentage);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Student student)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("DeleteStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@RollNo", student.RollNo);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region Asynchronous Methods

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            var students = new List<Student>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("select * from students", connection))
                {
                    await connection.OpenAsync();
                    var reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            var student = new Student
                            {
                                RollNo = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                DateOfBirth = reader.GetDateTime(2),
                                Percentage = reader.GetDouble(3)
                            };

                            students.Add(student);
                        }
                    }
                }
            }

            // If college has < 50% students passing, then don't show any students at all
            // as college is blacklisted.
            var studentSummaryService = new StudentSummaryService();
            var passingCount = studentSummaryService.GetPassingCount(students);

            if (passingCount < students.Count / 2.0)
                students.Clear();

            return students;
        }

        public async Task InsertAsync(Student student)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                // Terrible programmer to write query inside of aspx source code
                //var query = $"insert into Students values({student.RollNo}, '{student.Name}', '{student.DateOfBirth}', {student.Percentage})";

                using (var command = new SqlCommand("InsertStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@RollNo", student.RollNo);
                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                    command.Parameters.AddWithValue("@Percentage", student.Percentage);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Student student)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("UpdateStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@RollNo", student.RollNo);
                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                    command.Parameters.AddWithValue("@Percentage", student.Percentage);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(Student student)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("DeleteStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@RollNo", student.RollNo);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        #endregion
    }
}