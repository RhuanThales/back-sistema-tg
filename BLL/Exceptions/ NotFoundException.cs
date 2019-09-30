using System;

namespace back_sistema_tg.BLL.Exceptions
{
    public class  NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }

}