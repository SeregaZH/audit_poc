using System.Collections.Generic;
using AuditReportPoc.Enums;
using AuditReportPoc.Events;
using AuditReportPoc.Matcher;

namespace AuditReportPoc
{
  public static class ActivityMatcherManager<TEvent>
    where TEvent : EventBase
  {
    private static IList<IActivityMatcher<TEvent>> matchers = new List<IActivityMatcher<TEvent>>();

    static ActivityMatcherManager()
    {
      RegisterMatchers();
    }

    private static void RegisterMatchers()
    {
      matchers.Add(new SimpleActivityMatcher<MatterEvent>((@event) => @event.Type == EventType.Delete, UserActivity.DeleteMatter, 1));
      matchers.Add(new SimpleActivityMatcher<MatterEvent>(@event => @event.Type == EventType.Create, UserActivity.CreateMatter, 1));
      matchers.Add(new SimpleActivityMatcher<DocumentEvent>(@event => @event.Type == EventType.Delete, UserActivity.DeleteDocument, 1));
      matchers.Add(
        new SimpleStatefullActivityMatcher<DocumentEvent>(
          (ev1, ev2) => ev1.State.Equals("Review") && ev2.State.Equals("ReadyToReview"), UserActivity.RemoveDocument, 1));
      matchers.Add(
        new SimpleStatefullActivityMatcher<DocumentEvent>(
          (ev1, ev2) => ev1.State.Equals("ReadyToReview") && ev2.State.Equals("Review"), UserActivity.SendToReview, 1));
      matchers.Add(
        new SimpleActivityMatcher<MatterEvent>(
          (ev) => ev.Type == EventType.Update, UserActivity.UpdateMatter, 1));
    }

    public static IEnumerable<IActivityMatcher<TEvent>> GetMatchers()
    {
      return matchers;
    }
  }
}
