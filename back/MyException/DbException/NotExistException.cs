namespace lab.MyException.DbException
{
    public class NotExistException:Exception
    {
        public string field { get;}

        public NotExistException(string message,string field):base(message)
        {
            this.field = field;
        }
    }
}
