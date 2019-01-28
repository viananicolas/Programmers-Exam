using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ProgrammersExam.Domain.Entity;
using ProgrammersExam.Domain.ViewModel;

namespace ProgrammersExam.Domain.AutoMapper.Profiles
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<PerformanceOrderViewModel, Customer>().ForMember(member=>member.Name, opt => opt.MapFrom(src => src.CustomerName));
            CreateMap<PerformanceOrderViewModel, PerformanceOrder>()
                .ForMember(member => member.Play, opt => opt.MapFrom(src => src.CustomerName));
        }
    }
}
