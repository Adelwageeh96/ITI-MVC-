namespace MVC_Lab.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<EmployeeProject> EmployeeProjects { get; set; }


        

    }
}
