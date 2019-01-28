using System;
using System.ComponentModel.DataAnnotations.Schema;
using ProgrammersExam.Domain.Defaults;
using ProgrammersExam.Domain.Entity.Abstract;
using ProgrammersExam.Domain.Enum;

namespace ProgrammersExam.Domain.Entity
{
    public class PerformanceOrder : Base
    {
        public Customer Customer { get; set; }
        public Play Play { get; set; }
        public int Audience { get; set; }
        private decimal _totalPrice;
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice
        {
            get => _totalPrice;
            private set =>
                _totalPrice = Audience > Play.Audience
                    ? (Audience - Play.Audience) * (Play.Category == Category.Comedy
                          ? Configuration.ComedyAdditionalPrice
                          : Configuration.TragedyAdditionalPrice)
                    : Play.Price;
        }
    }
}