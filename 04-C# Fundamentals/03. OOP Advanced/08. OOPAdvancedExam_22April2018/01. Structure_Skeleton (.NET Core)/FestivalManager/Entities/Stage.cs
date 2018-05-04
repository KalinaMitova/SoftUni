namespace FestivalManager.Entities
{
	using System.Collections.Generic;
    using System.Linq;
    using Contracts;

	public class Stage : IStage
	{
		// да си вкарват през полетата бе
		private readonly List<ISet> sets;
        private readonly List<ISong> songs;
        private readonly List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => this.sets.AsReadOnly();

        public IReadOnlyCollection<ISong> Songs => this.songs.AsReadOnly();

        public IReadOnlyCollection<IPerformer> Performers => this.performers.AsReadOnly();

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSet(ISet performer)
        {
            this.sets.Add(performer);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            IPerformer performer = this.performers.FirstOrDefault(p => p.Name == name);

            if(performer == null)
            {
                //TODO:
                throw new System.Exception();
            }

            return performer;
        }

        public ISet GetSet(string name)
        {
            ISet set = this.sets.FirstOrDefault(p => p.Name == name);

            if (set == null)
            {
                //TODO:
                throw new System.Exception();
            }

            return set;
        }

        public ISong GetSong(string name)
        {
            ISong song = this.songs.FirstOrDefault(p => p.Name == name);

            if (song == null)
            {
                //TODO:
                throw new System.Exception();
            }

            return song;
        }

        public bool HasPerformer(string name)
        {
            return this.performers.Any(p => p.Name == name);
        }

        public bool HasSet(string name)
        {
            return this.sets.Any(p => p.Name == name);
        }

        public bool HasSong(string name)
        {
            return this.songs.Any(p => p.Name == name);
        }
    }
}
