using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Sort
    {
        public void HeapSort(int[] array)
        {
            int n = array.Length;

            // Построение кучи (перегруппировка массива)
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify2(array, n, i);

            // Извлечение элементов из кучи по одному
            for (int i = n - 1; i >= 0; i--)
            {
                // Перемещение текущего корня в конец
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                // Вызов процедуры Heapify на уменьшенной куче
                Heapify2(array, i, 0);
            }
        }

        // Процедура пирамидальной перегруппировки поддерева с корнем i
        public void Heapify2(int[] array, int n, int i)
        {

            int largest = i; // Инициализация наибольшего элемента как корня
            int left = 2 * i + 1; // Левый потомок узла i
            int right = 2 * i + 2; // Правый потомок узла i

            // Если левый потомок больше корня
            if (left < n && array[left] > array[largest])
                largest = left;

            // Если правый потомок больше наибольшего элемента на данный момент
            if (right < n && array[right] > array[largest])
                largest = right;

            // Если наибольший элемент не является корнем
            if (largest != i)
            {
                int swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;

                // Рекурсивно вызываем процедуру Heapify для поддерева
                Heapify2(array, n, largest);
            }
        }
    }
}
