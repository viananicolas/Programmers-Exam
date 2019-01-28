using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text;
using ProgrammersExam.Domain.Defaults;
using ProgrammersExam.Domain.Entity.Abstract;
using ProgrammersExam.Domain.Enum;

namespace ProgrammersExam.Domain.Entity
{
    public class Play : Base
    {
        public string PlayName { get; set; }
        public int Audience { get; set; }
        private decimal _price;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price
        {
            get => _price;
            set => _price = Category == Category.Tragedy ? Configuration.TragedyPrice : Configuration.ComedyPrice;
        }

        public Category Category { get; set; }
    }
}
