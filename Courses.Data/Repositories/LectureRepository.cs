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
    public class LectureRepository : ILectureRepository
    {
        private readonly DataContext _dataContext;
        public LectureRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Lecture> Post(Lecture lecture)
        {
            _dataContext.Lectures.Add(lecture);
            await _dataContext.SaveChangesAsync();
            return lecture;
        }

        public async Task Delete(Lecture lecture)
        {
            _dataContext.Lectures.Remove(lecture);
            await _dataContext.SaveChangesAsync();
        }
               
        public async Task<IEnumerable<Lecture>> GetList() =>await _dataContext.Lectures.Include(l => l.Courses).ToListAsync();

        public async Task<Lecture> Put(int id, Lecture lecture)
        {
            Lecture? res = _dataContext.Lectures.Find(id);
            if (res == null)
                throw new Exception("404");
            res.Name = lecture.Name;
            res.City = lecture.City;
            res.Phone = lecture.Phone;
            res.Salary = lecture.Salary;
            await _dataContext.SaveChangesAsync();
            return res;
        }
    }
}
