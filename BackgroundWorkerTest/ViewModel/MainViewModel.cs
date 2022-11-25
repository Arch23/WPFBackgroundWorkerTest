using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BackgroundWorkerTest.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private bool enableCancel = false;
        public bool EnableCancel {
            get => enableCancel;
            set { 
                enableCancel = value;
                OnPropertyChanged();
            } 
        }

        private bool enableStart = true;
        public bool EnableStart
        {
            get => enableStart;
            set
            {
                enableStart = value;
                OnPropertyChanged();
            }
        }

        private int progress = 0;
        public int Progress
        {
            get => progress;
            set
            {
                progress = value;
                OnPropertyChanged();
            }
        }

        private string labelText = "Press the button to start!";
        public string LabelText
        {
            get => labelText;
            set
            {
                labelText = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
