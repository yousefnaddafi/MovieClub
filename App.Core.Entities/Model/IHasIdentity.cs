using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Entities.Model
{
    public interface IHasIdentity
    {
        int Id { get; set; }
    }
}
