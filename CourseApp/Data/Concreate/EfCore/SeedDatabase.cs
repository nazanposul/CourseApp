using CourseApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Data.Concreate.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed(DbContext db)
        {
            if (db.Database.GetPendingMigrations().Count() == 0)
            {
                if(db is DataContext)
                {
                    DataContext _db = db as DataContext;
                    if (_db.Instructors.Count() == 0)
                    {
                        _db.Instructors.AddRange(Instructors);
                    }
                    if (_db.Instructors.Count() == 0)
                    {
                        _db.Courses.AddRange(Courses);
                    }
                }
                db.SaveChanges();
            }
        }
        private static Course[] Courses
        {
            get
            {
                Course[] courses = new Course[]
                {
                    new Course(){Name="Html",Price=100,IsActive=true,Instructor=Instructors[0]},
                    new Course(){Name="Core",Price=100,IsActive=true,Instructor=Instructors[1]},
                    new Course(){Name="Mvc",Price=100,IsActive=false,Instructor=Instructors[0]},
                    new Course(){Name="Sql",Price=100,IsActive=false,Instructor=Instructors[1]}
                };
                return courses;
            }
        }
        private static Instructor[] Instructors =
        {
            new Instructor(){Name="Ahmet",Contact=new Contact(){Email="ahmet@gmail.com",Phone="12345",Address=new Address(){City="Çorum",Country="Tacikistan",Text="Atatürk Mahallesi No:45"}}},
            new Instructor(){Name="Mehmet",Contact=new Contact(){Email="mehmet@gmail.com",Phone="54321",Address=new Address(){City="Kastamonu",Country="Bolivya",Text="Çıkrık Mahallesi No:85"}}}
        };
    }
}
