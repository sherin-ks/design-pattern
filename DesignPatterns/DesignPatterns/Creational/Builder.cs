using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational;

public class Report
{
    public string Title { get; set; }
    public string Header { get; set; }
    public string Body { get; set; }
    public string Footer { get; set; }

    public void Display()
    {
        Console.WriteLine("Report:");
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Header: {Header}");
        Console.WriteLine($"Body: {Body}");
        Console.WriteLine($"Footer: {Footer}");
    }
}

public interface IReportBuilder
{
    void SetTitle(string title);
    void SetHeader(string header);
    void SetBody(string body);
    void SetFooter(string footer);
    Report Build();
}


public class ReportBuilder : IReportBuilder
{
    private Report _report = new Report();

    public void SetTitle(string title) => _report.Title = title;
    public void SetHeader(string header) => _report.Header = header;
    public void SetBody(string body) => _report.Body = body;
    public void SetFooter(string footer) => _report.Footer = footer;

    public Report Build() => _report;
}
public class ReportDirector
{
    public Report BuildFinancialReport(IReportBuilder builder)
    {
        builder.SetTitle("Financial Report 2025");
        builder.SetHeader("Financial Performance Overview");
        builder.SetBody("This section contains financial data, trends, and analyses.");
        builder.SetFooter("Confidential: Prepared by the Finance Department");
        return builder.Build();
    }

    public Report BuildHRReport(IReportBuilder builder)
    {
        builder.SetTitle("HR Report 2025");
        builder.SetHeader("Employee Performance Overview");
        builder.SetBody("This section contains employee statistics, appraisals, and HR updates.");
        builder.SetFooter("Prepared by the Human Resources Department");
        return builder.Build();
    }
}

