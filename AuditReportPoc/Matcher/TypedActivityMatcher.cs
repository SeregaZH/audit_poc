using AuditReportPoc.Enums;
using AuditReportPoc.Events;

namespace AuditReportPoc.Matcher
{
  public abstract class TypedActivityMatcher<TType> : BaseActivityMatcher 
    where TType : EventBase
  {
    protected TypedActivityMatcher(UserActivity activity, int priority) 
      : base(activity, priority)
    {
      
    }

    public sealed override bool Match(EventBase @event)
    {
      var typedEvent = @event as TType;
      if (typedEvent != null)
      {
        return MatchType(typedEvent);
      }

      return false;
    }

    protected virtual bool MatchType(TType typedEvent)
    {
      return false;
    }
  }
}
