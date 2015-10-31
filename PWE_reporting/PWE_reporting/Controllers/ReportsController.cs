using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PWE_reporting.Models;
using PWE_reporting.ReportWebService;
using System.Web.Services.Protocols;

namespace PWE_reporting.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Reports()
        {
            var reports = new List<Report>();

            int i = 0;
            for (i=0; i<15; i++)
            {
                reports.Add(new Report() { reportName = "Report_" + i, id=i });
            }

            return View(reports);
        }

        public ActionResult LookupTables()
        {
            ViewBag.Message = "Lookup Tables";
            return View();
        }

        public ActionResult DownloadReport(string reportfame)
        {
            //ViewBag.reportName = reportName;


            ReportExecutionService rs = new ReportExecutionService();
            rs.Credentials = new System.Net.NetworkCredential("username", "password");
            //rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
            rs.Url = "http://10.110.190.71/ReportServer/ReportExecution2005.asmx";



           /* ParameterValue[] parameters = new ParameterValue[3];
            parameters[0] = new ParameterValue();
            parameters[0].Name = "EmpID";
            parameters[0].Value = "38";
            parameters[1] = new ParameterValue();
            parameters[1].Name = "ReportMonth";
            parameters[1].Value = "6"; // June
            parameters[2] = new ParameterValue();
            parameters[2].Name = "ReportYear";
            parameters[2].Value = "2004";
            */

           // DataSourceCredentials[] credentials = null;
            string showHideToggle = null;
            string encoding;
            string mimeType;

            ParameterValue[] reportHistoryParameters = null;
            string[] streamIDs = null;

            string reportName = null;
            reportName = "/PWE_Reports/Report_04";
            string historyID = null;
            byte[] result = null;
            string format = "MHTML";
            string extension = null;


            Warning[] warnings = null;
            string devInfo = @"<DeviceInfo><Toolbar><False></Toolbar></DeviceInfo>";
            ExecutionInfo execInfo = new ExecutionInfo();
            ExecutionHeader execHeader = new ExecutionHeader();
            Response.AddHeader("Content-Disposition", "inline; filename=test.pdf");
            rs.ExecutionHeaderValue = execHeader;

          
            execInfo = rs.LoadReport(reportName, historyID);
           // rs.SetExecutionParameters(parameters, "en-us");

            try
            {
                result = rs.Render(format, devInfo, out extension, out mimeType, out encoding, out warnings, out streamIDs);

                execInfo = rs.GetExecutionInfo();
            }
            catch (SoapException e)
            {

            }

            return File(result, "application/mhtml");

            /*if (result != null)
            {
                return File(result, "application/mhtml");
            }
            else
            {
                ViewBag.Message = "Lookup Tables";
                ViewBag.Info = execInfo.ReportPath.ToString();
                return View();
            }
            */


            //return File(myExport.ExportToBytes(), "text/csv", "results.csv");
           // return View();
        }
        public ActionResult ViewReport(string reportName)
        {
            return View();
        }
       
    }
}