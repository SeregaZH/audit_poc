using System;

namespace AuditReportPoc.Events
{
  public sealed class DocumentEvent : EventBase
  {
    public Guid  DocumentId { get; set; }

    public string State { get; set; }
  }
}
