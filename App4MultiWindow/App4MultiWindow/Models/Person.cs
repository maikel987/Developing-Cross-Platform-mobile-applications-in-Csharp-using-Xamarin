using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace App4MultiWindow.Models
{
    public class Person : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public override string ToString()
        {
            return string.Format("{0}  {1}", Name, Surname);
        }

        public void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
