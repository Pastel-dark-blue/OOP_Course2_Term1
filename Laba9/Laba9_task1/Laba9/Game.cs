using System;

namespace Laba9
{
    class Game
    {
        public delegate void Attack(int energyBeforeHit, int expendedEnergy, int Energy, bool edible);
        public delegate void Heal(int energyBeforeHeal, int expendedEnergy, int Energy);

        public Game(gamerPosition position)
        {
            //каждому игроку вначале игры дается энергия = 100 единиц
            Energy = 100;

            Position = position;
        }

        public gamerPosition Position { get; set; }

        public event Attack AttackEvent; //событие: игрок атаковал
        public event Heal HealEvent; //событие: игрок вылечил

        //энергия игрока
        private int energy;
        public int Energy
        {
            get
            {
                return energy;
            }
            private set
            {
                energy = value;
            }
        }

        //игрок нанес удар
        public void Hit(bool edible)
        {
            //записываем значение энергии до удара
            int energyBeforeHit = Energy;

            //затраченная энергия (зависит от позиции игрока)
            int expendedEnergy = 0;

            //в зависимости от того, является ли игрок воином или целителем, на аттаку он затратит разное количество энергии
            switch (this.Position)
            {
                case gamerPosition.Warrior:
                    if (edible) expendedEnergy = 5;
                    else expendedEnergy = 3;
                    break;
                case gamerPosition.Healer:
                    if (edible) expendedEnergy = 7;
                    else expendedEnergy = 5;
                    break;
            }

            if (energyBeforeHit > expendedEnergy)
            {
                //отнимаем от значения энергии до удара количество затраченной на этот удар энергии
                Energy -= expendedEnergy;
                //если игрок аттаковал нечто съестное, то он это съедает и получает энергию
                if (edible)
                {
                    Energy += 10;
                }
            }

            //извещаем подписчиков на событие AttackEvent, о том что игрок атаковал
            AttackEvent?.Invoke(energyBeforeHit, expendedEnergy, Energy, edible);
        }

        //игрок кого-то вылечил
        public void Help()
        {
            int energyBeforeHeal = Energy;

            int expendedEnergy = 0;

            switch (this.Position)
            {
                case gamerPosition.Warrior:
                    expendedEnergy = 20;
                    break;
                case gamerPosition.Healer:
                    expendedEnergy = 5;
                    break;
            }

            if (energyBeforeHeal > expendedEnergy)
            {
                Energy -= expendedEnergy;
            }

            HealEvent?.Invoke(energyBeforeHeal, expendedEnergy, Energy);
        }

        public void getEnergy()
        {
            Energy += 10;
            Console.WriteLine("**Вы пополнили запас энергии на 10 единиц**");
        }

        public void displayCurrentEnergy()
        {
            Console.WriteLine($"**Ваша энергия = {Energy}**");
        }
    }

}
