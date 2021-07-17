namespace Players.Dto.Commands
{
    public class AddPlayerScoreCommand
    {
        protected AddPlayerScoreCommand()
        {

        }
        public AddPlayerScoreCommand(string login, int score)
        {
            Login = login;
            Score = score;
        }

        public string Login { get; protected set; }
        public int Score { get; protected set; }
    }
}
