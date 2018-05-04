using System;

using Logger.Models.Contracts;
using Logger.Models.Entities.Layouts;

namespace Logger.Models.Factories
{
    public class LayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            ILayout layout = null;

            switch (type)
            {
                case "SimpleLayout":
                    layout = new SimpleLayout();
                    break;
                case "XmlLayout":
                    layout = new XmlLayout();
                    break;
                case "JsonLayout":
                    layout = new JsonLayout();
                    break;
                default:
                    throw new ArgumentException("Invalid layout type!");                    
            }

            return layout;
        }
    }
}
