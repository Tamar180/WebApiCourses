namespace web_api_courses.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int MeetingNum { get; set; }
        public int Age { get; set; }
        public int LectureId { get; set; }
        public Lecture Lecture { get; set; }
        public List<Pupil> Pupils { get; set; }
    }
}
