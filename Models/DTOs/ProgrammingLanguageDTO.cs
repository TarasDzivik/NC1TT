using NC1TestTask.Data.Entities;
using NC1TestTask.Data.Entities.JoiningEntities;
using System.ComponentModel.DataAnnotations;

namespace NC1TestTask.Models.DTOs
{
    public class ProgrammingLanguageDTO : CreateProgrammingLanguageDTO
    {
        public int PLId { get; set; }
        public IList<EmployeeProgLanguage> EmployeeProgLanguages { get; set; }
    }

    public class CreateProgrammingLanguageDTO
    {
        [Required]
        [StringLength(maximumLength: 40, ErrorMessage = "Programming Language name is too long!")]
        public string Name { get; set; }
    }

    public class UpdateProgrammingLanguageDTO : CreateProgrammingLanguageDTO
    {
    
    }
}
