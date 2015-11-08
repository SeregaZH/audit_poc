using AuditReportPoc.EventAggregators;
using AuditReportPoc.Events;

namespace AuditReportPoc
{
  public interface IEventAggregator
  {
    void Aggregate(EventBase @event);

    BaseAggregation GetAggregation();
  }
}
