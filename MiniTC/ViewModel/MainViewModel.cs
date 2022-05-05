using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MiniTC.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {

        public MainViewModel()
        {
            DriveList1 = new ObservableCollection<string>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<string> DriveList1 { get; set; }

        private string selectedDrive1;
        public string SelectedDrive1
        {
            get => selectedDrive1;
            set
            {
                selectedDrive1 = value;
                TextPath1 = selectedDrive1;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(selectedDrive1)));
            }
        }

        private string textPath1;
        public string TextPath1
        {
            get => textPath1;
            set
            {
                textPath1 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(textPath1)));
            }
        }

        private ICommand p1cbClick;
        public ICommand P1cbClick => p1cbClick ?? (p1cbClick = new RelayCommand(o => getDrives(), null));

        private ICommand p1cbSelect;
        public ICommand P1cbSelect => p1cbSelect ?? (p1cbSelect = new RelayCommand(o => Console.WriteLine("SELECT"), null));

        private void getDrives()
        {
            Console.WriteLine("CLICK!!!");
            string[] x = Directory.GetLogicalDrives();

            for (int i = 0; i < DriveList1.Count + i; i++)
                DriveList1.RemoveAt(0);
            foreach (string str in x)
            {
                //Console.WriteLine(str);
                DriveList1.Add(str);
            }
        }

    }
}
