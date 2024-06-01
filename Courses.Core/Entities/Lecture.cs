namespace web_api_courses.Entities
{
    public class Lecture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public double Salary { get; set; }
        public List<Course> Courses { get; set; }
    }
}
