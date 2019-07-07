using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

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
        int BinarySearch(int low, int high, int x, int[] s)
        {
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
                    BinarySearch(low, mid - 1, x, s);

                else if (x > s[mid])
                    BinarySearch(mid + 1, high, x, s);
            }
            return -1;
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
