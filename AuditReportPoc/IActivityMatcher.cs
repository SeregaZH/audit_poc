using AuditReportPoc.Enums;

namespace AuditReportPoc
{
  public interface IActivityMatcher<in TEvent>
  {
    bool Match(TEvent @event);

    UserActivity GetActivity();

    int Priority { get; }
  }
}
