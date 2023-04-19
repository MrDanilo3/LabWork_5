using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Conteiner
{
    class Bee
    {
        private readonly int _id;
        private readonly HoneyPot _pot;

        public Bee(int id, HoneyPot pot)
        {
            _id = id;
            _pot = pot;
        }

        public void Start()
        {
            //Нескінченний цикл, який забезпечує постійну роботу бджоли
            while (true)
            {
                Thread.Sleep(1000);
                //Додавання нової порції
                _pot.AddPortion(_id);
                //Якщо горщик повний, розбудити медведя
                if (_pot.IsFull())
                {
                    Console.WriteLine("Bee {0} filled the pot", _id);
                    _pot.WakeUpBear();
                }
            }
        }
    }
    
}
