using Gy.QySin.Application.Common.Interfaces;

namespace Gy.QySin.SqlPersistence
{
    public class DbConfigurations : IDbConfigurations
    {
        public int ShortTextColumnLength => 15;

        public int LongTextColumnLength => 50;
    }
}