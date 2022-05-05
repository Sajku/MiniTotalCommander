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
            get { return selectedDrive1; }
            set { selectedDrive1 = value; }
        }

        private ICommand p1cbClick;
        public ICommand P1cbClick => p1cbClick ?? (p1cbClick = new RelayCommand(o => clickF(), null));

        private ICommand p1cbSelect;
        public ICommand P1cbSelect => p1cbSelect ?? (p1cbSelect = new RelayCommand(o => Console.WriteLine("SELECT!!!"), null));


        private void clickF()
        {
            Console.WriteLine("CLICK!!!");
            string[] x = Directory.GetLogicalDrives();

            for (int i = 0; i < DriveList1.Count; i++)
            {
                DriveList1.RemoveAt(0);
            }
            foreach (string str in x)
            {
                Console.WriteLine(str);
                DriveList1.Add(str);
            }

        }
    }
}
