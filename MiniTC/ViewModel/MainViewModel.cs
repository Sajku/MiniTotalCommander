﻿using MiniTC.Model;
using MiniTC.View;
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
    class MainViewModel : BaseViewModel
    {

        public PanelViewModel PanelLeft { get; set; }
        public PanelViewModel PanelRight { get; set; }

        public MainViewModel()
        {
            PanelLeft = new PanelViewModel();
            PanelRight = new PanelViewModel();
            PanelLeft.CurrentPath = null;
            PanelRight.CurrentPath = null;
        }


        private ICommand copy;
        public ICommand Copy => copy ?? (copy = new RelayCommand(
            o =>
            {
                string pathSource = PanelLeft.CurrentPath + PanelLeft.SelectedFile;
                string pathDestination = PanelRight.CurrentPath + PanelLeft.SelectedFile;
                PanelLeft.ErrorDescription = Copying.CopyFile(pathSource, pathDestination);
                PanelRight.CurrentPath = PanelRight.CurrentPath;
            },
            o => PanelLeft.SelectedFile != null && PanelRight.CurrentPath != null));

    }
}
