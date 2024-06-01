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
    public class LectureService : ILectureService
    {
        private readonly ILectureRepository _lectureRepository;
        public LectureService(ILectureRepository lectureRepository)
        {
            _lectureRepository = lectureRepository;
        }

        public async Task Delete(int id)
        {
            var list = await _lectureRepository.GetList();
            Lecture? lecture = list.ToList().Find(l => l.Id == id);
            if (lecture != null)
                await _lectureRepository.Delete(lecture);
        }

        public async Task<IEnumerable<Lecture>> GetAll(string? name, string? city)
        {
            var list = await _lectureRepository.GetList();
            return list.ToList().Where(l => (l.Name == name || name == null) && (l.City == city || city == null));
        }

        public async Task<Lecture> GetById(int id)
        {
            var list = await _lectureRepository.GetList();
            Lecture? lecture = list.ToList().Find(l => l.Id == id);
            if (lecture == null)
                throw new Exception("404");
            return lecture;
        }

        public async Task<Lecture> Post(Lecture lecture)
        {
            return await _lectureRepository.Post(lecture);
        }

        public async Task<Lecture> Put(int id, Lecture lecture)
        {
            return await _lectureRepository.Put(id, lecture);

        }

    }
}
