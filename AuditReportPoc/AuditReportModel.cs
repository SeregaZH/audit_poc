using System.Collections.Generic;
using AuditReportPoc.Enums;

namespace AuditReportPoc
{
  public class AuditReportModel
  {
    public AuditReportModel()
    {
      Before = new Dictionary<string, string>();
      After = new Dictionary<string, string>();
    }

    public UserActivity Activity { get; set; }
    public UserActivityType Type { get; set; }
    public IDictionary<string, string> Before { get; private set; }
    public IDictionary<string, string> After { get; private set; }
  }
}
