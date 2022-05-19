using TrivyDash.Models;

namespace TrivyDash.Data
{
    public interface IReportRepo
    {
        void CreateReport(Report report);
        IEnumerable<Report> GetReports();
        IEnumerable<Report> GetReport(string buildName);
        bool SaveChanges();
    }
}
