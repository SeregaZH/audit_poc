using System.Collections.Generic;
using System.Linq;
using AuditReportPoc.Events;

namespace AuditReportPoc.EventAggregators
{
  public class UpdateAggregator<TEvent> : IEventAggregator
  {
    private readonly Queue<EventBase> _events;

    public UpdateAggregator()
    {
      _events = new Queue<EventBase>();
    }

    public void Aggregate(EventBase @event)
    {
      if (@event is TEvent)
      {
        if (_events.Count > 2)
        {
          _events.Dequeue();
        }

        _events.Enqueue(@event);
      }
    }

    public BaseAggregation GetAggregation()
    {
      var eventsCopy = _events.ToList();
      return new UpdateAggregation(eventsCopy.LastOrDefault(), eventsCopy.FirstOrDefault());
    }
  }
}
