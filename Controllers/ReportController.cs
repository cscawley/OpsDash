using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrivyDash.Data;
using TrivyDash.Dtos;
using TrivyDash.Models;

namespace TrivyDash.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : Controller
    {
        private readonly IReportRepo _repository;
        private readonly IMapper _mapper;

        public ReportController(IReportRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ReportReadDto>> GetAllReports()
        {
            Console.WriteLine("Get Reports");
            var reports = _repository.GetReports();
            if (reports != null)
                return Ok(_mapper.Map<IEnumerable<ReportReadDto>>(reports));
            return NotFound();
        }
        [HttpGet("{buildName}", Name = "GetReport")]
        public ActionResult<IEnumerable<ReportReadDto>> GetReport(string buildName)
        {
            Console.WriteLine("Get Players");
            var reports = _repository.GetReport(buildName);
            if (reports != null)
                return Ok(_mapper.Map<IEnumerable<ReportReadDto>>(reports));
            return NotFound();
        }
        [HttpPost]
        public ActionResult<ReportReadDto> CreateReport(ReportCreateDto reportCreateDto)
        {
            var report = _mapper.Map<Report>(reportCreateDto);
            // investigate IMapper.map between the Create DTO and the entity model. 
            System.Console.WriteLine(report.Date);
            report.Date = DateTime.UtcNow;
            System.Console.WriteLine(report.Date);
            _repository.CreateReport(report);
            _repository.SaveChanges();
            return CreatedAtRoute(nameof(GetReport), new { buildName = report.Id }, report);
        }
    }
}
