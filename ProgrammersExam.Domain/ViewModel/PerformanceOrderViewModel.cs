using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProgrammersExam.Domain.ViewModel
{
    public class PerformanceOrderViewModel
    {
        [Required]
        public int PlayId { get; set; }
        [Required]
        public int Audience { get; set; }
        [Required]
        public string CustomerName { get; set; }
    }
}
