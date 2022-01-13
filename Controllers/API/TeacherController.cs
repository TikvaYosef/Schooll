using Schooll.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schooll.Controllers.API
{
    public class TeacherController : Controller
    {
        string ConnectionString = "Data Source=desktop-5e70rm2;Initial Catalog=school;Integrated Security=True;Pooling=False";
        List<Teacher> listOfTeachers = new List<Teacher>();


        // GET: Teacher
      
        public static void showAllTeachers(List<Teacher> listOfTeachers, string ConnectionString)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = @"SELECT * FROM Employyes";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader DataFromDb = command.ExecuteReader();

                if (DataFromDb.HasRows)
                {
                    while (DataFromDb.Read())
                    {
                        listOfTeachers.Add(new Teacher(DataFromDb.GetInt32(0),DataFromDb.GetString(1), DataFromDb.GetString(2), DataFromDb.GetInt32(3), DataFromDb.GetDateTime(4)));
                    }
                }

                else
                {
                    Console.WriteLine("no rows in table");
                }
                connection.Close();

            }
        }

        public IHttpActionResult Get()
        {
            
            return Ok();
        }

        // GET: Teacher/Details/5

        public static void showTeacherById(List<Teacher> listOfTeachers, string ConnectionString,int id)
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
        }

        // POST: Teacher/Create
 


        // GET: Teacher/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Teacher/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teacher/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Teacher/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
