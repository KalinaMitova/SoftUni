namespace FestivalManager.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

	using Contracts;
	using Controllers.Contracts;

	using IO.Contracts;
        
	class Engine : IEngine
    {
        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;
        private IReader reader;
        private IWriter writer;
        
        public Engine(IFestivalController festivalCоntroller, ISetController setCоntroller,
            IReader reader, IWriter writer)
        {
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
            this.reader = reader;
            this.writer = writer;
        }

		public void Run()
		{
			while (true)
			{
				var input = this.reader.ReadLine();

				if (input == "END")
					break;

				try
				{
					var result = this.ProcessCommand(input);
					this.writer.WriteLine(result);
				}
				catch (Exception ex)
				{
					this.writer.WriteLine("ERROR: " + ex.Message);
				}
			}

			var end = this.festivalCоntroller.ProduceReport();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(end);
		}

		public string ProcessCommand(string input)
		{
			var args = input.Split();

			var commadName = args.First();
			var parameters = args.Skip(1).ToArray();

			if (commadName == "LetsRock")
			{
				var sets = this.setCоntroller.PerformSets();
				return sets;
			}

			var festivalcontrolfunction = this.festivalCоntroller.GetType()
				.GetMethods()
				.FirstOrDefault(x => x.Name == commadName);

			string result;

			try
			{
				result = (string)festivalcontrolfunction.Invoke(this.festivalCоntroller, new object[] { parameters });
			}
			catch (TargetInvocationException up)
			{
				throw up.InnerException;
			}

			return result;
		}
	}
}