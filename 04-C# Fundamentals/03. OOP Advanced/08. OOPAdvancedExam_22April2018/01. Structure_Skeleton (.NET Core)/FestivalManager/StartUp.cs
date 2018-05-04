﻿namespace FestivalManager
{
	using System.IO;
	using System.Linq;
	using Core;
	using Core.Contracts;
	using Core.Controllers;
	using Core.Controllers.Contracts;
	using Core.IO;
	using Core.IO.Contracts;
	using Entities;
	using Entities.Contracts;

	public static class StartUp
	{
		public static void Main(string[] args)
		{
			Stage stage = new Stage();
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

			IFestivalController festivalController = new FestivalController(stage);
			ISetController setController = new SetController(stage);

			var engine = new Engine(festivalController, setController, reader, writer);

			engine.Run();
		}
	}
}