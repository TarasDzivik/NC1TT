using NC1TestTask.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace NC1TestTask.Models.DTOs
{
    public class DepartmentDTO : CreateDepartmentDTO
    {
        public int DepartmentId { get; set; }
        public IList<EmployeeDTO> Employees { get; set; }
    }

    public class CreateDepartmentDTO
    {
        [Required]
        [MaxLength(40, ErrorMessage = "Department name should up to 40 characters!")]
        [MinLength(2, ErrorMessage = "Department name is to short!")]
        public string Name { get; set; }
        [Required]
        [Range(minimum: -50, maximum: 400, ErrorMessage = "We do not believe that such a floor exists!")]
        public int Floor { get; set; }
    }

    public class UpdateDepartmentDTO : CreateDepartmentDTO
    {

    }
}
