using System;
namespace App.Core.ApplicationService.Dtos.RateByUserDtos
{
    public class RateByUserInputDto
    {
        public int MovieId { get; set; }
        public double RateByUser { get; set; }
    }
}
