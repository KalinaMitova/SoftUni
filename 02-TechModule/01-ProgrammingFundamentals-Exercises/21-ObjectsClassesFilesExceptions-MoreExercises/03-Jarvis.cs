using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Jarvis
{
    class Program
    {
        static void Main(string[] args)
        {
            var maxEnergyConsumption = long.Parse(Console.ReadLine());

            var jarvis = new Robot();
            jarvis.MaxEnergyConsumption = maxEnergyConsumption;

            var line = Console.ReadLine();

            while (line != "Assemble!")
            {
                var tokens = line.Split();

                var part = tokens[0];
                var energyConsumption = int.Parse(tokens[1]);

                switch (part)
                {
                    case "Head":
                        {
                            var iq = int.Parse(tokens[2]);
                            var skinMaterial = tokens[3];

                            var head = new Head
                            {
                                EnergyConsumption = energyConsumption,
                                Iq = iq,
                                SkinMaterial = skinMaterial
                            };

                            jarvis.AddHead(head);
                        }
                        break;
                    case "Torso":
                        {
                            var processorSize = double.Parse(tokens[2]);
                            var housingMaterial = tokens[3];

                            var torso = new Torso();
                            torso.EnergyConsumption = energyConsumption;
                            torso.ProcessorSizeInCentimeters = processorSize;
                            torso.HousingMaterial = housingMaterial;

                            jarvis.AddTorso(torso);
                        }
                        break;
                    case "Arm":
                        {
                            var armReachDistance = int.Parse(tokens[2]);
                            var countOfFingers = int.Parse(tokens[3]);

                            var arm = new Arm();
                            arm.EnergyConsumption = energyConsumption;
                            arm.ArmReachDistance = armReachDistance;
                            arm.CountOfFingers = countOfFingers;

                            jarvis.AddArm(arm);
                        }
                        break;
                    case "Leg":
                        {
                            var strength = int.Parse(tokens[2]);
                            var speed = int.Parse(tokens[3]);

                            var leg = new Leg();
                            leg.EnergyConsumption = energyConsumption;
                            leg.Strength = strength;
                            leg.Speed = speed;

                            jarvis.AddLeg(leg);
                        }
                        break;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(jarvis);
        }        
    }
        
    class Robot
    {
        public long MaxEnergyConsumption { get; set; }

        public Head Head { get; set; }

        public Torso Torso { get; set; }
        
        public List<Arm> Arms { get; set; }

        public List<Leg> Legs { get; set; }          

        public void AddHead (Head head)
        {
            if (this.Head == null)
            {
                this.Head = head;
            }
            else if (this.Head.EnergyConsumption > head.EnergyConsumption)
            {
                this.Head = head;
            }
        }

        public void AddTorso (Torso torso)
        {
            if (this.Torso == null)
            {
                this.Torso = torso;
            }
            else if (this.Torso.EnergyConsumption > torso.EnergyConsumption)
            {
                this.Torso = torso;
            }
        }

        public void AddArm(Arm arm)
        {
            if (Arms == null)
            {
                Arms = new List<Arm>();
            }

            var length = this.Arms.Count;
            if (length < 2)
            {
                Arms.Add(arm);
            }

            for (int i = 0; i < length; i++)
            {
                if (Arms[i].EnergyConsumption > arm.EnergyConsumption)
                {
                    Arms.RemoveAt(i);
                    Arms.Add(arm);
                }
            }
        }

        public void AddLeg(Leg leg)
        {
            if (Legs == null)
            {
                Legs = new List<Leg>();
            }

            var length = this.Legs.Count;
            if (length < 2)
            {
                Legs.Add(leg);
            }

            for (int i = 0; i < length; i++)
            {
                if (Legs[i].EnergyConsumption > leg.EnergyConsumption)
                {
                    Legs.RemoveAt(i);
                    Legs.Add(leg);
                }
            }
        }

        public override string ToString()
        {
            if (Head == null || Torso == null || Arms.Count < 2 || Legs.Count < 2)
            {
                return "We need more parts!";
            }

            var totalEnergy = 0L;
            totalEnergy += Head.EnergyConsumption;
            totalEnergy += Torso.EnergyConsumption;
            totalEnergy += Arms.Sum(a => a.EnergyConsumption);
            totalEnergy += Legs.Sum(l => l.EnergyConsumption);
                    
            if (totalEnergy > MaxEnergyConsumption)
            {
                return "We need more power!";
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("Jarvis:\r\n");
            sb.Append(Head.ToString());
            sb.Append(Torso.ToString());

            foreach (var arm in Arms.OrderBy(a => a.EnergyConsumption))
            {
                sb.Append(arm.ToString());
            }

            foreach (var leg in Legs.OrderBy(l => l.EnergyConsumption))
            {
                sb.Append(leg.ToString());
            }

            return sb.ToString();
        }
    }

    class Head
    {
        public int EnergyConsumption { get; set; }

        public int Iq { get; set; }

        public string SkinMaterial { get; set; }

        public override string ToString()
        {
            var result = string.Empty;
            result +=
                string.Format(
                    $"#Head:\n###Energy consumption: {EnergyConsumption}\n###IQ: {Iq}\n###Skin material: {SkinMaterial}\n");
            return result;
        }
    }

    class Torso
    {
        public int EnergyConsumption { get; set; }

        public double ProcessorSizeInCentimeters { get; set; }

        public string HousingMaterial { get; set; }

        public override string ToString()
        {
            var result = string.Empty;
            result +=
                string.Format(
                    $"#Torso:\n###Energy consumption: {EnergyConsumption}\n###Processor size: {ProcessorSizeInCentimeters:F2}\n###Corpus material: {HousingMaterial}\n");
            return result;
        }
    }

    class Leg
    {
        public int EnergyConsumption { get; set; }

        public int Strength { get; set; }

        public int Speed  { get; set; }

        public override string ToString()
        {
            var result = string.Empty;
            result +=
                string.Format(
                    $"#Leg:\n###Energy consumption: {EnergyConsumption}\n###Strength: {Strength}\n###Speed: {Speed}\n");
            return result;
        }
    }

    class Arm
    {
        public int EnergyConsumption { get; set; }

        public int ArmReachDistance  { get; set; }

        public int CountOfFingers  { get; set; }

        public override string ToString()
        {
            var result = string.Empty;
            result += 
                string.Format(
                    $"#Arm:\n###Energy consumption: {EnergyConsumption}\n###Reach: {ArmReachDistance}\n###Fingers: {CountOfFingers}\n");
            return result;
        }
    }
}
