using AuditReportPoc.Enums;
using AuditReportPoc.Events;

namespace AuditReportPoc.Context
{
  public class BaseActivityContext
  {
    public BaseActivityContext(UserActivity activity, EventBase currentEvent)
    {
      Activity = activity;
      CurrentEvent = currentEvent;
    }

    public EventBase CurrentEvent { get; private set; }

    public UserActivity Activity { get; private set; }
  }
}
