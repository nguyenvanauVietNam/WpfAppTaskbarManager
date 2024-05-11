using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WpfAppTaskbarManager
{
    /// <summary>
    /// Interaction logic for TaskbarManager.xaml
    /// </summary>
    public partial class TaskbarManager : Window
    {
        public TaskbarManager()
        {
            InitializeComponent();
            //Hiển thị sub control
            MenuControl.Navigate(new WpfAppTaskbarManager.View.MenuControl());

            TabControl.Navigate(new WpfAppTaskbarManager.View.TabControl());
        }
    }
}
