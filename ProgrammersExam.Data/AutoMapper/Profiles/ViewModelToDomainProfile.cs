using AutoMapper;
using ProgrammersExam.Data.StaticMethods;
using ProgrammersExam.Data.UnitOfWork.Interface;
using ProgrammersExam.Entities.Entity;
using ProgrammersExam.Entities.ViewModel;

namespace ProgrammersExam.Data.AutoMapper.Profiles
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<PerformanceOrderViewModel, Customer>();
            CreateMap<PerformanceOrderViewModel, PerformanceOrder>()
                .ForMember(member => member.Audience, opt => opt.MapFrom(src => src.Audience));
        }
    }
}
