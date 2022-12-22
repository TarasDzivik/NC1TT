using NC1TestTask.Data.Entities;

namespace NC1TestTask.Data.DTOs
{
    public class DepartmentDto : Department
    {
        public string Name { get; set; }
        public int Floor { get; set; }
    }
}
