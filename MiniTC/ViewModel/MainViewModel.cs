﻿using MiniTC.View;
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
        public ICommand Copy => copy ?? (copy = new RelayCommand(o => copyFile(), o => PanelLeft.SelectedFile != null && PanelRight.CurrentPath != null));

        private void copyFile()
        {
            Console.WriteLine("COPYYYYYY!");

            Console.WriteLine(PanelLeft.CurrentPath);
            Console.WriteLine(PanelLeft.SelectedFile);
            string pathSource = PanelLeft.CurrentPath + PanelLeft.SelectedFile;
            string pathDestination = PanelRight.CurrentPath + PanelLeft.SelectedFile;

            try
            {
                File.Copy(@pathSource, @pathDestination);
            }
            catch (IOException)
            {
                Console.WriteLine("Plik już istnieje!");
                PanelLeft.ErrorDescription = "Error - Plik o takiej nazwie juz istnieje!";
            }

            PanelRight.CurrentPath = PanelRight.CurrentPath;

        }

    }
}
