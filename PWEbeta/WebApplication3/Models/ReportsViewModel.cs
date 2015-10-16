using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PWEapp.Models
{
    public class ReportsViewModel
    {
        public IList<ReportCheckBox> SelectedReports { get; set; }
    }
    public class PostedReports
    {
        public string[] ReportIds { get; set; }
    }
}