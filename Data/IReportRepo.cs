using TrivyDash.Models;

namespace TrivyDash.Data
{
    public interface IReportRepo
    {
        bool SaveChanges();
        IEnumerable<Report> GetAllReports(string buildName);
        IEnumerable<Report> GetReport();
        void CreateReport(Report report);
    }
}
