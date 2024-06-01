using Courses.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_api_courses.Entities;

namespace Courses.Data.Repositories
{
    public class PupilRepository : IPupilRepository
    {
        private readonly DataContext _dataContext;
        public PupilRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Pupil> Post(Pupil pupil)
        {
            _dataContext.Pupils.Add(pupil);
            await _dataContext.SaveChangesAsync();
            return pupil;
        }

        public async Task Delete(Pupil pupil)
        {
            _dataContext.Pupils.Remove(pupil);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pupil>> GetList() =>await _dataContext.Pupils.Include(l => l.Courses).ToListAsync();

        public async Task<Pupil> Put(int id, Pupil pupil)
        {
            Pupil? res = _dataContext.Pupils.Find(id);
            if (res == null)
                throw new Exception("404");
            res.Name = pupil.Name;
            res.Address = pupil.Address;
            res.Age = pupil.Age;
            res.Phone = pupil.Phone;
            await _dataContext.SaveChangesAsync();
            return res;
        }
    }
}
