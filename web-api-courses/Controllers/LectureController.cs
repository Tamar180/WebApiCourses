using AutoMapper;
using Courses.Core.DTOs;
using Courses.Core.Servises;
using Courses.Service;
using Microsoft.AspNetCore.Mvc;
using web_api_courses.Entities;
using web_api_courses.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_api_courses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectureController : ControllerBase
    {
        private readonly ILectureService _lectureService;
        private readonly IMapper _mapper;
        public LectureController(ILectureService lectureService, IMapper mapper)
        {
            _lectureService = lectureService;
            _mapper = mapper;
        }

        // GET: api/<LectureController>
        [HttpGet]
        public async Task<ActionResult> Get(string? name, string? city)
        {
            var list =await _lectureService.GetAll(name, city);
            return Ok(_mapper.Map<IEnumerable<LectureDto>>(list));

        }
        // GET api/<LectureController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var lecture =await _lectureService.GetById(id);
            return Ok(_mapper.Map<LectureDto>(lecture));

        }

        // POST api/<LectureController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] LecturePostModel lecture)
        {
            var lectureToAdd =await _lectureService.Post(_mapper.Map<Lecture>(lecture));
            return Ok(_mapper.Map<LectureDto>(lectureToAdd));
        }

        // PUT api/<LectureController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] LecturePostModel lecture)
        {
            var l = _mapper.Map<Lecture>(lecture);
            var lRes =await _lectureService.Put(id, l);
            return Ok(_mapper.Map<LectureDto>(lRes));
        }

        // DELETE api/<LectureController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
           await _lectureService.Delete(id);
        }
    }
}
