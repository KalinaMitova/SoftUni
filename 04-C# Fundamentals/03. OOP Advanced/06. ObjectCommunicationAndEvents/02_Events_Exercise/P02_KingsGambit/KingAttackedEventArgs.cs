namespace P02_KingsGambit
{
    using System;

    using P02_KingsGambit.Contracts;

    public class KingAttackedEventArgs : EventArgs
    {
        public KingAttackedEventArgs(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}
