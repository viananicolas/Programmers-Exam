using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProgrammersExam.Domain.Entity.Abstract
{
    public abstract class Base
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime RegisterDate
        {
            get => DateTime.Now;
            private set => RegisterDate = value;
        }
    }
}
