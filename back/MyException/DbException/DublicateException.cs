namespace lab.MyException.DbException
{
    public class DublicateException:Exception
    {
        public string field { get; }

        public DublicateException(string message, string field) : base(message)
        {
            this.field = field;
        }
    }
}
