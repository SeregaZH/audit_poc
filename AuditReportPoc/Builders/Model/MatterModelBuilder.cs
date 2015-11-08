using AuditReportPoc.Context;
using AuditReportPoc.Enums;

namespace AuditReportPoc.Builders.Model
{
  public class MatterModelBuilder : IModelBuilder
  {
    public AuditReportModel Build(BaseActivityContext context)
    {
      return new AuditReportModel
      {
        Activity = context.Activity,
        Type = UserActivityType.MatterSetup
      };
    }
  }
}
