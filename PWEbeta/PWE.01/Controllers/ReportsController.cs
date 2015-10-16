using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PWEapp.Models;

namespace PWEapp.Controllers
{
    public class ReportsController : Controller
    {



        //private PimDbContext pimDb = new PimDbContext();
        // GET: Reports
        public ActionResult Reports()
        {
            // var report_names = pimDb.Reports.ToList();

            var reportList = new List<ReportCheckBox>
            {
                new ReportCheckBox {Id = 1, Name="Product_Attributes.1", CheckBox = false },
                new ReportCheckBox {Id = 2, Name="Product_Attributes.2", CheckBox = false },
                new ReportCheckBox {Id = 3, Name="Product_Info_Groups.3", CheckBox = false },
                new ReportCheckBox {Id = 4, Name="Product_Attributes.4", CheckBox = false },
                new ReportCheckBox {Id = 5, Name="Product_Variant_Attributes.5", CheckBox = false },
                new ReportCheckBox {Id = 6, Name="Product_Variant_Attributes.6", CheckBox = false },
                new ReportCheckBox {Id = 7, Name="Product_Variant_Attributes.7", CheckBox = false },
                new ReportCheckBox {Id = 8, Name="Product_Variant_Attributes.8", CheckBox = false },
                new ReportCheckBox {Id = 9, Name="Product_Attributes.9", CheckBox = false },
                new ReportCheckBox {Id = 10, Name="Product_Attributes.10", CheckBox = false },
                new ReportCheckBox {Id = 11, Name="Product_Attributes.11", CheckBox = false },
                new ReportCheckBox {Id = 12, Name="Product_Attributes.12", CheckBox = false },
                new ReportCheckBox {Id = 13, Name="Product_Variant_Attributes.13", CheckBox = false },
                new ReportCheckBox {Id = 14, Name="Product_Variant_Attributes.14", CheckBox = false }
              };
            return View(reportList);
        }

        public ActionResult LookupTables()
        {
            ViewBag.Message = "Lookup Tables";
            return View();
        }

        public ActionResult SubmitReportList(FormCollection form)
        {
            string reports = form.Get("ReportSubmit");
            return View();


        }

    }
}