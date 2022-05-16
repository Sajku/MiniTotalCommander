using MiniTC.Model;
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
            Model = new PanelModel();
        }

        public PanelModel Model = null;
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
                Model.CurrentPath = currentPath;
                
                List<string> files = Model.UpdateFiles();
                currentPath = Model.CurrentPath;
                if (files.Count() > 1)
                {
                    FilesList.Clear();
                    foreach (string f in files)
                        FilesList.Add(f);
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
                ErrorDescription = "";
                OnPropertyChanged(nameof(SelectedFile));
            }
        }

        private string errorDescription;
        public string ErrorDescription
        {
            get => errorDescription;
            set
            {
                errorDescription = value;
                OnPropertyChanged(nameof(ErrorDescription));
            }
        }


        private ICommand driveListClick = null;
        public ICommand DriveListClick => driveListClick ?? (driveListClick = new RelayCommand(o => {
            List<string> drives = Model.getDrives();
            DriveList.Clear();
            foreach (string d in drives)
                DriveList.Add(d);
            }, null));

        private ICommand folderChange = null;
        public ICommand FolderChange => folderChange ?? (folderChange = new RelayCommand(o => CurrentPath = Model.changePath(SelectedFile), o => SelectedFile != null));

    }
}
