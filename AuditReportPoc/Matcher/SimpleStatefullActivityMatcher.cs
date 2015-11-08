using System;
using AuditReportPoc.Enums;
using AuditReportPoc.Events;

namespace AuditReportPoc.Matcher
{
  public class SimpleStatefullActivityMatcher<TType> : BaseStatefullActivityMatcher<TType> 
    where TType : EventBase
  {
    private readonly Func<TType, TType, bool> _predicate;
    
    public SimpleStatefullActivityMatcher(Func<TType, TType, bool> predicate, UserActivity activity, int priority) 
      : base(activity, priority)
    {
      _predicate = predicate;
    }

    protected override bool Match(TType currentEvent, TType prevEvent)
    {
      if (prevEvent != null)
      {
        return _predicate(currentEvent, prevEvent);
      }

      return false;
    }
  }
}
