using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Administration;

namespace SP.Common
{
    public class LoggingService : SPDiagnosticsServiceBase
    {

        public static string MaventionDiagnosticAreaName = "Mavention";
        private static LoggingService _Current;
        public static LoggingService
            Current
        {
            get
            {
                if (_Current == null)
                {
                    _Current = new LoggingService();
                }
                return _Current;
            }
        }

        private LoggingService()
            : base("Mavention Logging Service", SPFarm.Local)
        {
        }
        protected override IEnumerable<SPDiagnosticsArea> ProvideAreas()
        {
            List<SPDiagnosticsArea> areas = new List<SPDiagnosticsArea> 
            { 
                new SPDiagnosticsArea(MaventionDiagnosticAreaName, new List<SPDiagnosticsCategory> 
                { 
                    new SPDiagnosticsCategory("WebParts", TraceSeverity.Unexpected, EventSeverity.Error) }) 
            };
            return areas;
        }
        public static void LogError(string categoryName, string errorMessage)
        {
            SPDiagnosticsCategory category = LoggingService.Current.Areas[MaventionDiagnosticAreaName].Categories[categoryName];
            LoggingService.Current.WriteTrace(0, category, TraceSeverity.Unexpected, errorMessage);
        }

    }
}
