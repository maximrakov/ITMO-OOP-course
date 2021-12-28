using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication666.Models;
using WebApplication666.Repositories;

namespace WebApplication666.Services
{
    public class ReportService
    {
        ReportRepository reportRepository = new ReportRepository();
        StuffMemberService stuffMember = new StuffMemberService();
        private static int id = 0;
        public void AddReport(string owner, string mess)
        {
            Report report = new Report(stuffMember.GetById(Int32.Parse(owner)), mess);
            report.Id = id;
            reportRepository.AddReport(report);
            id++;
        }
        public Report FindById(int id)
        {
            return reportRepository.FindById(id);
        }
    }
}
