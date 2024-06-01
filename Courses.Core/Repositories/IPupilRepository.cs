using Courses.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_api_courses.Entities;

namespace Courses.Core.Repositories
{
    public interface IPupilRepository
    {
        Task<IEnumerable<Pupil>> GetList();
        Task<Pupil> Post(Pupil pupil);
        Task<Pupil> Put(int id, Pupil pupil);
        Task Delete(Pupil pupil);
    }
}
