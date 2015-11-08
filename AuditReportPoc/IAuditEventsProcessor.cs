using System.Collections.Generic;

namespace AuditReportPoc
{
  public interface IAuditEventsProcessor<in T>
  {
    IEnumerable<AuditReportModel> Process(IEnumerable<T> events);
  }
}
