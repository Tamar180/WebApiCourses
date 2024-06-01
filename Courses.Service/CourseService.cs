using Courses.Core.Repositories;
using Courses.Core.Servises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_api_courses.Entities;

namespace Courses.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task Delete(int id)
        {
            var list = await _courseRepository.GetList();
            Course? res = list.ToList().Find(x => x.Id == id);
            if (res != null)
                await _courseRepository.Delete(res);
        }

        public async Task<IEnumerable<Course>> GetAll(string? name, int? age)
        {
            var list = await _courseRepository.GetList();
            return list.Where(c => (name == null || c.Name == name) && (age == null || c.Age >= age));
        }
        public async Task<Course> GetById(int id)
        {
            var list = await _courseRepository.GetList();
            Course? course = list.ToList().Find(c => c.Id == id);
            if (course == null)
                throw new Exception("404");
            return course;
        }
        public async Task<Course> Post(Course course)
        {
            return await _courseRepository.Post(course);
        }
        public async Task<Course> Put(int id, Course course)
        {
            return await _courseRepository.Put(id, course);

        }

    }
}
