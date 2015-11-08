using System;
using AuditReportPoc.Enums;
using AuditReportPoc.Events;

namespace AuditReportPoc.Matcher
{
  public class BasicActivityMatcher : BaseActivityMatcher
  {
    private readonly Predicate<EventBase> _internalPredicate;

    public BasicActivityMatcher(Predicate<EventBase> predicate, UserActivity activity, int priority) 
      : base(activity, priority)
    {
      _internalPredicate = predicate;
    }

    public override bool Match(EventBase @event)
    {
      return _internalPredicate(@event);
    }
  }
}
