using System.ComponentModel.DataAnnotations;

namespace ProgrammersExam.Entities.Enum
{
    public enum Category
    {
        [Display(Name = "Comedy")]
        Comedy,
        [Display(Name = "Tragedy")]
        Tragedy
    }
}
