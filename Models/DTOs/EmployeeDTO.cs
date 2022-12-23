using NC1TestTask.Data.Entities;
using NC1TestTask.Data.Entities.JoiningEntities;
using NC1TestTask.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace NC1TestTask.Models.DTOs
{
    public class EmployeeDTO : CreateEmployeeDTO
    {
        public int EmployeeId { get; set; }
        public DepartmentDTO Department { get; set; }
        public IList<EmployeeProgLanguage> EmloyeeProgLanguages { get; set; }
    }
    public class CreateEmployeeDTO
    {
        [Required]
        [MinLength(2, ErrorMessage = "Your name is too short!")]
        [StringLength(maximumLength: 20, ErrorMessage = "Your name is too long!")]
        public string Name { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Your surname is too short!")]
        [StringLength(maximumLength: 20, ErrorMessage = "Your surname is too long!")]
        public string Surname { get; set; }
        [Required]
        [Range(minimum: 18, maximum: 99, ErrorMessage = "Employee age should be between 18 and 99 years!")]
        public int Age { get; set; }
        [Required]
        public GenderType Gender { get; set; }
    }
}
