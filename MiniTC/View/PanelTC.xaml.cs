using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MiniTC.View
{
    /// <summary>
    /// Logika interakcji dla klasy PanelTC.xaml
    /// </summary>
    public partial class PanelTC : UserControl
    {
        public PanelTC()
        {
            InitializeComponent();
        }

        // ----------------------------------------------------------------------------
        // FIRST ELEMENT
        public static readonly DependencyProperty DriveListProperty =
            DependencyProperty.Register(
                nameof(DriveList),
                typeof(ObservableCollection<string>),
                typeof(PanelTC));

        public ObservableCollection<string> DriveList
        {
            get { return (ObservableCollection<string>)GetValue(DriveListProperty); }
            set { SetValue(DriveListProperty, value); }
        }

        public static readonly DependencyProperty SelectedDriveProperty =
            DependencyProperty.Register(
                nameof(SelectedDrive),
                typeof(string),
                typeof(PanelTC));

        public string SelectedDrive
        {
            get { return (string)GetValue(SelectedDriveProperty); }
            set { SetValue(SelectedDriveProperty, value); }
        }

        // ----------------------------------------------------------------------------
        // SECOND ELEMENT
        public static readonly DependencyProperty TextPathProperty =
            DependencyProperty.Register(
                nameof(TextPath),
                typeof(string),
                typeof(PanelTC));

        public string TextPath
        {
            get { return (string)GetValue(TextPathProperty); }
            set { SetValue(TextPathProperty, value); }
        }

        // ----------------------------------------------------------------------------
        // THIRD ELEMENT
        public static readonly DependencyProperty FilesListProperty =
            DependencyProperty.Register(
                nameof(FilesList),
                typeof(ObservableCollection<string>),
                typeof(PanelTC));

        public ObservableCollection<string> FilesList
        {
            get { return (ObservableCollection<string>)GetValue(FilesListProperty); }
            set { SetValue(FilesListProperty, value); }
        }






    }
}
