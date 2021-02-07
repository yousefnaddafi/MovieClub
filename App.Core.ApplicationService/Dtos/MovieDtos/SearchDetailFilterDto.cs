using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.Dtos.MovieDtos
{
    public class SearchDetailFilterDto
    {
        public string title { get; set; }
        public string productYear { get; set; }
        public float rateByUser { get; set; }
        public List<string> actors { get; set; }
        public List<string> genres { get; set; }
    }
    
}
