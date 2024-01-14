using Lucene.Net.Search;
using Lucene.Net.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
        public partial class FormMain : Form
    {
        private object assumeDiagram;

        public FormMain()
        {
            InitializeComponent();
        }
        public void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public async void sort_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(array.Text) && String.IsNullOrWhiteSpace(number.Text))
            {
                MessageBox.Show("Числа не введены");
                return;
            }
            if (!string.IsNullOrWhiteSpace(array.Text) && !string.IsNullOrWhiteSpace(number.Text))
            {
                MessageBox.Show("Выберете один из способов ввода чисел");
                return;
            }
            if (string.IsNullOrWhiteSpace(array.Text) && !string.IsNullOrWhiteSpace(number.Text))
            {
                string input = number.Text;
                if (!int.TryParse(input, out int parsedNumber))
                {
                    MessageBox.Show("Введены некорректные символы.");
                    return;
                }

                int length = parsedNumber;
                Random rand = new Random();
                int[] numberArray = new int[length];
                for (int i = 0; i < length; i++)
                {
                    numberArray[i] = rand.Next(-1000, 1001);
                }
                array.Text = string.Join(" ", numberArray);
                // Сортировка массива чисел методом пирамидальной сортировки
                await HeapSortAsync(numberArray);


                // Создание строки для хранения чисел из массива
                string output = "";

                // Обход отсортированного массива и добавление каждого числа в строку
                for (int i = 0; i < numberArray.Length; i++)
                {
                    output += numberArray[i].ToString() + " ";
                }

                // Вывод строки во второй TextBox
                result.Text = output;

            }


            else
            {

                string inputText = array.Text;
                string[] numbers = inputText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int[] numberArray = new int[numbers.Length];

                for (int i = 0; i < numbers.Length; i++)
                {
                    if (!int.TryParse(numbers[i], out int parsedNumber))
                    {
                        MessageBox.Show("Введены некорректные символы.");
                        return;
                    }

                    numberArray[i] = parsedNumber;
                }


                // Сортировка массива чисел методом пирамидальной сортировки
                await HeapSortAsync(numberArray);


                // Создание строки для хранения чисел из массива
                string output = "";

                // Обход отсортированного массива и добавление каждого числа в строку
                for (int i = 0; i < numberArray.Length; i++)
                {
                    output += numberArray[i].ToString() + " ";
                }

                // Вывод строки во второй TextBox
                result.Text = output;
            }
        }

        public async Task HeapSortAsync(int[] array)
        {
            int n = array.Length;

            // Построение кучи (перегруппировка массива)
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(array, n, i);

            // Извлечение элементов из кучи по одному
            for (int i = n - 1; i >= 0; i--)
            {
                // Перемещение текущего корня в конец
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                await DrawChartAsync(array);

                // Вызов процедуры Heapify на уменьшенной куче
                Heapify(array, i, 0);
            }
        }

        // Процедура пирамидальной перегруппировки поддерева с корнем i
        public void Heapify(int[] array, int n, int i)
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
                Heapify(array, n, largest);
            }
        }
        public async Task DrawChartAsync(int[] array)
        {
            diogramma.Series[0].Points.Clear(); // Очистка предыдущего графика
            diogramma.Series["Series1"].IsVisibleInLegend = false;

            for (int i = 0; i < array.Length; i++)
            {
                diogramma.Series[0].Points.AddXY(i, array[i]); // Добавление столбца гистограммы
            }

            await Task.Delay(500); // Пауза в 0.5 секунды
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var dialogResultMainForm1 = new LoginForm().ShowDialog();
            if (dialogResultMainForm1 == DialogResult.Cancel)
            {
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|BMP Image|*.bmp";
            //saveFileDialog.Title = "Сохранить изображение диаграммы";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Chart chart = diogramma;

                // Сохранение изображения диаграммы
                chart.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
            }

        }

    }
    
}
    





