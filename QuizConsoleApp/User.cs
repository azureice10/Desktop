namespace QuizConsoleApp
{
    internal class User(string username, string password, int level)
    {
        // Atribut-atribut user
        public string Username { get; set; } = username;
        public string Password { get; set; } = password;
        public int Level { get; set; } = level;

    }
}
