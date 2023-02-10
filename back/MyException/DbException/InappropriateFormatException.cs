using System.Net;

namespace lab.MyException.DbException
{
    public class InappropriateFormatException: Exception
    {
        public string field { get; }
        public string formatException { get; }

        public InappropriateFormatException(string field, string formatException)
        {
            this.field = field;
            this.formatException = formatException;
        }
    }
}
