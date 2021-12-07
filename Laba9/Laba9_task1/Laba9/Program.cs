using System;

namespace Laba9
{
    class Program
    {
        delegate void getCurrentState();

        static void Main(string[] args)
        {
            Game gamer = null;
            
            byte pos; //позиция игрока
            byte action; //действие игрока

            while (true)
            {
                Console.WriteLine("--> Выберите игрока <--\n1 - воин \n2 - целитель \n3 - выход");
                
                byte.TryParse(Console.ReadLine(), out pos);
                if(pos == 3)
                {
                    return;
                }
                else if(pos == 1 || pos == 2) 
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Игрок не зарегестрирован. \nВыберите один из предложенных вариантов.");
                }
            }

            switch (pos)
            {
                case 1:
                    gamer = new Game(gamerPosition.Warrior);
                    break;
                case 2:
                    gamer = new Game(gamerPosition.Healer);
                    break;
            }
            gamer.AttackEvent += StateAfterAttack;
            gamer.HealEvent += StateAfterHeal;

            //Лямбда
            getCurrentState displayCurrentEnergy = () => Console.WriteLine($"**Ваша энергия = {gamer.Energy}**");

            while (true)
            {
                Console.WriteLine("\n--> Что вы хотите сделать? <--");
                Console.WriteLine("1 - аттаковать и кушать \n2 - просто аттаковать \n3 - вылечить другого игрока " +
                    "\n4 - выполнить задание и пополнить запас энергии \n5 - посмотреть текущий уровень энергии \n6 - выход");
                bool suitableValue = byte.TryParse(Console.ReadLine(), out action);
                if (!suitableValue)
                {
                    Console.WriteLine("Выберите один из предложенных вариантов.");
                    continue;
                }

                switch (action)
                {
                    case 1:
                        gamer.Hit(true);
                        break;
                    case 2:
                        gamer.Hit(false);
                        break;
                    case 3:
                        gamer.Help();
                        break;
                    case 4:
                        gamer.getEnergy();
                        break;
                    case 5:
                        displayCurrentEnergy();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Выберите один из предложенных вариантов.");
                        break;
                }
            }
        }

       static public void StateAfterAttack(int energyBeforeHit, int expendedEnergy, int Energy, bool edible)
        {
            if (energyBeforeHit < expendedEnergy)
            {
                Console.WriteLine("Для аттаки вам не хватило " + (expendedEnergy - energyBeforeHit) + " ед. энергии");
                return;
            }
            
            Console.WriteLine("Ваша энергия до аттаки была : " + energyBeforeHit);
            Console.WriteLine("Вы затратили на аттаку : " + expendedEnergy);

            if (edible)
            {
                Console.WriteLine("Вы аттаковали нечто съестное и получили + 10 к энергии");
            }
            else
            {
                Console.WriteLine("Вы аттаковали нечто несъестное");
            }

            Console.WriteLine("Ваш текущий уровень энергии : " + Energy);
        }

        static public void StateAfterHeal(int energyBeforeHit, int expendedEnergy, int Energy)
        {
            if (energyBeforeHit < expendedEnergy)
            {
                Console.WriteLine("Для исцеления игрока вам не хватило " + (expendedEnergy - energyBeforeHit) + " ед. энергии");
                return;
            }

            Console.WriteLine("Ваша энергия до исцеления была : " + energyBeforeHit);
            Console.WriteLine("Вы затратили на исцеление : " + expendedEnergy);

            Console.WriteLine("Ваш текущий уровень энергии : " + Energy);
        }
    }
}

