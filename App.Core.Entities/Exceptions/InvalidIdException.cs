using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Entities.Exceptions
{
    public class InvalidIdException : Exception
    {
        public InvalidIdException(string msg) : base(msg)
        {

        }
    }
}
