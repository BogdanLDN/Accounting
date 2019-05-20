using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace C4TestTask
{
    /// <summary>
    /// Модель приложения, наследует интерфейс INotifyPropertyChanged для возможности уведомить модель о изменениях.
    /// </summary>
    public class People : INotifyPropertyChanged
    {
        private string name;
        private string position;
        private string dateOfBirth;
        private string coming;
        private string leaving;


        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Position
        {
            get { return position; }
            set
            {
                position = value;
                OnPropertyChanged("Position");
            }
        }
        public string DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                dateOfBirth = value;
                OnPropertyChanged("GetAge"); //извещаем об изменении даты, для отображения возраста после редактирования даты.               
            }
        }
        public string Coming
        {
            get { return coming; }
            set
            {
                coming = value;
                OnPropertyChanged("Coming");

            }
        }
        public string Leaving
        {
            get { return leaving; }
            set
            {
                leaving = value;
                OnPropertyChanged("Leaving");

            }
        }

        public string GetAge
        {
            get
            {
                if (dateOfBirth == null)
                {
                    dateOfBirth = "01.01.1900";
                }

                return AgeGenerator.ReturnAge(dateOfBirth).ToString();
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