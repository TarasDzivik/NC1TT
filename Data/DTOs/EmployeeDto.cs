using NC1TestTask.Data.Entities;

namespace NC1TestTask.Data.DTOs
{
    public class EmployeeDto : Employee
    {
        public string Name { get; set; }

        public string Surname { get; set; }
        public int Age { get; set; }

        public Department? Department { get; set; }

        public ProgrammingLanguage? ProgrammingLanguage { get; set; }
    }
}
