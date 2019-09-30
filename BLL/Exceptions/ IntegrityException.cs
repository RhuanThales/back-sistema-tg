using System;

namespace back_sistema_tg.BLL.Exceptions
{
    public class  IntegrityException : ApplicationException
    {
        public IntegrityException(string message) : base(message)
        {
        }
    }

}