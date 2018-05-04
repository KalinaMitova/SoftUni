namespace FestivalManager.Core.Controllers
{
	using System;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using Contracts;
	using Entities.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
	{
		private const string TimeFormat = "mm\\:ss";
		private const string TimeFormatLong = "{0:D2}:{1:D2}";
		private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";
                
        private readonly IStage stage;

        private ISetFactory setFactory;
        private IInstrumentFactory instrumentFactory;
        private IPerformerFactory performerFactory;
        private ISongFactory songFactory;

		public FestivalController(IStage stage)
		{
			this.stage = stage;

            this.setFactory = new SetFactory();
            this.instrumentFactory = new InstrumentFactory();
            this.performerFactory = new PerformerFactory();
            this.songFactory = new SongFactory();
		}

		public string RegisterSet(string[] args)
		{
            string name = args[0];
            string type = args[1];

            ISet set = this.setFactory.CreateSet(name, type);

            this.stage.AddSet(set);

            return $"Registered {type} set";
		}

		public string SignUpPerformer(string[] args)
		{
			string name = args[0];
			int age = int.Parse(args[1]);

			string[] instrumentNames = args.Skip(2).ToArray();

            var performer = this.performerFactory.CreatePerformer(name, age);

            if (instrumentNames.Length > 0)
            {
                IInstrument[] instruments = instrumentNames
                .Select(i => this.instrumentFactory.CreateInstrument(i))
                .ToArray();
                
                foreach (var instrument in instruments)
                {
                    performer.AddInstrument(instrument);
                }
            }
            
            this.stage.AddPerformer(performer);

			return $"Registered performer {name}";
		}

		public string RegisterSong(string[] args)
		{
            string songName = args[0];
            
            TimeSpan duration = TimeSpan.ParseExact(args[1], TimeFormat, CultureInfo.InvariantCulture);

            ISong song = this.songFactory.CreateSong(songName, duration);

            this.stage.AddSong(song);

			return $"Registered song {songName} ({duration:mm\\:ss})";
		}

		public string AddPerformerToSet(string[] args)
		{
            var performerName = args[0];
            var setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }
            
            IPerformer performer = this.stage.GetPerformer(performerName);
            ISet set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return $"Added {performer.Name} to {set.Name}";
        }
        
		public string RepairInstruments(string[] args)
		{
			var instrumentsToRepair = this.stage.Performers
				.SelectMany(p => p.Instruments)
				.Where(i => i.Wear < 100)
				.ToArray();

			foreach (var instrument in instrumentsToRepair)
			{
				instrument.Repair();
			}

			return $"Repaired {instrumentsToRepair.Length} instruments";
		}

        public string ProduceReport()
        {
            var result = new StringBuilder();

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            result.AppendLine($"Festival length: " + string.Format("{0:D2}:{1:D2}", (int)totalFestivalLength.TotalMinutes, totalFestivalLength.Seconds));

            foreach (var set in this.stage.Sets)
            {
                result.AppendLine($"--{set.Name} ({string.Format("{0:D2}:{1:D2}", (int)set.ActualDuration.TotalMinutes, set.ActualDuration.Seconds)}):");

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    string instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result.AppendLine($"---{performer.Name} ({instruments})");
                }

                if (!set.Songs.Any())
                {
                    result.AppendLine("--No songs played");
                }
                else
                {
                    result.AppendLine("--Songs played:");
                    foreach (var song in set.Songs)
                    {
                        result.AppendLine("----" + song.ToString());
                    }
                }
            }

            return result.ToString().Trim();
        }

        public string AddSongToSet(string[] args)
        {
            string songName = args[0];
            string setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            ISong song = this.stage.GetSong(songName);
            ISet set = this.stage.GetSet(setName);

            set.AddSong(song);

            return string.Format($"Added {song.Name} ({song.Duration:mm\\:ss}) to {setName}");
        }
    }
}