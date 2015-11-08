using System;

namespace AuditReportPoc.Events
{
  public sealed class MatterEvent : EventBase
  {
    public string MatterName { get; set; }

    public string  MatterNumber { get; set; }

    public DateTime OpenedDate { get; set; }
  }
}
