using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuditReportPoc.Events;

namespace AuditReportPoc
{
  class Program
  {
    static void Main(string[] args)
    {
      var processor = new AuditEventsProcessor();
      var events = processor.Process(GetMattersEvent().Reverse());
      
      foreach (var result in events)
      {
        Console.WriteLine("{0} | {1}", result.Activity, result.Type);
      }
    }

    static IEnumerable<EventBase> GetMattersEvent()
    {
      return new List<EventBase>
      {
        new DocumentEvent {Id = Guid.NewGuid(), DocumentId = Guid.NewGuid(), Type = EventType.Delete, State = "ReadyToReview"},
        new DocumentEvent {Id = Guid.NewGuid(), DocumentId = Guid.NewGuid(), Type = EventType.Update, State = "ReadyToReview"},
        new DocumentEvent {Id = Guid.NewGuid(), DocumentId = Guid.NewGuid(), Type = EventType.Update, State = "Review"},
        new MatterEvent { Id = Guid.NewGuid(), MatterName = "qwerty23", ModifyBy = Guid.NewGuid(), OpenedDate = DateTime.Today, MatterNumber = "12345", Type = EventType.Delete},
        new MatterEvent { Id = Guid.NewGuid(), MatterName = "qwerty23", ModifyBy = Guid.NewGuid(), OpenedDate = DateTime.Today, MatterNumber = "12345", Type = EventType.Update},
        new MatterEvent { Id = Guid.NewGuid(), MatterName = "qwerty", ModifyBy = Guid.NewGuid(), OpenedDate = DateTime.Today, MatterNumber = "123451", Type = EventType.Update},
        new MatterEvent { Id = Guid.NewGuid(), MatterName = "qwerty", ModifyBy = Guid.NewGuid(), OpenedDate = DateTime.Today, MatterNumber = "12345", Type = EventType.Create},
        new DocumentEvent {Id = Guid.NewGuid(), DocumentId = Guid.NewGuid(), Type = EventType.Create, State = "ReadyToReview"}
      };
    }
  }
}
