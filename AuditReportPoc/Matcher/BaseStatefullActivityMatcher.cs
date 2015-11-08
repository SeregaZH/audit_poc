using System;
using System.Collections.Generic;
using System.Linq;
using AuditReportPoc.Enums;
using AuditReportPoc.Events;

namespace AuditReportPoc.Matcher
{
  public abstract class BaseStatefullActivityMatcher<TType> : TypedActivityMatcher<TType>
    where TType : EventBase
  {
    private readonly Stack<TType> _states;
    
    public BaseStatefullActivityMatcher(UserActivity activity, int priority) 
      : base(activity, priority)
    {
      _states = new Stack<TType>();
      
    }

    protected sealed override bool MatchType(TType typedEvent)
    {
      var previous = _states.Any() ? _states.Pop() : null;
      var result = this.Match(typedEvent, previous);
      _states.Push(typedEvent);
      return result;
    }

    protected virtual bool Match(TType currentEvent, TType prevEvent)
    {
      return false;
    }
  }
}
