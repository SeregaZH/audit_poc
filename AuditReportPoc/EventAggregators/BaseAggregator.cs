using AuditReportPoc.Events;

namespace AuditReportPoc.EventAggregators
{
  public class BaseAggregator<TEvent> : IEventAggregator where TEvent : EventBase
  {
    private EventBase _event;
    
    public void Aggregate(EventBase @event)
    {
      if (_event is TEvent)
      {
        _event = @event;
      }
    }

    public BaseAggregation GetAggregation()
    {
      return new BaseAggregation(_event);
    }
  }
}
