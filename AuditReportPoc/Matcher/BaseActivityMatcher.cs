using AuditReportPoc.Enums;
using AuditReportPoc.Events;

namespace AuditReportPoc.Matcher
{
  public abstract class BaseActivityMatcher : IActivityMatcher<EventBase>
  {
    private readonly UserActivity _activity;
    
    protected BaseActivityMatcher(UserActivity activity, int priority)
    {
      _activity = activity;
      Priority = priority;
    }

    public abstract bool Match(EventBase @event);

    public virtual UserActivity GetActivity()
    {
      return _activity;
    }

    public int Priority { get; private set; }
  }
}
