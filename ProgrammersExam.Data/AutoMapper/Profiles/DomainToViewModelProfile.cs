using AutoMapper;
using ProgrammersExam.Entities.Entity;
using ProgrammersExam.Entities.ViewModel;

namespace ProgrammersExam.Data.AutoMapper.Profiles
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            //CreateMap<>()
            CreateMap<PerformanceOrder, PerformanceReceiptViewModel>().ForMember(member => member.TotalPrice, opt => opt.MapFrom(src =>
                $"{src.TotalPrice:C}"));

        }
    }
}
