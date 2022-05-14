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

        public PanelTC PanelLeft { get; set; }
        public PanelTC PanelRight { get; set; }

        public MainViewModel()
        {
            PanelLeft = new PanelTC();
            PanelRight = new PanelTC();
        }

        private ICommand copy;
        public ICommand Copy => copy ?? (copy = new RelayCommand(o => Console.WriteLine("COPYYYYYYYYY!"), null));

    }
}
