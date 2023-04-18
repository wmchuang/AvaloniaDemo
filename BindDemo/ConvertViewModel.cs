using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindDemo
{
    public class ConvertViewModel : INotifyPropertyChanged
    {
        private string _myText = "Hello";

        public event PropertyChangedEventHandler? PropertyChanged;

        public string MyText
        {
            get => _myText;
            set
            {
                _myText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyText"));
            }
        }
    }
}
