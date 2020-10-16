using System;
using System.Diagnostics;

namespace QueueShellAlgorythm
{
  class Program
  {
    static void Main(string[] args)
    {
      Random random = new Random(); //  Создадим объект класса Random
      Stopwatch stopwatch = new Stopwatch();  //  Создадим объект класса Stopwatch для замера времени

      Queue queue;  //  Создадим экземпляр очереди

      int[] quantitySelection = {
        500, 1000, 1500, 2000, 2500, 3000, 3500, 4000, 4500, 5000, 20000, 50000, 75000, 100000, 250000
      };  //  Создадим выборку размеров очереди для каждого из экспериментов

      long ops = 0; //  Создадим переменную для записи количества операций

      for (int sessionNumber = 1; sessionNumber <= quantitySelection.Length; sessionNumber++) //  Производим 10 экспериментов
      {
        queue = new Queue();  //  Создаем очередь, имеющую размер из выборки


        for (int i = 0; i < quantitySelection[sessionNumber - 1]; i++)
        {
          queue.Enqueue(random.Next(1, 1000));  //  Заполняем очередь случайными числами от 1 до 1000
        }

        stopwatch.Start();
        queue.ShellSort();  //  Вызываем метод сортировки очереди
        stopwatch.Stop();
        Console.WriteLine($"Sorting session number: {sessionNumber}\tNumbers sorted: {quantitySelection[sessionNumber - 1]}\tSorting time: {stopwatch.ElapsedMilliseconds} ms\tNumber of operations: {ops}\n");
        stopwatch.Reset();
        //Console.WriteLine();
        //queue.PrintQueue();
      }

      Console.ReadKey();
    }
  }
}