using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgrammersExam.Entities.Entity.Abstract
{
    public abstract class Base
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime RegisterDate { get; set; }
    }
}
