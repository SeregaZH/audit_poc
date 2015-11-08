using AuditReportPoc.Enums;

namespace AuditReportPoc
{
  public interface IActivityResolver<in TEvent>
  {
    UserActivity Resolve(TEvent @event);
  }
}
