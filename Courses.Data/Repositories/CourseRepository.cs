using Courses.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using web_api_courses.Entities;

namespace Courses.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DataContext _dataContext;

        public CourseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<Course>> GetList() => await _dataContext.Courses.Include(c => c.Lecture).ToListAsync();

        public async Task<Course> Post(Course course)
        {
            _dataContext.Courses.Add(course);
            await _dataContext.SaveChangesAsync();
            return course;
        }

        public async Task Delete(Course course)
        {
            _dataContext.Courses.Remove(course);
            await _dataContext.SaveChangesAsync();
        }


        public async Task<Course> Put(int id, Course course)
        {
            Course? res = _dataContext.Courses.Find(id);
            if (res == null)
                throw new Exception("404");
            res.Name = course.Name;
            res.Address = course.Address;
            res.MeetingNum = course.MeetingNum;
            res.Age = course.Age;
            await _dataContext.SaveChangesAsync();
            return res;
        }

    }
}
