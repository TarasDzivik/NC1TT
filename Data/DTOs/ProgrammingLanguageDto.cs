using NC1TestTask.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace NC1TestTask.Data.DTOs
{
    public class ProgrammingLanguageDto : ProgrammingLanguage
    {
        public string Name { get; set; }
    }
}
