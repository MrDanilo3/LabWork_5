using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conteiner
{
    internal class Bear
    {
        private readonly HoneyPot _pot;

        public Bear(HoneyPot pot)
        {
            _pot = pot;
        }

        public void Start()
        {
            while (true)
            {
                _pot.GetPortion();// Ведмідь отримує порцію меду з вулика
                Thread.Sleep(1000);//Ведмідь спить 1 секунду, перерва між діями
                Console.WriteLine("Bear is sleeping");
                _pot.Refill();// Ведмідь додає порцію меду у вулик
            }
        }

        public void EatHoney()
        {
            while (true)
            {
                lock (_pot)
                {
                    // Якщо вулик не повний, то ведмідь спить
                    while (!_pot.IsFull())
                    {
                        Console.WriteLine("Bear is sleeping...");
                        Monitor.Wait(_pot);
                    }
                    _pot.Empty();
                    
                    Console.WriteLine("Bear ate all the honey and is going to sleep...");
                    // Ведмідь спить 2 секунди, перерва між діями
                    Thread.Sleep(2000);
                }
            }
        }
    }
}
