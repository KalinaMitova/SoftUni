namespace FestivalManager.Entities.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
	using Entities.Contracts;

	public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
            Type setType = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            return (ISet)Activator.CreateInstance(setType, new object[] { name });
		}
	}
}
