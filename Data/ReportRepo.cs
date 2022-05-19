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
            if (report == null)
                throw new ArgumentNullException(nameof(report));
            _context.Report.Add(report);
        }

        public IEnumerable<Report> GetReports()
        {
            return _context.Report.ToList();
        }

        public IEnumerable<Report> GetReport(string buildName)
        {
            return _context.Report.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
