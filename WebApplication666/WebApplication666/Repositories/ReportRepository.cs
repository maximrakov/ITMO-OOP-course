using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication666.Models;

namespace WebApplication666.Repositories
{
    public class ReportRepository
    {
        List<Report> reports = new List<Report>();
        public ReportRepository()
        {
            try
            {
                reports = Deserial();
            }
            catch
            {
                reports = new List<Report>();
            }
        }
        public void AddReport(Report report)
        {
            reports.Add(report);
            Serial(reports);
        }
        public Report FindById(int id)
        {
            foreach(Report report in reports)
            {
                if(report.Id == id)
                {
                    return report;
                }
            }
            return null;
        }
        private static void Serial(List<Report> stuffReports)
        {
            string json = JsonSerializer.Serialize(stuffReports);
            File.WriteAllText(@"D:\reportsStuff\Report.txt", json);
        }

        private static List<Report> Deserial()
        {
            string text = File.ReadAllText(@"D:\reportsStuff\Report.txt", Encoding.UTF8);
            return JsonSerializer.Deserialize<List<Report>>(text);
        }
    }
}
