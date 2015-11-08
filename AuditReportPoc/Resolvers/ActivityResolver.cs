using System.Collections.Generic;
using System.Linq;
using AuditReportPoc.Enums;

namespace AuditReportPoc.Resolvers
{
  public class ActivityResolver<TEvent> : IActivityResolver<TEvent>
  {
    private readonly IEnumerable<IActivityMatcher<TEvent>> _matchers;

    public ActivityResolver(IEnumerable<IActivityMatcher<TEvent>> matchers)
    {
      _matchers = matchers.OrderByDescending(x => x.Priority);
    }

    public UserActivity Resolve(TEvent @event)
    {
      UserActivity result = UserActivity.None;

      foreach (var matcher in _matchers)
      {
        if (matcher.Match(@event))
        {
          result = matcher.GetActivity();
        }
      }

      return result;
    }
  }
}
