namespace _08_PetClinic.Enumerators
{
    using System.Collections;
    using System.Collections.Generic;

    public class ReleaseEnumerator : IEnumerable<int>
    {
        private int size;

        public ReleaseEnumerator(int size)
        {
            this.size = size;
        }

        public IEnumerator<int> GetEnumerator()
        {
            int index = this.size / 2;

            for (int i = 0; i < this.size; i++)
            {
                yield return index;

                index = (index + 1) % (this.size);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
