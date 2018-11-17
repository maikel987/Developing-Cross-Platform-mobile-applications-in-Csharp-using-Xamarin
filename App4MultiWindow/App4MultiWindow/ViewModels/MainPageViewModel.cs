using App.Shared;
using App4MultiWindow.Models;
using App4MultiWindow.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App4MultiWindow.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ICommand NextCommand { get; set; }

        public ICommand ClickCommand { get; set; }
        public ICommand ClickCommandUnit { get; set; }

        public List<Person> persons { get; set; }
        public string Title { get; set; }



        public MainPageViewModel()
        {
            NextCommand = new Command(NextCommandAction);

            Title = "";
            if (Device.RuntimePlatform == Device.UWP) Title = "Welcome on UWP";
            else if (Device.RuntimePlatform == Device.Android) Title = "Welcome on Androïde";

            if (Device.Idiom == TargetIdiom.Desktop) { Title += " We are on Desktop"; }
            else { Title += " We are not on Desktop" + Device.Idiom; }




            ClickCommand = new Command(ClickCommandAction);
            ClickCommandUnit = new Command(ClickCommandActionUnit);

            persons = new List<Person> {
                new Person { Name = "David", Surname = "Dupond" },
                new Person { Name = "Jo", Surname = "Marignant" },
                new Person { Name = "Ben", Surname = "Azer" },
                new Person { Name = "Chloé", Surname = "Grouu" }
            };

        }

        private void NextCommandAction(object obj)
        {
            var nav = AppContainer.Instance.Get<INav>();
            var nextView = AppContainer.Instance.Get<INext>();
            nav.Push(nextView);
        }

        private void ClickCommandActionUnit(object obj)
        {
            Person sender;
            if (obj != null)
            {
                sender = (Person)obj;
                if (sender != null)
                {
                    Person pers = persons.FirstOrDefault(p => p.Name == sender.Name);
                    pers.Surname += " The King!";
                    pers.OnPropertyChanged(nameof(pers.Surname));

                }
            }

        }

        private void ClickCommandAction(object obj)
        {
            foreach (Person item in persons)
            {
                item.Name += " J.";
                item.OnPropertyChanged("Name");

            }
        }

        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
