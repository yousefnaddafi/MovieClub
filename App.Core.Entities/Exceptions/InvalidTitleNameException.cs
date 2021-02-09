using System;
namespace App.Core.Entities.Exceptions
{
    public class InvalidTitleNameException : ApplicationException
    {
        public InvalidTitleNameException(string message) : base(message)
        {

        }
    }
}
