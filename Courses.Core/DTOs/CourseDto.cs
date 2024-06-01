using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_api_courses.Entities;

namespace Courses.Core.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int MeetingNum { get; set; }
        public int Age { get; set; }
        public int LectureId { get; set; }
        public LectureDto Lecture { get; set; }
    }
}
