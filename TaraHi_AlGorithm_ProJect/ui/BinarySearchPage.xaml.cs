using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace TaraHi_AlGorithm_ProJect.ui
{
    /// <summary>
    /// Interaction logic for BinarySearchPage.xaml
    /// </summary>
    public partial class BinarySearchPage : Page
    {
        public BinarySearchPage()
        {
            InitializeComponent();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Search_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (item.Text.Length == 0 || arrayLen.Text.Length == 0||delay.Text.Length==0||  Convert.ToInt32(arrayLen.Text)<0 || Convert.ToInt32(delay.Text) < 0)
            {
                ErrorDialog.IsOpen = true;
            }
            else
            {
                int l = Convert.ToInt32(arrayLen.Text);
                int x = Convert.ToInt32(item.Text);
                BinarySearch(0, l - 1, x, arrGenerate(l, random.IsChecked ?? false),Convert.ToInt32(delay.Text));
            }
        }
        int[] arrGenerate(int len,bool random)
        {
            int[] arr = new int[len];
            if (random)
            {
                Random r = new Random();
                for (int i = 0; i < len; i++)
                {
                    arr[i] = r.Next(0,len);
                }
                Array.Sort(arr);
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
        void updateStackPanel(int low, int high, int[] arr,int x)
        {
            arrStackPanel.Children.Clear();
            for (int i = low; i <= high; i++)
            {
                /*
                 * mid=yellow
                 * other=red
                 */
                arrStackPanel.Children.Add(new  Border { Height = 70, Width = 70, BorderBrush=arr[i]==x?Brushes.Green:i==(low+high)/2?Brushes.Blue:Brushes.Red, BorderThickness=new Thickness(2),Child=new Label {Content=arr[i].ToString(),VerticalAlignment=VerticalAlignment.Center,HorizontalAlignment=HorizontalAlignment.Center,Foreground=Brushes.White,FontSize=16},CornerRadius=new CornerRadius(50)});
            }
        }

        async Task<int> BinarySearch(int low, int high, int x, int[] s,int delay)
        {
            updateStackPanel(low, high, s, x);
            await Task.Delay(delay*1000);
            if (low > high)
            {
                return 0;
            }
            else
            {
                int mid = (low + high) / 2;
                if (s[mid] == x)
                    return mid;

                else if (x < s[mid])
                    await BinarySearch(low, mid - 1, x, s,delay);

                else if (x > s[mid])
                     await BinarySearch(mid + 1, high, x, s,delay);
            }
            return -1;
        }
    }
}
