using System;
using System.Threading.Tasks;
using ProgrammersExam.Entities.ViewModel;

namespace ProgrammersExam.Data.Service.Base.Interface
{
    public interface IPerformanceOrderService : IDisposable
    {
        Task<PerformanceReceiptViewModel> Add(PerformanceOrderViewModel performanceOrderViewModel);
    }
}