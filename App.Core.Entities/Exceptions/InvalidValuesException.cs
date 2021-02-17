using System;
namespace App.Core.Entities.Exceptions
{
    public class InvalidValuesException : ApplicationException
    {
        public InvalidValuesException(string message) : base(message)
        {

        }
    }
}
