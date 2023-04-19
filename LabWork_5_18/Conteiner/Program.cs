using Conteiner;
using System;
using System.Threading;
class Program
{

    static void Main(string[] args)
    {
        // Створюємо медовий горщик з максимальною кількістю порцій рівною 5
        HoneyPot pot = new HoneyPot(5);
        // Створюємо ведмедя та передаємо йому медовий горщик
        Bear bear = new Bear(pot);
        // Створюємо список бджіл
        List<Bee> bees = new List<Bee>();
        // Оголошуємо змінну потоку
        Thread t = null;

        // Створюємо  бджіл та запускаємо кожну з них у власному потоці
        for (int i = 0; i < 10; i++)
        {
            Bee bee = new Bee(i, pot);
            bees.Add(bee);
            t = new Thread(new ThreadStart(bee.Start));
            t.Start();
        }

        // Запускаємо ведмедя у окремому потоці
        Thread bearThread = new Thread(new ThreadStart(bear.Start));
        bearThread.Start();

        // Очікуємо завершення всіх потоків бджіл
        foreach (Bee bee in bees)
        {
            t.Join(5000);
        }

        bearThread.Join(5000);

        Console.WriteLine("All threads finished.");
    }
}

