using Schooll.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Schooll.Controllers.API
{
    public class TeacherrController : ApiController
    {
        string ConnectionString = "Data Source=desktop-5e70rm2;Initial Catalog=school;Integrated Security=True;Pooling=False";
        List<Teacher> listOfTeachers = new List<Teacher>();


        public  List<Teacher>  showAllTeachers(List<Teacher> listOfTeachers, string ConnectionString)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = @"SELECT * FROM Teachers  ";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader DataFromDb = command.ExecuteReader();

                if (DataFromDb.HasRows)
                {
                    while (DataFromDb.Read())
                    {
                        listOfTeachers.Add(new Teacher(DataFromDb.GetInt32(0), DataFromDb.GetString(1), DataFromDb.GetString(2), DataFromDb.GetInt32(3), DataFromDb.GetDateTime(4)));
                    }
                }

                else
                {
                    Console.WriteLine("no rows in table");
                }             
                connection.Close();

            }
            return listOfTeachers;
        }


        // GET: api/Teacherr
        public IHttpActionResult Get()
        {
            List<Teacher> teacher1 = showAllTeachers(listOfTeachers, ConnectionString);
            return Ok(new { teacher1 });
        }




        // GET: api/Teacherr/5

        public List<Teacher> showTeacherById(List<Teacher> listOfTeachers, string ConnectionString, int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = $@"SELECT * FROM Employyes
                                        where Id  = {id}";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader DataFromDb = command.ExecuteReader();


                if (DataFromDb.HasRows)
                {
                    while (DataFromDb.Read())
                    {
                        listOfTeachers.Add(new Teacher(DataFromDb.GetInt32(0), DataFromDb.GetString(1), DataFromDb.GetString(2), DataFromDb.GetInt32(3), DataFromDb.GetDateTime(4)));
                    }
                }

                else
                {
                    Console.WriteLine("no rows in table");
                }
                connection.Close();

            }
            return listOfTeachers;
        }
        public IHttpActionResult Get(int id)
        {
            List<Teacher> teacher1 = showTeacherById(listOfTeachers, ConnectionString, id);
            return Ok(new { teacher1 }); ;
        }

        // POST: api/Teacherr
        public IHttpActionResult Post([FromBody] Teacher obj)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                connection.Open();
                string query = $@"UPDATE Employyes SET name = '{name}',birthday = '{birthday}',email= '{email}',salery= {salery}                   
                                WHERE Id = {ID}";
                SqlCommand command = new SqlCommand(query, connection);
                int rowEffected = command.ExecuteNonQuery();
                Console.WriteLine(rowEffected);
                connection.Close();
            }
            return Ok();
        }

        // PUT: api/Teacherr/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Teacherr/5
        public void Delete(int id)
        {
        }
    }
}
