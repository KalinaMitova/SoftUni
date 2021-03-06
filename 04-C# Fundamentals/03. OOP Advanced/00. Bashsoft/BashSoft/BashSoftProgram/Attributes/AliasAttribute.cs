﻿namespace BashSoftProgram.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public class AliasAttribute : Attribute
    {
        private string name;

        public AliasAttribute(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public override bool Equals(object obj)
        {
            return this.name.Equals(obj);
        }
    }
}
