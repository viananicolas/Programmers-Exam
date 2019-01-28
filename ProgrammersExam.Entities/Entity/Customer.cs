using ProgrammersExam.Entities.Entity.Abstract;

namespace ProgrammersExam.Entities.Entity
{
    public class Customer : Base
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
    }
}
