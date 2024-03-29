﻿using System;
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
using TaraHi_AlGorithm_ProJect.ui;

namespace TaraHi_AlGorithm_ProJect
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void binarysearchbtn_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BinarySearchPage page = new BinarySearchPage();
            MainFrame.Navigate(page);
        }

        private void mergeSortbtn_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MergeSortPage page = new MergeSortPage();
            MainFrame.Navigate(page);
        }

        private void quickSortbtn_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            quickSortPage page = new quickSortPage();
            MainFrame.Navigate(page);
        }
    }
}
