using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Entities.Model
{
   public class UserLogin: IHasIdentity
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime ExpireMembershipDate { get; set; }
    }
}
