using AuditReportPoc.Events;

namespace AuditReportPoc.EventAggregators
{
  public class UpdateAggregation : BaseAggregation
  {
    public UpdateAggregation(EventBase currentEvent, EventBase previousEvent) 
      : base(currentEvent)
    {
      PreviousEvent = previousEvent;
    }

    public EventBase PreviousEvent { get; private set; }
  }
}
