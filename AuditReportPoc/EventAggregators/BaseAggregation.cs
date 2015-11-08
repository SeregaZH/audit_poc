using AuditReportPoc.Events;

namespace AuditReportPoc.EventAggregators
{
  public class BaseAggregation
  {
    public BaseAggregation(EventBase currentEvent)
    {
      CurrentEvent = currentEvent;
    }

    public EventBase CurrentEvent { get; private set; }
  }
}
