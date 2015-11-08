using System;
using System.Collections.Generic;
using AuditReportPoc.Builders.Context;
using AuditReportPoc.Builders.Model;
using AuditReportPoc.Context;
using AuditReportPoc.Enums;
using AuditReportPoc.EventAggregators;
using AuditReportPoc.Events;

namespace AuditReportPoc
{
  public static class ActivityBuilderManager
  {
    private static IDictionary<UserActivity, IEventAggregator> aggregators = new Dictionary<UserActivity, IEventAggregator>();
    private static IDictionary<UserActivity, IContextBuilder> contextBuilders = new Dictionary<UserActivity, IContextBuilder>();
    private static IDictionary<UserActivity, IModelBuilder> modelBuilders = new Dictionary<UserActivity, IModelBuilder>();

    static ActivityBuilderManager()
    {
      RegisterAggregators();
      RegisterContextBuilders();
      RegisterModelBuilders();
    }

    public static IEventAggregator ResolveAggregator(UserActivity activity)
    {
      if (aggregators.ContainsKey(activity))
      {
        return aggregators[activity];
      }

      return null;
    }

    public static IContextBuilder ResolveContextBuilder(UserActivity activity)
    {
      if (contextBuilders.ContainsKey(activity))
      {
        return contextBuilders[activity];
      }

      return null;
    }

    public static IModelBuilder ResolveModelBuilder(UserActivity activity)
    {
      if (modelBuilders.ContainsKey(activity))
      {
        return modelBuilders[activity];
      }

      return null;
    }

    public static void Aggregate(EventBase eventBase)
    {
      foreach (var aggregate in aggregators.Values)
      {
        aggregate.Aggregate(eventBase);
      }
    }

    private static void RegisterAggregators()
    {
      aggregators.Add(UserActivity.CreateMatter, new BaseAggregator<MatterEvent>());
      aggregators.Add(UserActivity.DeleteMatter, new BaseAggregator<MatterEvent>());
      aggregators.Add(UserActivity.UpdateMatter, new BaseAggregator<MatterEvent>());
      aggregators.Add(UserActivity.RemoveDocument, new UpdateAggregator<DocumentEvent>());
    }

    private static void RegisterContextBuilders()
    {
      contextBuilders.Add(UserActivity.CreateMatter, new BaseContextBuilder());
      contextBuilders.Add(UserActivity.DeleteMatter, new BaseContextBuilder());
      contextBuilders.Add(UserActivity.UpdateMatter, new BaseContextBuilder());
      contextBuilders.Add(UserActivity.RemoveDocument, new UpdateContextBuilder());
    }

    private static void RegisterModelBuilders()
    {
      modelBuilders.Add(UserActivity.CreateMatter, new MatterModelBuilder());
      modelBuilders.Add(UserActivity.DeleteMatter, new MatterModelBuilder());
      modelBuilders.Add(UserActivity.UpdateMatter, new MatterModelBuilder());
      modelBuilders.Add(UserActivity.RemoveDocument, new RemoveDocumentsModelBuilder());
    }
  }
}
