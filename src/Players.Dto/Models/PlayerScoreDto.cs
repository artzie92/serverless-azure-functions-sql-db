using System;

namespace Players.Dto.Models
{
    public class PlayerScoreDto
    {
        public string Login { get; set; }
        public int Score { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}