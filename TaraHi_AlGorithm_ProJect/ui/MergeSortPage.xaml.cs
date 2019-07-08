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
using LiveCharts;
using LiveCharts.Wpf;

namespace TaraHi_AlGorithm_ProJect.ui
{
    /// <summary>
    /// Interaction logic for MergeSortPage.xaml
    /// </summary>
    public partial class MergeSortPage : Page
    {
        public MergeSortPage()
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
        void MergeSort(int low, int high,int[]s,int delay)
        {
            if (low < high)
            {

                int mid = (low + high) / 2;

                MergeSort(low, mid,s,delay);
                MergeSort(mid + 1, high,s,delay);

                Merge(low, mid, high,s,delay);
            }
        }

        async void Merge(int low, int mid, int high, int[] s,int delay)
        {
            int i = low, j = mid + 1, k = 0;
            int[] arr = new int[high - low + 1];
            while (i <= mid && j <= high)
            {
                if (s[i] < s[j])
                {
                    arr[k] = s[i];
                    i++;
                }
                else if (s[j] < s[i])
                {
                    arr[k] = s[j];
                    j++;
                }
                k++;
                updateChart(s);
                await Task.Delay(delay * 100);
            }
            if (i > mid)
            {
                while (j <= high)
                {
                    arr[k] = s[j];
                    j++;
                    k++;
                    updateChart(s);
                    await Task.Delay(delay * 100);
                }
            }
            else if (j > high)
            {
                while (i <= mid)
                {
                    arr[k] = s[i];
                    i++;
                    k++;
                    updateChart(s);
                    await Task.Delay(delay * 100);
                }
            }
            int c = 0;
            for (int o = low; o <= high; o++)
            {
                s[o] = arr[c++];
                updateChart(s);
                await Task.Delay(delay * 100);
            }
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
            }
            return arr;
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
                MergeSort(0,l-1,arrGenerate(l, random.IsChecked??false),Convert.ToInt32(delay.Text));
            }
        }
    }
}
