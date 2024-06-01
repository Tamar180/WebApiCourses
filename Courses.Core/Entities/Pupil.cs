namespace web_api_courses.Entities
{
    public class Pupil
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public List<Course> Courses { get; set; }
    }
}
