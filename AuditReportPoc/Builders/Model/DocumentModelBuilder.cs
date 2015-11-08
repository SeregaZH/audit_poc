using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuditReportPoc.Context;
using AuditReportPoc.Enums;

namespace AuditReportPoc.Builders.Model
{
  public class DocumentModelBuilder : IModelBuilder
  {
    public AuditReportModel Build(BaseActivityContext context)
    {
      return new AuditReportModel {Activity = context.Activity, Type = UserActivityType.DeleteDocument};
    }
  }
}
