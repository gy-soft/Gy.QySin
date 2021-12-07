using MyCouch;

namespace Gy.QySin.Persistence.Document
{
    public class CouchClientFactory : ICouchClientFactory
    {
        private readonly string connString;
        public CouchClientFactory(string connString)
        {
            this.connString = connString;
        }
        public IMyCouchClient ForDatabase(string database)
        {
            return new MyCouchClient(connString, database);
        }
    }
}