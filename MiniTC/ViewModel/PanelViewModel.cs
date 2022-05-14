using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MiniTC.ViewModel
{
    class PanelViewModel : BaseViewModel
    {

        public PanelViewModel()
        {
            DriveList = new ObservableCollection<string>();
        }

        public ObservableCollection<string> DriveList { get; set; }

        private string selectedDrive;
        public string SelectedDrive
        {
            get => selectedDrive;
            set
            {
                selectedDrive = value;
                TextPath = selectedDrive;
                OnPropertyChanged(nameof(SelectedDrive));
            }
        }

        private string textPath;
        public string TextPath
        {
            get => textPath;
            set
            {
                textPath = value;
                OnPropertyChanged(nameof(TextPath));
            }
        }

        private ICommand driveListClick = null;
        public ICommand DriveListClick => driveListClick ?? (driveListClick = new RelayCommand(o => Console.WriteLine("CLICK"), o => true));
        //public ICommand DriveListClick => driveListClick ?? (driveListClick = new RelayCommand(o => getDrives(), null));

        private ICommand driveListSelect = null;
        public ICommand DriveListSelect => driveListSelect ?? (driveListSelect = new RelayCommand(o => Console.WriteLine("SELECT"), null));

        private ICommand zaladujTelefony = null;
        public ICommand ZaladujTelefony
        {
            get
            {
                if (zaladujTelefony == null)
                    zaladujTelefony = new RelayCommand(
                        arg => Console.WriteLine("1231231231213"),
                        arg => true
                        );

                return zaladujTelefony;
            }
        }

        private void getDrives()
        {
            Console.WriteLine("CLICK!!!");
            string[] x = Directory.GetLogicalDrives();

            for (int i = 0; i < DriveList.Count + i; i++)
                DriveList.RemoveAt(0);
            foreach (string str in x)
            {
                //Console.WriteLine(str);
                DriveList.Add(str);
            }
        }

    }
}
