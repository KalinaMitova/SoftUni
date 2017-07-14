using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_PokemonEvolution
{
    class Pokemon
    {
        public string Name { get; set; }

        public List<Evolution> Evolutions { get; set; }                
    }

    class Evolution
    {
        public string EvolutionType { get; set; }

        public long EvolutionIndex { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Pokemon> pokemons = new List<Pokemon>();
            
            string line = Console.ReadLine();
            while (line != "wubbalubbadubdub")
            {
                string[] tokens = line
                    .Split(" ->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                string pokemonName = tokens[0];

                if (tokens.Length == 1)
                {
                    if (pokemons.Any(p => p.Name == pokemonName))
                    {
                        Pokemon pokemonToPrint = pokemons.Find(p => p.Name == pokemonName);
                        Console.WriteLine($"# {pokemonToPrint.Name}");
                        foreach (var evo in pokemonToPrint.Evolutions)
                        {
                            Console.WriteLine($"{evo.EvolutionType} <-> {evo.EvolutionIndex}");
                        }
                    }
                }
                else
                {
                    string evolutionType = tokens[1];
                    int evolutionIndex = int.Parse(tokens[2]);

                    Evolution currentEvolution = new Evolution
                    {
                        EvolutionType = evolutionType,
                        EvolutionIndex = evolutionIndex
                    };

                    if (pokemons.All(p => p.Name != pokemonName))
                    {
                        Pokemon currentPokemon = new Pokemon
                        {
                            Name = pokemonName,
                            Evolutions = new List<Evolution>()
                        };

                        currentPokemon.Evolutions.Add(currentEvolution);

                        pokemons.Add(currentPokemon);
                    }
                    else
                    {
                        Pokemon searchedPokemon = pokemons.Find(p => p.Name == pokemonName);
                        searchedPokemon.Evolutions.Add(currentEvolution);
                    }
                }

                line = Console.ReadLine();
            }

            foreach (var pokemon in pokemons)
            {
                Console.WriteLine($"# {pokemon.Name}");
                foreach (var evo in pokemon.Evolutions.
                    OrderByDescending(e => e.EvolutionIndex))
                {
                    Console.WriteLine($"{evo.EvolutionType} <-> {evo.EvolutionIndex}");
                }
            }
        }
    }
}
