using System;

namespace Players.Infrastructure.Domain
{
    public class PlayerScoreEntity
    {
        protected PlayerScoreEntity()
        {
            CreatedOn = DateTime.Now;
        }
        public static PlayerScoreEntity Create(string login, int score)
        {
            var entity = new PlayerScoreEntity
            {
                Login = login,
                Score = score
            };
            return entity;
        }

        public void Update(int score)
        {
            Score = score;
            ModifiedOn = DateTime.Now;
        }

        public int Id { get; protected set; }
        public string Login { get; protected set; }
        public int Score { get; protected set; }
        public DateTime CreatedOn { get; protected set; }
        public DateTime? ModifiedOn { get; protected set; }
    }
}
