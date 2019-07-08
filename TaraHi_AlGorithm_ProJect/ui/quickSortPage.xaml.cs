using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace TaraHi_AlGorithm_ProJect.ui
{
    /// <summary>
    /// Interaction logic for quickSortPage.xaml
    /// </summary>
    public partial class quickSortPage : Page
    {
        public quickSortPage()
        {
            InitializeComponent();
            SortChart.DisableAnimations = true;
            SortChart.Series = new SeriesCollection()
            {
                new ColumnSeries
                {
                    Values=new ChartValues<int>{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20},
                    Fill=Brushes.Red,

                }
            };
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        int[] arrGenerate(int len, bool random)
        {
            int[] arr = new int[len];
            if (random)
            {
                Random r = new Random();
                for (int i = 0; i < len; i++)
                {
                    arr[i] = r.Next(0, len);
                }
            }
            else
            {
                for (int i = 0; i < len; i++)
                {
                    arr[i] = i;
                }
                Array.Reverse(arr);
            }
            return arr;
        }
        void updateChart(int[] s)
        {
            SortChart.Series = new SeriesCollection()
            {
                new ColumnSeries
                {
                    Values=new ChartValues<int>(s),
                    Fill=Brushes.Red
                }
            };
        }
        async Task QuickSort(int low, int high, int[] s, int delay)
        {
            int pivotPoint = 0;
            if (low < high)
            {
                pivotPoint = Partition(low, high,s);
                await QuickSort(low, pivotPoint - 1,s,delay);
                await QuickSort(pivotPoint + 1, high,s,delay);
                updateChart(s);
                await Task.Delay(delay * 1000);
            }
        }

        static int Partition(int low, int high,int[] s)
        {
            int pivotItem = s[low];
            int j = low;
            for (int i = low; i <= high; i++)
            {
                if (s[i] < pivotItem)
                {
                    j++;
                    Exchange(i, j,s);
                }
            }
            Exchange(low, j,s);
            return j;
        }

        static void Exchange(int i, int j,int[] s)
        {
            int temp = s[j];
            s[j] = s[i];
            s[i] = temp;
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            if (arrayLen.Text.Length == 0 || delay.Text.Length == 0 || Convert.ToInt32(arrayLen.Text) < 0 || Convert.ToInt32(delay.Text) < 0)
            {
                ErrorDialog.IsOpen = true;
            }
            else
            {
                int l = Convert.ToInt32(arrayLen.Text);
                QuickSort(0, l - 1, arrGenerate(l, random.IsChecked ?? false), Convert.ToInt32(delay.Text));
            }
        }
    }
}
