using AutoMapper;
using Courses.Core.DTOs;
using Courses.Core.Servises;
using Courses.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;
using web_api_courses.Entities;
using web_api_courses.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_api_courses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PupilController : ControllerBase
    {
        private readonly IPupilService _pupilService;
        private readonly IMapper _mapper;
        public PupilController(IPupilService pupilService, IMapper mapper)
        {
            _pupilService = pupilService;
            _mapper = mapper;
        }

        // GET: api/<PupilController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var list = await _pupilService.GetAll();
            return Ok(_mapper.Map<IEnumerable<PupilDto>>(list));
        }

        // GET api/<PupilController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var pupil = await _pupilService.GetById(id);
            return Ok(_mapper.Map<PupilDto>(pupil));
        }

        // POST api/<PupilController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PupilPostModel pupil)
        {
            var pupilToAdd = await _pupilService.Post(_mapper.Map<Pupil>(pupil));
            return Ok(_mapper.Map<PupilDto>(pupilToAdd));
        }

        // PUT api/<PupilController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PupilPostModel pupil)
        {
            var p = _mapper.Map<Pupil>(pupil);
            var pRes = await _pupilService.Put(id, p);
            return Ok(_mapper.Map<PupilDto>(pRes));
        }
        // PUT api/<PupilController>/5/age
        [HttpPut("{id}/age")]
        public async Task Put(int id)
        {
            await _pupilService.AddYear(id);
        }
        // DELETE api/<PupilController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _pupilService.Delete(id);
        }
    }
}
