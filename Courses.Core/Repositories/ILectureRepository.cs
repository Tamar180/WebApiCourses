using Courses.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_api_courses.Entities;

namespace Courses.Core.Repositories
{
    public interface ILectureRepository
    {
        Task<IEnumerable<Lecture>> GetList();
        Task<Lecture> Post(Lecture lecture);
        Task<Lecture> Put(int id, Lecture lecture);
        Task Delete(Lecture lecture);

    }
}
