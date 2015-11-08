using AuditReportPoc.Context;
using AuditReportPoc.Enums;
using AuditReportPoc.EventAggregators;

namespace AuditReportPoc
{
  public interface IContextBuilder
  {
    BaseActivityContext BuildContext(UserActivity activity, BaseAggregation aggregation);
  }
}
