namespace P02_KingsGambit.Models
{
    using System;

    using P02_KingsGambit.Contracts;

    public abstract class Subordinate : ISubordinate
    {
        protected Subordinate(string name, string action, int hitPoints)
        {
            this.Name = name;
            this.Action = action;
            this.HitPoints = hitPoints;

            this.IsAlive = true;
        }

        public string Name { get; }

        public string Action { get; }

        public bool IsAlive { get; private set; }

        public int HitPoints { get; private set; }

        public event SubordinateDeathEventHandler DeathEvent;

        public void Die()
        {
            this.IsAlive = false;
            if(this.DeathEvent != null)
            {
                this.DeathEvent.Invoke(this);
            }
        }

        public virtual void ReactToAttack()
        {
            Console.WriteLine($"{this.GetType().Name} {this.Name} is {this.Action}!");
        }

        public void TakeDamage()
        {
            this.HitPoints--;
        }
    }
}
