using System.ComponentModel.DataAnnotations;

namespace ProgrammersExam.Domain.Enum
{
    public enum Category
    {
        [Display(Name = "Comedy")]
        Comedy,
        [Display(Name = "Tragedy")]
        Tragedy
    }
}
