using AuditReportPoc.Enums;
using AuditReportPoc.Events;

namespace AuditReportPoc.Context
{
  public class UpdateActivityContext : BaseActivityContext
  {
    public UpdateActivityContext(UserActivity activity, EventBase currentEvent, EventBase previousEvent) 
      : base(activity, currentEvent)
    {
      PreviousEvent = previousEvent;
    }

    public EventBase PreviousEvent { get; private set; }
  }
}
