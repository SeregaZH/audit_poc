using AuditReportPoc.Context;
using AuditReportPoc.Enums;
using AuditReportPoc.EventAggregators;

namespace AuditReportPoc.Builders.Context
{
  public class BaseContextBuilder : IContextBuilder
  {
    public BaseActivityContext BuildContext(UserActivity activity, BaseAggregation aggregation)
    {
      return new BaseActivityContext(activity, aggregation.CurrentEvent);
    }
  }
}
