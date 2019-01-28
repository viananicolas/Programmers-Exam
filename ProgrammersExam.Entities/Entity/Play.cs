using System.ComponentModel.DataAnnotations.Schema;
using ProgrammersExam.Entities.Defaults;
using ProgrammersExam.Entities.Entity.Abstract;
using ProgrammersExam.Entities.Enum;

namespace ProgrammersExam.Entities.Entity
{
    public class Play : Base
    {
        public string PlayName { get; set; }
        public int Audience { get; set; }
        //private decimal _price;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        //{
        //    get => _price;
        //    set => _price = Category == Category.Tragedy ? Configuration.TragedyPrice : Configuration.ComedyPrice;
        //}

        public Category Category { get; set; }
    }
}
