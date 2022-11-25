using BackgroundWorkerTest.BackgroundWorkers;
using BackgroundWorkerTest.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace BackgroundWorkerTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BackgroundWorker worker;
        private MainViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            worker = new BackgroundWorker();
            viewModel = DataContext as MainViewModel;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            worker.CancelAsync();
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            var bkWorker = new CountingUp(worker, viewModel);
            bkWorker.Start();
        }
    }
}
