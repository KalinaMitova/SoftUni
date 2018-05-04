namespace _08_PetClinic.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using _08_PetClinic.Common;
    using _08_PetClinic.Enumerators;
    using _08_PetClinic.Models.Contracts;

    public class Clinic : IClinic, IEnumerable<int>
    {
        private IPet[] rooms;
        private AddEnumerator addEnumerator;
        private ReleaseEnumerator releaseEnumerator;

        public Clinic(string name, int roomsCount)
        {
            if(roomsCount % 2 == 0)
            {
                throw new ArgumentException(ErrorMessages.InvalidOperation);
            }

            this.Name = name;
            this.rooms = new Pet[roomsCount];
            this.addEnumerator = new AddEnumerator(roomsCount);
            this.releaseEnumerator = new ReleaseEnumerator(roomsCount);
        }

        public string Name { get; set; }

        public bool Add(IPet pet)
        {
            foreach (var index in this.addEnumerator)
            {
                if(rooms[index] == null)
                {
                    rooms[index] = pet;
                    return true;
                }
            }
            return false;
        }

        public bool Release()
        {
            foreach (var index in this.releaseEnumerator)
            {
                if (this.rooms[index] != null)
                {
                    this.rooms[index] = null;
                    return true;
                }
            }
            return false;
        }

        public void Print(int roomIndex)
        {
            IPet room = this.rooms[roomIndex - 1];
            if(room == null)
            {
                Console.WriteLine("Room empty");
            }
            else
            {
                Console.WriteLine(room);
            }
        }

        public void PrintAll()
        {
            for (int i = 0; i < this.rooms.Length; i++)
            {
                IPet room = this.rooms[i];
                if (room == null)
                {
                    Console.WriteLine("Room empty");
                }
                else
                {
                    Console.WriteLine(room);
                }
            }
        }

        public bool HasEmptyRooms()
        {
            for (int i = 0; i < this.rooms.Length; i++)
            {
                if(this.rooms[i] == null)
                {
                    return true;
                }
            }
            return false;
        }


        public IEnumerator<int> GetEnumerator()
        {
            int startIndex = this.rooms.Length / 2; ;

            for (int i = 0; i < this.rooms.Length; i++)
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
