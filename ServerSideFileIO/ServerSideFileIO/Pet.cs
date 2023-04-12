using System;
using System.Collections;

namespace ServerSideFileIO
{
    public class Pet : IComparable
    {
        public string? Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string? Type { get; set; } = string.Empty;

        public Pet(string? name, int age, string? type)
        {
            Name = name;
            Age = age;
            Type = type;
        }

        public override string ToString()
        {
            return $"{Name}&{Age}&{Type}";
        }

        // using less specific interface IComparable
        public int CompareTo(object? obj)
        {
            // parse the object to a pet
            Pet? p = obj as Pet;

            // return -1 if the object comes first
            // return 1 if the object comes after
            // return 0 if they are the same
            return Name.CompareTo(p.Name);
        }

        // using more specific interface IComparable<Pet>
        public int CompareTo(Pet pet)
        {
            return this.Name.CompareTo(pet.Name);
        }
    }
}
