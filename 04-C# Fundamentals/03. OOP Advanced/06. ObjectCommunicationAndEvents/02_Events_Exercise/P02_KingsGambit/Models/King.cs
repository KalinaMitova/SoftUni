namespace P02_KingsGambit
{
    using System;
    using System.Collections.Generic;

    using P02_KingsGambit.Contracts;
    
    public class King : IKing
    {
        private ICollection<ISubordinate> subordinates;

        public King(string name, ICollection<ISubordinate> subordinates)
        {
            this.Name = name;
            this.subordinates = subordinates;
        }

        public string Name { get; private set; }

        public IReadOnlyCollection<ISubordinate> Subordinates => (IReadOnlyCollection<ISubordinate>)this.subordinates;
        
        public event GetAttackedEventHandler GetAttackedEvent;
        
        public void GetAttacked()
        {
            Console.WriteLine($"{this.GetType().Name} {this.Name} is under attack!");
            if (this.GetAttackedEvent != null)
            {
                this.GetAttackedEvent.Invoke();
            }
        }

        public void AddSubordinate(ISubordinate subordinate)
        {
            this.subordinates.Add(subordinate);
            this.GetAttackedEvent += subordinate.ReactToAttack;
            subordinate.DeathEvent += this.OnSubordinateDeath;
        }
        
        public void OnSubordinateDeath(object sender)
        {
            this.GetAttackedEvent -= ((ISubordinate)sender).ReactToAttack;
            this.subordinates.Remove((ISubordinate)sender);
        }
    }
}
