using System;

namespace AuditReportPoc.Events
{
  public class EventBase
  {
    public Guid Id { get; set; }

    public DateTime ModifyDate { get; set; }

    public Guid ModifyBy { get; set; }

    public EventType Type { get; set; }
  }
}
