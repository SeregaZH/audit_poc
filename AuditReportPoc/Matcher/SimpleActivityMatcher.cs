using System;
using AuditReportPoc.Enums;
using AuditReportPoc.Events;

namespace AuditReportPoc.Matcher
{
  public sealed class SimpleActivityMatcher<TType> : TypedActivityMatcher<TType> where TType : EventBase
  {
    private readonly Predicate<TType> _predicate;
    
    public SimpleActivityMatcher(Predicate<TType> predicate, UserActivity activity, int priority) 
      : base(activity, priority)
    {
      _predicate = predicate;
    }

    protected override bool MatchType(TType typedEvent)
    {
      return _predicate(typedEvent);
    }
  }
}
