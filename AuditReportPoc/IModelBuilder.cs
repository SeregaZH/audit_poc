using AuditReportPoc.Context;

namespace AuditReportPoc
{
  public interface IModelBuilder
  {
    AuditReportModel Build(BaseActivityContext context);
  }
}
