namespace Stations.App
{
    using System.Linq;

    using Stations.Models;
    using Stations.DataProcessor.Dto;
    using Stations.DataProcessor.Dto.Import;

    using AutoMapper;

    public class StationsProfile : Profile
	{
		// Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
		public StationsProfile()
		{
            CreateMap<StationDto, Station>();
            CreateMap<SeatingClassDto, SeatingClass>();
		}
	}
}
