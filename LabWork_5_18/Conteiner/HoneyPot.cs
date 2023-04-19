using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conteiner
{
    internal class HoneyPot
    {
        private int _portion;
        private readonly int _maxCapacity;
        private bool _isFull;

        public HoneyPot(int maxCapacity)
        {
            _maxCapacity = maxCapacity;
        }

        //метод, що додає порцію меду до горщика та виводить повідомлення з номером бджоли, яка додала порцію та кількістю порцій, які знаходяться в горщику
        public void AddPortion(int id)
        {
            _portion++;
            Console.WriteLine("Bee {0} added portion to the pot. Current portion count: {1}", id, _portion);
        }

        //етод, який будить ведмедя, якщо горщик заповнений
        public void WakeUpBear()
        {
            lock (this)
            {
                _isFull = true;
                Monitor.Pulse(this);
            }
        }

        //Повертає стан горщика
        public bool IsFull()
        {
            return _portion >= _maxCapacity;
        }

        //метод, який вилучає порцію меду з горщика та виводить повідомлення про кількість порцій
        public void GetPortion()
        {
            lock (this)
            {
                while (!_isFull)
                {
                    Console.WriteLine("Bear is sleeping...");
                    Monitor.Wait(this);
                }
                _isFull = false;
                Console.WriteLine("Bear got a portion from the pot. Current portion count: {0}", _portion);
            }
        }

        public void Empty()
        {
            _portion = 0;
        }


        //метод, що заповнює горщик заново
        public void Refill()
        {
            Console.WriteLine("Refilling the pot...");
            Thread.Sleep(3000);
            Console.WriteLine("Pot refilled.");
        }
    }
}
