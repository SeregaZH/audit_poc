using System.Collections.Generic;
using AuditReportPoc.Enums;
using AuditReportPoc.Events;
using AuditReportPoc.Resolvers;

namespace AuditReportPoc
{
  public  class AuditEventsProcessor : IAuditEventsProcessor<EventBase>
  {
    public IEnumerable<AuditReportModel> Process(IEnumerable<EventBase> events)
    {
      var matchers = ActivityMatcherManager<EventBase>.GetMatchers();
      var resolver = new ActivityResolver<EventBase>(matchers);

      foreach (var ev in events)
      {
        var activity = resolver.Resolve(ev);
        ActivityBuilderManager.Aggregate(ev);

        var aggregator = ActivityBuilderManager.ResolveAggregator(activity);

        if (aggregator == null)
        {
          yield return new AuditReportModel {Activity = activity, Type = UserActivityType.None};
        }
        else
        {
          var contextBuilder = ActivityBuilderManager.ResolveContextBuilder(activity);
          var context = contextBuilder.BuildContext(activity, aggregator.GetAggregation());
          var builder = ActivityBuilderManager.ResolveModelBuilder(activity);
          yield return builder.Build(context);
        }
      }
    }
  }
}
