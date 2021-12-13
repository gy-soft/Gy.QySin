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
            IDateParams DateParams
        )
        {
            var query = new QueryViewRequest(designDocument, viewName);
            query.StartKey = new object[] { DateParams.Year, DateParams.Month, DateParams.Day };
            query.EndKey = new object[] { DateParams.Year, DateParams.Month, DateParams.Day, "z" };
            query.Reduce = true;
            return query;
        }
    }
}