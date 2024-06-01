using Courses.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_api_courses.Entities;

namespace Courses.Core.Servises
{
    public interface ILectureService
    {

        Task<IEnumerable<Lecture>> GetAll(string? name, string? city);
        Task<Lecture> GetById(int id);
        Task<Lecture> Post(Lecture lecture);
        Task<Lecture> Put(int id, Lecture lecture);
        Task Delete(int id);

    }
}
