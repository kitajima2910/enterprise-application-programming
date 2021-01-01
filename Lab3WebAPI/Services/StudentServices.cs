using Lab3WebAPI.Models;
using Lab3WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3WebAPI.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly StudentContext context;

        public StudentServices(StudentContext context)
        {
            this.context = context;
        }

        public void Create(Student t)
        {
            context.Students.Add(t);
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            var model = context.Students.Find(id);
            context.Students.Remove(model);
        }

        public List<Student> FindAll() => context.Students.ToList();

        public List<Student> FindAll(string gender) => context.Students.Where(m => m.Gender.Equals(gender)).ToList();

        public Student FindById(string id) => context.Students.SingleOrDefault(m => m.StudentId.Equals(id));
        public void Update(Student t)
        {
            context.Update(t);
            context.SaveChanges();
        }
    }
}
