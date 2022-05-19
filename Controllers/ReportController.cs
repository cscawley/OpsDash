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
        [HttpGet("{buildName}", Name = "GetReports")]
        public ActionResult<IEnumerable<ReportReadDto>> GetReports(string buildName)
        {
            Console.WriteLine("Get Players");
            var reports = _repository.GetAllReports(buildName);
            if (reports != null)
                return Ok(_mapper.Map<IEnumerable<ReportReadDto>>(reports));
            return NotFound();
        }
        [HttpPost]
        public ActionResult<ReportReadDto> CreatePlayer(ReportCreateDto reportCreateDto)
        {
            var report = _mapper.Map<Report>(reportCreateDto);
            _repository.CreateReport(report);
            _repository.SaveChanges();
            return CreatedAtRoute(nameof(GetReports), new { buildName = report.ArtifactName }, report);
        }
    }
}
