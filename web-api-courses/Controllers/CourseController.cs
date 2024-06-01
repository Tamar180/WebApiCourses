using AutoMapper;
using Courses.Core.DTOs;
using Courses.Core.Servises;
using Microsoft.AspNetCore.Mvc;
using web_api_courses.Entities;
using web_api_courses.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_api_courses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;
        public CourseController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        // GET: api/<CourseController>/5/?
        [HttpGet]
        public async Task<ActionResult> Get(string? name, int? age)
        {
            var list =await _courseService.GetAll(name, age);
            return Ok(_mapper.Map < IEnumerable<CourseDto>>(list));
        }
        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var course =await _courseService.GetById(id);
            return Ok(_mapper.Map<CourseDto>(course));
        }

        // POST api/<CourseController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CoursePostModel course)
        {
           var courseToAdd=await _courseService.Post(_mapper.Map<Course>(course));
            return Ok(_mapper.Map<CourseDto>(courseToAdd));
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CoursePostModel course)
        {
            var c = _mapper.Map<Course>(course);
            var cRes=await _courseService.Put(id,c);
            return Ok(_mapper.Map<CourseDto>(cRes));
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
           await _courseService.Delete(id);
        }
    }
}
