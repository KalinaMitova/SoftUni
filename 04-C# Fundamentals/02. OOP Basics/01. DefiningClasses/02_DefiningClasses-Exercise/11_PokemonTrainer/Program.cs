using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<Trainer> trainers = new List<Trainer>();

        string input;
        while ((input = Console.ReadLine()) != "Tournament")
        {
            string[] tokens = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            string trainerName = tokens[0];
            string pokemonName = tokens[1];
            string pokemonElement = tokens[2];
            decimal pokemonHealth = decimal.Parse(tokens[3]);

            Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

            if (trainers.Any(t => t.Name == trainerName))
            {
                trainers.Single(t => t.Name == trainerName).Pokemons.Add(pokemon);
            }
            else
            {
                Trainer trainer = new Trainer(trainerName);
                trainer.Pokemons.Add(pokemon);
                trainers.Add(trainer);
            }
        }

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            foreach (var trainer in trainers)
            {
                if(trainer.Pokemons.Any(p => p.Element == command))
                {
                    trainer.Badges++;
                }
                else
                {
                    for (int i = 0; i < trainer.Pokemons.Count(); i++)
                    {
                        var pokemon = trainer.Pokemons[i];
                        pokemon.Health -= 10;
                        if (pokemon.Health <= 0)
                        {
                            trainer.Pokemons.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }
        }

        foreach (var trainer in trainers.OrderByDescending(t => t.Badges))
        {
            Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count()}");
        }
    }
}