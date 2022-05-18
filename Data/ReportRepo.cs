using TrivyDash.Models;

namespace TrivyDash.Data
{
    public class ReportRepo : IReportRepo
    {
        private readonly AppDbContext _context;

        public ReportRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateReport(Report report)
        {
            _context.Report.Add(report);
        }

        public IEnumerable<Report> GetAllReports()
        {
            return _context.Report.ToList();
        }

        public IEnumerable<Report> GetReport()
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
