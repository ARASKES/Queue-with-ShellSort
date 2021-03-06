using System;

public class Queue
{
  int[] elements; //  Массив в качестве "ядра" очереди

  public Queue()
  {
    elements = new int[] { };
  }

  public int Count
  {
    get
	{
      return elements.Length;
    }
  }

  public bool isEmpty
  {
    get
	{
      return elements.Length == 0;
    }
  }

  public void Enqueue(int value)
  {
    int[] cacheArray = new int[elements.Length + 1];

    for (int i = 0; i < elements.Length; i++)
    {
      cacheArray[i] = elements[i];
    }
    cacheArray[elements.Length] = value;

    elements = cacheArray;
  }

  public int Dequeue()
  {
    int elementToDelete = elements[0];

    int[] cacheArray = new int[elements.Length - 1];

    for (int i = 0; i < cacheArray.Length; i++)
    {
      cacheArray[i] = elements[i + 1];
    }

    elements = cacheArray;

    return elementToDelete;
  }

  public int Peek()
  {
    return elements[0];
  }

  private int Get(int index)
  {
    int elementNeeded;

    for (int i = 0; i < index; i++)
    {
      Enqueue(Dequeue());
    }

    elementNeeded = Peek();

    for (int i = index; i < elements.Length; i++)
    {
      Enqueue(Dequeue());
    }

    return elementNeeded;
  }

  private void Set(int index, int value)
  {
    for (int i = 0; i < index; i++)
    {
      Enqueue(Dequeue());
    }

    elements[0] = value;

    for (int i = index; i < elements.Length; i++)
    {
      Enqueue(Dequeue());
    }
  }

  public void ShellSort()
  {
    //  Регулировка шага (стандартным методом Шелла, начиная с половины размера)
    for (int step = elements.Length / 2; step > 0; step /= 2)
    {
      //  Перебор элементов, начиная с элемента, индекс которого равен шагу
      for (int i = step; i < elements.Length; i++)
      {
        //  Перестановка элементов по возрастанию внутри участка между j-тым и i-тым элементами, до элемента с индексом i
        for (int j = i - step; j >= 0 && Get(j) < Get(j + step); j -= step)
        {
          int temp = Get(j);
          Set(j, Get(j + step));
          Set(j + step, temp);
        }
      }
    }
  }

  public void PrintQueue()
  {
    if (elements.Length != 0)
    {
      foreach (int element in elements)
      {
        Console.Write($"{element} ");
      }
      Console.WriteLine();
    }
  }
}
