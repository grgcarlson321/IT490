using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PWE_reporting.Models;
using PWE_reporting.ReportWebService;
using PWE_reporting.ReportWebReference;
using System.Web.Services.Protocols;

namespace PWE_reporting.Controllers
{
    public class ReportsController : Controller
    {
        

        // GET: Reports
        public ActionResult Reports()
        {
            ReportingService2005 rr = new ReportingService2005();

            
            rr.Credentials = new System.Net.NetworkCredential("ServiceAccount", "password");
            //rr.Credentials = System.Net.CredentialCache.DefaultCredentials;
            rr.Url = "http://10.110.190.71/ReportServer/ReportService2005.asmx";

           

            CatalogItem[] items = null;

            try
            {
                items = rr.ListChildren("/PWE_Reports", true);
            }
            catch (SoapException e)
            {
                throw e;
            }

            var reports = new List<Report>();

            
            foreach (CatalogItem value in items)
            {
                reports.Add(new Report() { ReportName = value.Name});
            }



            return View(reports);
        }

        public ActionResult LookupTables()
        {
            ViewBag.Message = "Lookup Tables";
            return View();
        }

        public ActionResult DownloadReport(string reportName)
        {
            
            //ViewBag.reportName = reportName;
            ReportExecutionService rs = new ReportExecutionService();
            rs.Credentials = new System.Net.NetworkCredential("ServiceAccount", "password");
            //rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
            rs.Url = "http://10.110.190.71/ReportServer/ReportExecution2005.asmx";
            
            string encoding = null;
            string mimeType = null;
            string[] streamIDs = null;

            string reportPath = null;
            reportPath = "/PWE_Reports/"+reportName;
            string historyID = null;
            byte[] result = null;
            string format = "CSV";
            string extension = null;


            ReportWebService.Warning[] warnings = null;
            ExecutionInfo execInfo = new ExecutionInfo();
            ExecutionHeader execHeader = new ExecutionHeader();
            Response.AddHeader("Content-Disposition", "inline; filename="+ reportName + ".csv");
            rs.ExecutionHeaderValue = execHeader;

            
            execInfo = rs.LoadReport(reportPath, historyID);
           // rs.SetExecutionParameters(parameters, "en-us");

           try
           {
                result = rs.Render(format, null, out extension, out mimeType, out encoding, out warnings, out streamIDs);
               
                execInfo = rs.GetExecutionInfo();
           }
            catch (SoapException e)
            {
                throw e;
            }

            return File(result, "text/csv", "myreport.csv");

        }
        public ActionResult ViewReport(string ReportName)
        {
            //return File(result, mimeType);
            ViewBag.ReportName = ReportName;
            return View();
        }

      


       
    }
}