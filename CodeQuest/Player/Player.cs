using CodeQuest.Interfaces;

namespace CodeQuest.Player
{
    public class Player : IPlayer
    {
        public string Name { get; private set; }
        public PlayerData PlayerData = new PlayerData();

        public Player(string name)
        {
            Name = name;
        }

        public override bool Equals(Object name)
        {
            return Name.Equals(((Player)name).Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }

    // skapa fler players
}
