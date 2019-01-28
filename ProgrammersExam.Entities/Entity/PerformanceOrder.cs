using System.ComponentModel.DataAnnotations.Schema;
using ProgrammersExam.Entities.Defaults;
using ProgrammersExam.Entities.Entity.Abstract;
using ProgrammersExam.Entities.Enum;

namespace ProgrammersExam.Entities.Entity
{
    public class PerformanceOrder : Base
    {
        public Customer Customer { get; set; }
        public Play Play { get; set; }
        public int Audience { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice
        {
            get =>
                Audience > Play.Audience
                    ? (Audience - Play.Audience) * (Play.Category == Category.Comedy
                          ? Configuration.ComedyAdditionalPrice 
                          : Configuration.TragedyAdditionalPrice) + Play.Price
                    : Play.Price;
            private set => TotalPrice = value;
        }
    }
}