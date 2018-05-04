namespace _08_PetClinic.Enumerators
{
    using System.Collections;
    using System.Collections.Generic;

    public class AddEnumerator : IEnumerable<int>
    {
        private int size;

        public AddEnumerator(int size)
        {
            this.size = size;
        }

        public IEnumerator<int> GetEnumerator()
        {
            int startIndex = this.size / 2; ;

            for (int i = 0; i < this.size; i++)
            {
                if (i % 2 == 1)
                {
                    yield return startIndex -= i;
                }
                else
                {
                    yield return startIndex += i;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
