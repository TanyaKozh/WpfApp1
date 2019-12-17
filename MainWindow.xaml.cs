using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using System.IO;
using Microsoft.Win32;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ArrayList myAL;
        int A = -100, B = 100;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Gen(ArrayList myAL, int itemCount, int x, int y)
        {
            Random rnd1 = new Random();
            int number;
            lbMain.Items.Clear();
            lbMain.Items.Add("Исходный массив");
            for (int index = 1; index <= itemCount; index++)
            {
                number = rnd1.Next(x, y);
                myAL.Add(number);
                lbMain.Items.Add(number);
            }
        }
        private void error()
        {
            tBox_countElem.BorderBrush = Brushes.Red;
            MessageBox.Show("Входная строка имела неверный тип данных", "ой...", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Btn_task2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                myAL = new ArrayList();
                int itemCount = Convert.ToInt32(tBox_countElem.Text);
                Gen(myAL, itemCount, A, B);
                myAL.Sort();
                lbMain.Items.Add("Отсортированный массив");
                foreach (int elem in myAL)
                {
                    lbMain.Items.Add(elem);
                }
                tBox_countElem.BorderBrush = Brushes.Gray;
            }
            catch
            {
                error();
            }
        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog myDialog = new SaveFileDialog();
            myDialog.Filter = "Текст(*.TXT)|*.TXT" + "|Все файлы (*.*)|*.* ";

            if (myDialog.ShowDialog() == true)
            {
                string filename = myDialog.FileName;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename, false))
                {
                    foreach (Object item in lbMain.Items)
                    {
                        file.WriteLine(item);
                    }
                }
            }
        }

        private void Btn_about_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
        }

        private void Btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Btn_task3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                myAL = new ArrayList();
                int itemCount = Convert.ToInt32(tBox_countElem.Text);
                Gen(myAL, itemCount, A, B);
                int m = 0;
                for (int index = 1; index < itemCount - 1; index++)
                {
                    if (((int)myAL[index - 1] < (int)myAL[index]) && ((int)myAL[index] > (int)myAL[index + 1]))
                        m++;
                }
                tBox_countElem.BorderBrush = Brushes.Gray;
                MessageBox.Show("Колличество элементов массива больше своих «соседей» = " + Convert.ToString(m), "Результат");
            }
            catch
            {
                error();
            }
        }

        private void Btn_task4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                myAL = new ArrayList();
                int itemCount = Convert.ToInt32(tBox_countElem.Text);
                Gen(myAL, itemCount, A, B);
                bool p = false;
                int index = 0;
                while (p == false)
                {
                    if ((int)myAL[index] > 25)
                        p = true;
                    index++;
                }
                tBox_countElem.BorderBrush = Brushes.Gray;
                if (p == true)
                    MessageBox.Show("Номер первого элемента, большего 25 = " + index, "Результат");
                else MessageBox.Show("Все элементы массива меньше 25");
            }
            catch
            {
                error();
            }
        }

        private void Btn_task5_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                myAL = new ArrayList();
                int itemCount = Convert.ToInt32(tBox_countElem.Text);
                int sum = 0;
                Gen(myAL, itemCount, A, B);
                for (int index = 0; index < itemCount; index++)
                {
                    if ((int)myAL[index] > (int)myAL[1])
                        sum += (int)myAL[index];
                }
                tBox_countElem.BorderBrush = Brushes.Gray;
                MessageBox.Show("Сумма элементов, больше " + myAL[1] + " = " + sum, "Результат");
            }
            catch
            {
                error();
            }
        }

        private void Btn_task6_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Window2 window2 = new Window2();
                window2.Owner = this;
                window2.ShowDialog();
                double K;
                K = Convert.ToDouble(window2.tb_K.Text);
                myAL = new ArrayList();
                int itemCount = Convert.ToInt32(tBox_countElem.Text);
                Gen(myAL, itemCount, A, B);
                bool p = false;
                int index = 0;
                while (p == false)
                {
                    if ((int)myAL[index] > K)
                        p = true;
                    index++;
                }
                tBox_countElem.BorderBrush = Brushes.Gray;
                if (p == true)
                    MessageBox.Show("Номер первого элемента, больше " + K + " = " + index, "Результат");
                else MessageBox.Show("Все элементы массива меньше " + K);
            }
            catch
            {
                error();
            }
        }

        private void Btn_task7_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Window2 window2 = new Window2();
                window2.Owner = this;
                window2.ShowDialog();
                int K;
                K = Convert.ToInt32(window2.tb_K.Text);
                myAL = new ArrayList();
                int itemCount = Convert.ToInt32(tBox_countElem.Text);
                if (K > itemCount)
                {
                    MessageBox.Show("K не может быть больше введенного количесnва элементов");
                }
                else
                {
                    Gen(myAL, itemCount, A, B);
                    int sum = 0;
                    bool p = false;
                    for (int index = 0; index < itemCount; index++)
                    {
                        if ((int)myAL[index] > (int)myAL[K - 1])
                        {
                            sum += (int)myAL[index];
                            p = true;
                        }
                    }
                    tBox_countElem.BorderBrush = Brushes.Gray;
                    if (p == true)
                        MessageBox.Show("Сумма элементов, больше чем " + myAL[K - 1] + " = " + sum, "Результат");
                    else MessageBox.Show("Все элементы массива меньше " + myAL[K - 1]);
                }
            }
            catch
            {
                error();
            }
        }

        private void Btn_task1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                myAL = new ArrayList();
                int itemCount = Convert.ToInt32(tBox_countElem.Text);
                Gen(myAL, itemCount, A, B);
                tBox_countElem.BorderBrush = Brushes.Gray;
            }
            catch
            {
                error();
            }
        }
    }
}
