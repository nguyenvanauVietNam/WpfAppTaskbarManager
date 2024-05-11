using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppTaskbarManager.View
{
    /// <summary>
    /// Interaction logic for MenuControl.xaml
    /// </summary>
    public partial class MenuControl : Page
    {
        public MenuControl()
        {
            InitializeComponent();
        }

        private void btnFile_Click(object sender, RoutedEventArgs e)
        {
            // Hiển thị menu khi di chuột vào nút
            ToggleButton? toggleButton = sender as ToggleButton;
            if (toggleButton != null && toggleButton.ContextMenu != null)
            {
                toggleButton.ContextMenu.IsEnabled = true;
                toggleButton.ContextMenu.PlacementTarget = toggleButton;
                toggleButton.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
                toggleButton.ContextMenu.IsOpen = true;
            }
        }
        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Tắt ứng dụng khi người dùng nhấn vào Exit
            Application.Current.Shutdown();
        }
        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            // Hiển thị menu khi di chuột vào nút
            ToggleButton? toggleButton = sender as ToggleButton;
            if (toggleButton != null && toggleButton.ContextMenu != null)
            {
                toggleButton.ContextMenu.IsEnabled = true;
                toggleButton.ContextMenu.PlacementTarget = toggleButton;
                toggleButton.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
                toggleButton.ContextMenu.IsOpen = true;
            }
        }
    }
}
