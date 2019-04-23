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
using System.Windows.Shapes;

namespace SavingSettigns
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private UsersDBEntities1 udb = new UsersDBEntities1();
        public LoginWindow()
        {
            InitializeComponent();
            Logger.WriteToFile("LoginWindow: Login window initialized");
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Cursor prev = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;
            Logger.WriteToFile("LoginWindow: Register button clicked");
            if (tbUsername.Text == null)
            {
                Logger.WriteToFile("LoginWindow: Registration failed: empty username");
                MessageBox.Show("Username can not be empty!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (tbPassword.Password == null)
            {
                Logger.WriteToFile("LoginWindow: Registration failed: empty password");
                MessageBox.Show("Password can not be empty!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    User newUser = new User()
                    {
                        Username = tbUsername.Text,
                        Password = tbPassword.Password
                    };
                    udb.Users.Add(newUser);
                    
                    udb.SaveChanges();                    
                    MessageBox.Show("Adding new user successful!", "Database", MessageBoxButton.OK);
                    Logger.WriteToFile("LoginWindow: Registration successful");
                }
                catch(Exception ex)
                {
                    Logger.WriteToFile("LoginWindow: Registration failed");
                    MessageBox.Show("Adding new user failed: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            Mouse.OverrideCursor = prev;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Cursor prev = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;
            Logger.WriteToFile("LoginWindow: Login button clicked");
            if (tbUsername.Text == null)
            {
                Logger.WriteToFile("LoginWindow: Login failed: empty username");
                MessageBox.Show("Username can not be empty!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (tbPassword.Password == null)
            {
                Logger.WriteToFile("LoginWindow: Login failed: empty password");
                MessageBox.Show("Password can not be empty!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    User user = udb.Users.FirstOrDefault(p => p.Username == tbUsername.Text && p.Password == tbPassword.Password);
                    if (user != null)
                    {
                        Program.user = user;
                        Logger.WriteToFile("LoginWindow: Login successful");
                       
                        this.Close();
                    }
                    else
                    {
                        Logger.WriteToFile("LoginWindow: Login failed");
                        MessageBox.Show("Login failed! ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteToFile("LoginWindow: Login failed");
                    MessageBox.Show("Login failed: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                 }
                Mouse.OverrideCursor=prev;
            }
        }
    }
}
