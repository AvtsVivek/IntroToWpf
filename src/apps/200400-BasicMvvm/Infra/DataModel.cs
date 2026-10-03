using System;
using System.ComponentModel;
using System.Diagnostics;

namespace BasicMvvm.Infra
{
    public class DataModel : IDataModel, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            VerifyPropertyName(propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [Conditional("DEBUG")]
        private void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
                throw new ArgumentNullException(GetType().Name + " does not contain property: " + propertyName);
        }

        private string _data;

        public string Data
        {
            get { return _data; }
            set
            {
                _data = value;
                OnPropertyChanged(nameof(Data));
            }
        }


        public string? Reverse()
        {
            char[] charArray = Data.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public DataModel()
        {
            Data = "";
        }

        public DataModel(string data)
        {
            Data = data;
        }
    }
}
