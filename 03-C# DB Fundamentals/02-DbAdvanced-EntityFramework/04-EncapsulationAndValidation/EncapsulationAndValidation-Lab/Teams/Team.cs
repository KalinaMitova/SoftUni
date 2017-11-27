namespace Teams
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }

        public void AddPlayer(Person player)
        {
            if (player.Age < 40)
            {
                this.firstTeam.Add(player);
            }
            else
            {
                this.reserveTeam.Add(player);
            }
        }

        public IReadOnlyList<Person> FirstTeam
        {
            get
            {
                return this.firstTeam.AsReadOnly();
            }
        }

        public IReadOnlyList<Person> ReserveTeam
        {
            get
            {
                return this.reserveTeam.AsReadOnly();
            }
        }

        public override string ToString()
        {
            string teamInfo =
                $"First team have {this.firstTeam.Count()} players" +
                Environment.NewLine +
                $"Reserve team have {this.reserveTeam.Count()} players";

            return teamInfo;
        }
    }
}
