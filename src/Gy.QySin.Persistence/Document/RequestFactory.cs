using System.Text;
using Gy.QySin.Application.Common.Interfaces;
using MyCouch.Requests;

namespace Gy.QySin.Persistence.Document
{
    public class RequestFactory
    {
        public static QueryViewRequest NewQueryViewRequest(
            string viewName,
            IByDateQuery byDateQuery
        )
        {
            var sb = new StringBuilder();
            foreach (var comp in byDateQuery.Date)
            {
                sb.Append($"{comp}:");
            }
            string key = sb.ToString();
            var query = new QueryViewRequest(viewName);
            query.Limit = byDateQuery.Limit;
            query.StartKey = key + "0";
            query.EndKey = key + ":";
            // query.StartKey = $"{hoy.Year}:{hoy.Month}:{hoy.Day}:0";
            // query.EndKey = $"{hoy.Year}:{hoy.Month}:{hoy.Day}::";
            return query;
        }
    }
}