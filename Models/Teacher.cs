using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schooll.Models
{
    public class Teacher
    {
        public int Id;
        public string Fanme;
        public string Lname;
        public int sallery;
        public DateTime birthDay;

        public Teacher(int id, string fanme, string lname, int sallery, DateTime birthDay)
        {
           this.Id = id;
           this.Fanme = fanme;
           this.Lname = lname;
           this.sallery = sallery;
           this.birthDay = birthDay;
        }
    }
}