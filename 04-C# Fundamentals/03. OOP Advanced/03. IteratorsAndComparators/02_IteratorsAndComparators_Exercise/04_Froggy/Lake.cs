using System;
using System.Collections;
using System.Collections.Generic;

namespace _04_Froggy
{
    public class Lake<T> : IEnumerable<T>
    {
        private IList<T> stones;

        public Lake(IList<T> stones)
        {
            this.stones = stones;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.stones.Count; i+=2)
            {
                yield return this.stones[i];
            }

            int start = this.stones.Count % 2 == 0 ? this.stones.Count - 1 : this.stones.Count - 2;

            for (int i = start; i >= 1; i -= 2)
            {
                yield return this.stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
