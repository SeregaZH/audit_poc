using AuditReportPoc.Context;
using AuditReportPoc.Enums;
using AuditReportPoc.EventAggregators;

namespace AuditReportPoc.Builders.Context
{
  public class UpdateContextBuilder : IContextBuilder
  {
    public BaseActivityContext BuildContext(UserActivity activity, BaseAggregation aggregation)
    {
      var aggr = aggregation as UpdateAggregation;
      return new UpdateActivityContext(activity, aggr.CurrentEvent, aggr.PreviousEvent);
    }
  }
}
