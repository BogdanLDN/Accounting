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
using System.Windows.Shapes;

namespace C4TestTask
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

        }

        Users users = new Users("Admin", "20101988");
        MainWindow window = new MainWindow();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //define local variables from the user inputs 
            string user = txtbLog.Text;
            string pass = passBox.Password;
            //check if eligible to be logged in 
            if (users.IsLoggedIn(user, pass))
            {

                this.Close();
                window.Show();

            }
            else
            {
                //show default login error message 
                MessageBox.Show("ошибка авторизации!");
                txtbLog.Text = null; // очищаем поле логин
                passBox.Password = null; // очищаем поле пароль
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
