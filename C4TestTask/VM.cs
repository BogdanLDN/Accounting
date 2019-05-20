using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;

namespace C4TestTask
{
    class VM : INotifyPropertyChanged
    {   
        private People selectedPeople;
        private ObservableCollection<People> peoples = new ObservableCollection<People>();
        public ObservableCollection<People> Peoples { get; set; }

        public People SelectedPeople
        {          
            get { return selectedPeople; }
            set
            {
                selectedPeople = value;
                OnPropertyChanged("SelectedPeople");
            }
        }
        // команда добавления нового объекта
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      People people = new People();
                      Peoples.Insert(0, people);
                      SelectedPeople = people;
                  }));
            }
        }
        // команда удаления
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      People people = obj as People;
                      if (people != null)
                      {
                          Peoples.Remove(people);
                      }
                  },
                 (obj) => Peoples.Count > 0));
            }
        }
        // команда приход на работу
        private RelayCommand comingCommand;
        public RelayCommand ComingCommand
        {
            get
            {
                return comingCommand ??
                  (comingCommand = new RelayCommand(obj =>
                  {
                      if (selectedPeople!=null)
                      {      
                          selectedPeople.Coming = DateTime.Now.ToString() + " - Время прихода";   
                      }
                      else
                          MessageBox.Show("Выбирете пользователя");
                  }));
            }
        }
        // команда уход с работы
        private RelayCommand leavingCommand;
        public RelayCommand LeavingCommand
        {
            get
            {
                return leavingCommand ??
                  (leavingCommand = new RelayCommand(obj =>
                 {
                     if (selectedPeople != null)
                     {
                         selectedPeople.Leaving = DateTime.Now.ToString() + " - Время ухода";
                     }
                     else
                     MessageBox.Show("Выбирете пользователя");                   
                 }));
            }
        }
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
        


        public VM()
        {
            // наполняем коллекцию значениями

            peoples.Add(new People { Name = "Иван", Position = "Менеджер", DateOfBirth = "20.10.1988"});
            peoples.Add(new People { Name = "Богдан", Position = "Менеджер", DateOfBirth = "27.06.1987" });
            peoples.Add(new People { Name = "Александр", Position = "Охранник", DateOfBirth = "02.03.1995" });
            peoples.Add(new People { Name = "Руслан", Position = "Разработчик", DateOfBirth = "20.11.1992" });
            peoples.Add(new People { Name = "Наталия", Position = "Администратор", DateOfBirth = "01.04.1988" });
            peoples.Add(new People { Name = "Юрий", Position = "Тестировшик", DateOfBirth = "22.08.1992" });
            peoples.Add(new People { Name = "Игорь", Position = "Разработчик", DateOfBirth = "11.12.1991" });
            peoples.Add(new People { Name = "Светлана", Position = "Рекрутер", DateOfBirth = "16.02.1989" });
            peoples.Add(new People { Name = "Анастасия", Position = "Рекрутер", DateOfBirth = "16.02.1989" });
            peoples.Add(new People { Name = "Ирина", Position = "Рекрутер", DateOfBirth = "16.02.1989" });
            peoples.Add(new People { Name = "Светлана", Position = "Рекрутер", DateOfBirth = "16.02.1989" });

            // сортируем колекцию по свойству "Имя"
            ICollectionView _customerView = CollectionViewSource.GetDefaultView(peoples);
            _customerView.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));      
            Peoples = peoples;
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
