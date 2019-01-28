using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProgrammersExam.Data.Service.Base.Interface;
using ProgrammersExam.Data.UnitOfWork.Interface;
using ProgrammersExam.Entities.Entity;
using ProgrammersExam.Entities.ViewModel;

namespace ProgrammersExam.Controllers
{
    [Produces("application/json"), Route("api/[controller]"), ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPerformanceOrderService _service;

        public HomeController(IUnitOfWork unitOfWork, IPerformanceOrderService service)
        {
            _unitOfWork = unitOfWork;
            _service = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_unitOfWork.GetRepositoryAsync<Play>().GetAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PerformanceOrderViewModel performanceOrderViewModel)
        {
            var receipt = await _service.Add(performanceOrderViewModel);
            return Ok(receipt);
        }
    }
}