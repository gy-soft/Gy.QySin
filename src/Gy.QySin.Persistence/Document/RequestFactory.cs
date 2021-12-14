using System.Text;
using Gy.QySin.Application.Common.Interfaces;
using MyCouch.Requests;

namespace Gy.QySin.Persistence.Document
{
    public class RequestFactory
    {
        public static QueryViewRequest NewDaylyReportRequest(
            string designDocument,
            string viewName,
            IFechaParams DateParams
        )
        {
            var query = new QueryViewRequest(designDocument, viewName);
            query.StartKey = new object[] { DateParams.Año, DateParams.Mes, DateParams.Día };
            query.EndKey = new object[] { DateParams.Año, DateParams.Mes, DateParams.Día, "z" };
            query.Reduce = true;
            return query;
        }
    }
}