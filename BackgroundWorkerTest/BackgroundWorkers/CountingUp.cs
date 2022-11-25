using BackgroundWorkerTest.ViewModel;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Controls;

namespace BackgroundWorkerTest.BackgroundWorkers
{
    internal class CountingUp
    {
        private readonly BackgroundWorker worker;
        private readonly MainViewModel viewModel;

        public CountingUp(BackgroundWorker workerInstance, MainViewModel viewModelIsntance)
        {
            worker = workerInstance;
            viewModel = viewModelIsntance;
            worker.DoWork += BeginCounting;
            worker.RunWorkerCompleted += EndCounting;
            worker.ProgressChanged += UpdateProgress;
            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;
        }

        public void Start()
        {
            worker.RunWorkerAsync();
        }

        private void BeginCounting(object s, DoWorkEventArgs args)
        {
            viewModel.EnableStart = false;
            viewModel.EnableCancel = true;
            viewModel.LabelText = "Counting...";
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.1));
                worker.ReportProgress(i+1);
                if (worker.CancellationPending)
                {
                    args.Cancel = true;
                    return;
                }
            }

            args.Result = "Finished";
        }

        private void UpdateProgress(object s, ProgressChangedEventArgs args)
        {
            viewModel.Progress = args.ProgressPercentage;
        }

        private void EndCounting(object s, RunWorkerCompletedEventArgs args) 
        {
            viewModel.EnableStart = true;
            viewModel.EnableCancel = false;

            if (args.Cancelled)
            {
                viewModel.LabelText = "Cancelled";
            }
            else
            {
                viewModel.LabelText = args.Result as string;
            }

            worker.DoWork -= BeginCounting;
            worker.RunWorkerCompleted -= EndCounting;
            worker.ProgressChanged -= UpdateProgress;
        }
    }
}
