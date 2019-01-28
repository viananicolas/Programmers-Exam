using System;
using System.ComponentModel.DataAnnotations;
using ProgrammersExam.Entities.Entity.Abstract;

namespace ProgrammersExam.Entities.ViewModel
{
    public class PerformanceOrderViewModel : Base
    {
        [Required]
        public int PlayId { get; set; }
        [Required, Range(1, int.MaxValue)]
        public int Audience { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, RegularExpression("^\\([1-9]{2}\\) (?:[2-8]|9[1-9])[0-9]{3}\\-[0-9]{4}$")]
        public string Telephone { get; set; }

    }
}
