using System;
using System.Threading.Tasks;
using AutoMapper;
using ProgrammersExam.Data.Service.Base;
using ProgrammersExam.Data.Service.Base.Interface;
using ProgrammersExam.Data.UnitOfWork.Interface;
using ProgrammersExam.Entities.Entity;
using ProgrammersExam.Entities.ViewModel;

namespace ProgrammersExam.Data.Service
{
    public class PerformanceOrderService : IPerformanceOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseService<PerformanceOrder> _service;
        private readonly IMapper _mapper;
        public PerformanceOrderService(IUnitOfWork unitOfWork, IMapper mapper, IBaseService<PerformanceOrder> service)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _service = service;
        }

        public async Task<PerformanceReceiptViewModel> Add(PerformanceOrderViewModel entity)
        {
            try
            {
                var performanceOrder = _mapper.Map<PerformanceOrder>(entity);
                var customer = _mapper.Map<Customer>(entity);
                performanceOrder.Customer = customer;
                performanceOrder.Play = _unitOfWork.GetRepository<Play>()
                    .Single(e => e.Id == entity.PlayId);
                var receipt = _mapper.Map<PerformanceReceiptViewModel>(await _service.Add(performanceOrder));
                return receipt;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
            _service?.Dispose();
        }
    }
}
