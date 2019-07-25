using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace C4TestTask.ViewModels
{
    public class LoginWindowVM : INotifyPropertyChanged
    {
        Users users = new Users("admin", "admin");
        MainWindow window = new MainWindow();
        public string Pass { get; set; }
        public string Log { get; set; }

        // команда закрыть приложение
        private RelayCommand closeWindowCommand;
        public RelayCommand CloseWindowCommand
        {
            get
            {
                return closeWindowCommand ??
                  (closeWindowCommand = new RelayCommand(obj =>
                  {
                      Application.Current.Shutdown();
                  }));
            }
        }

        private RelayCommand enterApp;
        public RelayCommand EnterApp
        {
            get
            {
                return enterApp ??
                  (enterApp = new RelayCommand(obj =>
                  {
                      //define local variables from the user inputs 
                      string user = Log;
                      string pass = Pass;
                      //check if eligible to be logged in 
                      if (users.IsLoggedIn(user, pass))
                      {
                          window.Show();

                          App.Current.MainWindow.Close();
                          App.Current.MainWindow = window;
                      }
                      else
                      {

                          MessageBox.Show("ошибка авторизации!");
                          Log = null; // очищаем поле логин
                          Pass = null; // очищаем поле пароль
                          OnPropertyChanged(Log);
                          OnPropertyChanged(Pass);
                      }
                  }));
            }
        }    
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

       
    }
}
