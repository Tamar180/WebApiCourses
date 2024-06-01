using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_api_courses.Entities;

namespace Courses.Core.Servises
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAll(string? name, int? age);
        Task<Course> GetById(int id);
        Task<Course> Post(Course course);
        Task<Course> Put(int id, Course course);
        Task Delete(int id);

    }
}
