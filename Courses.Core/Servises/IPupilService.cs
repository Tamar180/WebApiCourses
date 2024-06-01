using Courses.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_api_courses.Entities;

namespace Courses.Core.Servises
{
    public interface IPupilService
    {
        Task<IEnumerable<Pupil>> GetAll();
        Task<Pupil> GetById(int id);
        Task<Pupil> Post(Pupil pupil);
        Task<Pupil> Put(int id, Pupil pupil);
        Task AddYear(int id);
        Task Delete(int id);
    }
}
