using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Entities.Exceptions
{
    public class InvalidIdException : ApplicationException
    {
        public InvalidIdException(string msg) : base(msg)
        {

        }
    }
}
