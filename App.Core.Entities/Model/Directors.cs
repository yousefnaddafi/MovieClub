﻿using System;
using System.Collections.Generic;

namespace App.Core.Entities.Model
{
    public class Directors:IHasIdentity
    {
        public int Id { get; set; }
        public string DirectorName { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
