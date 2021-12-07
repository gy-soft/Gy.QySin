using MyCouch;

namespace Gy.QySin.Persistence.Document
{
    public interface ICouchClientFactory
    {
        IMyCouchClient ForDatabase(string database);
    }
}