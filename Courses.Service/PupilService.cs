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
    public class PupilService : IPupilService
    {
        private readonly IPupilRepository _pupilRepository;
        public PupilService(IPupilRepository pupilRepository)
        {
            _pupilRepository = pupilRepository;
        }

        public async Task AddYear(int id)
        {
            var list = await _pupilRepository.GetList();
            Pupil? res = list.ToList().Find(p => p.Id == id);
            if (res == null)
                throw new Exception("404");
            res.Age++;
            await _pupilRepository.Put(res.Id, res);

        }

        public async Task Delete(int id)
        {
            var list = await _pupilRepository.GetList();
            Pupil? pupil = list.ToList().Find(c => c.Id == id);
            if (pupil != null)
                await _pupilRepository.Delete(pupil);
        }

        public async Task<IEnumerable<Pupil>> GetAll()
        {
            return await _pupilRepository.GetList();
        }

        public async Task<Pupil> GetById(int id)
        {
            var list = await _pupilRepository.GetList();
            Pupil? pupil = list.ToList().Find(p => p.Id == id);
            if (pupil == null)
                throw new Exception("404");
            return pupil;
        }

        public async Task<Pupil> Post(Pupil pupil)
        {
            return await _pupilRepository.Post(pupil);
        }

        public async Task<Pupil> Put(int id, Pupil pupil)
        {
            return await _pupilRepository.Put(id, pupil);
        }

    }
}
