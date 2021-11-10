using System;

namespace Laba7
{
        public enum WaysToCreateACartoon {
            пластилиновый = 1,
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
