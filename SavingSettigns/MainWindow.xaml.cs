using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace SavingSettigns
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DataSet AllData;
        public MainWindow()
        {
            InitializeComponent();
            tbUser.Text ="Welcome "+ Program.user.Username+"!";
            Logger.WriteToFile("MainWindow: Main window initialized");
        }

        private void SaveMenu_Click(object sender, RoutedEventArgs e)
        {
            Cursor prev = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;
            Logger.WriteToFile("MainWindow: Save settings button clicked");
            Program.settings.SaveSettings();
            Mouse.OverrideCursor = prev;
        }

        private void radiosButton_Checked(object sender, RoutedEventArgs e)
        {
            Logger.WriteToFile("MainWindow: "+(sender as RadioButton).Name + " checked");           
        }
       
        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {            
            Logger.WriteToFile("MainWindow: "+(sender as CheckBox).Name + " checked");
        }

       private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Logger.WriteToFile("MainWindow: "+(sender as CheckBox).Name + " unchecked");
        }

       
       private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
       {
           Logger.WriteToFile("MainWindow: Combo box selection chaged to " + ((sender as ComboBox).SelectedItem as ComboBoxItem).Content);
       }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Logger.WriteToFile("MainWindow: Logout button clicked");
            Program.reinit = 1;
            this.Close();
        }
    }
}
