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
            FilesList = new ObservableCollection<string>();
        }

        public ObservableCollection<string> DriveList { get; set; }
        public ObservableCollection<string> FilesList { get; set; }

        private string selectedDrive;
        public string SelectedDrive
        {
            get => selectedDrive;
            set
            {
                selectedDrive = value;
                CurrentPath = SelectedDrive;
                OnPropertyChanged(nameof(SelectedDrive));
            }
        }

        private string currentPath;
        public string CurrentPath
        {
            get => currentPath;
            set
            {
                currentPath = value;
                if (currentPath != null)
                {
                    try
                    {
                        string[] directories = Directory.GetDirectories(CurrentPath);
                        string[] files = Directory.GetFiles(CurrentPath);
                        FilesList.Clear();
                        if (CurrentPath.Count(f => f == '\\') != 1)
                        {
                            FilesList.Add("..");
                        }

                        object p = Path.GetDirectoryName(CurrentPath);
                        Console.WriteLine(p);
                        foreach (string d in directories)
                        {
                            FilesList.Add("<D>" + Path.GetFileName(d));
                        }
                        foreach (string f in files)
                        {
                            FilesList.Add(Path.GetFileName(f));
                        }
                    }
                    catch
                    {
                        Console.WriteLine("ERROR");
                    }
                    
                }
                OnPropertyChanged(nameof(CurrentPath));
            }
        }

        private string selectedFile;
        public string SelectedFile
        {
            get => selectedFile;
            set
            {
                selectedFile = value;
                OnPropertyChanged(nameof(SelectedFile));
            }
        }


        private ICommand driveListClick = null;
        public ICommand DriveListClick => driveListClick ?? (driveListClick = new RelayCommand(o => getDrives(), null));

        private ICommand folderChange = null;
        public ICommand FolderChange => folderChange ?? (folderChange = new RelayCommand(o => changePath(), o => SelectedFile != null));


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

        private void changePath()
        {
            // RETURN TO PREVIOUS DIRECTORY
            if (SelectedFile == "..")
            {
                CurrentPath = Path.GetDirectoryName(Path.GetDirectoryName(CurrentPath));
                if (CurrentPath.Last() != '\\')
                {
                    CurrentPath += "\\";
                }
            }
            else
            {
                SelectedFile = SelectedFile.Remove(0, 3);
                CurrentPath += SelectedFile;
                CurrentPath += "\\";
            }
        }

    }
}
