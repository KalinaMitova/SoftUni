using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04_RoliTheCoder
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Event> totalEvents = new List<Event>();

            var line = Console.ReadLine();

            while (line != "Time for Code")
            {
                var tokens = line.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(e => e.Trim())
                    .ToArray();
                
                string id = tokens[0];
                string name = tokens[1];
                List<string> participants = tokens.Skip(2).Take(tokens.Length - 2).ToList();

                if (name[0] != '#' || participants.Any(p => p[0] != '@'))
                {
                    line = Console.ReadLine();
                    continue;
                }

                Event currentEvent = new Event
                {
                    Id = id,
                    Name = name.Substring(1),
                    Participants = participants.Distinct().ToList()
                };

                if (totalEvents.All(e => e.Id != currentEvent.Id))
                {
                    totalEvents.Add(currentEvent);
                }
                else if (totalEvents.Any(e => e.Id == currentEvent.Id && e.Name == currentEvent.Name))
                {
                    var eventToAddList = totalEvents.Find(e => e.Id == currentEvent.Id && e.Name == currentEvent.Name);
                    eventToAddList.Participants.AddRange(currentEvent.Participants);
                    eventToAddList.Participants = eventToAddList.Participants.Distinct().ToList();
                }

                line = Console.ReadLine();
            }

            foreach (var ev in totalEvents
                .OrderByDescending(e => e.Participants.Count)
                .ThenBy(e => e.Name))
            {
                Console.WriteLine($"{ev.Name} - {ev.Participants.Count}");
                foreach (var participant in ev.Participants
                    .OrderBy(p => p))
                {
                    Console.WriteLine(participant);
                }
            }
        }
    }

    class Event
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public List<string> Participants { get; set; }

    }
}
