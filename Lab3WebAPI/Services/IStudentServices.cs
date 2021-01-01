using Lab3WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3WebAPI.Services
{
    public interface IStudentServices
    {
        List<Student> FindAll();
        List<Student> FindAll(string gender);
        Student FindById(string id);
        void Create(Student t);
        void Update(Student t);
        void Delete(string id);
    }
}
