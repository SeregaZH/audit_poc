using AuditReportPoc.Context;
using AuditReportPoc.Enums;
using AuditReportPoc.Events;

namespace AuditReportPoc.Builders.Model
{
  public class RemoveDocumentsModelBuilder : IModelBuilder
  {
    public AuditReportModel Build(BaseActivityContext context)
    {
      var cont = context as UpdateActivityContext;
      var model = new AuditReportModel { Activity = cont.Activity, Type = UserActivityType.DeleteDocument };
      model.Before.Add("State", ((DocumentEvent)cont.PreviousEvent).State);
      model.After.Add("State", ((DocumentEvent)cont.CurrentEvent).State);
      return model;
    }
  }
}
