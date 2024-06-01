using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_api_courses.Entities;

namespace Courses.Core.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetList();
        Task<Course> Post(Course course);
        Task<Course> Put(int id, Course course);
        Task Delete(Course course);
    }
}
