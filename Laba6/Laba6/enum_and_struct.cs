using System;

namespace Laba6
{
        public enum WaysToCreateACartoon {
            пластилиновый,
            рисованный,
            кукольный,
            компьютерный,
            художественный,
        }

    struct Director 
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public Director(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}
