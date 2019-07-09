using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace NICHandsOn.Model
{
   public class EntryViewModel : ObservablePattern
    {
        private ObservableCollection<AddRecrod> entryadd;
        public ObservableCollection<AddRecrod> EntryAdd
        {
            get
            {
                return entryadd;
            }
            set
            {
                if(entryadd!=value)
                {
                    entryadd = value;
                }
            }
        }

        public EntryViewModel()
        {
            entryadd = new ObservableCollection<AddRecrod>();
        }
    }
    public class AddRecrod : ObservablePattern
    {
        int _id;
        string _textvalue;
        public string TextValue
        {
            get { return _textvalue; }
            set
            {
                _textvalue = value;
                OnPropertyChanged();

            }
        }
        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();

            }
        }

    }
    public class ObservablePattern : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }

        }
        protected bool SetProperty<T>(ref T backingStore, T value,
           [CallerMemberName]string propertyName = "",
           Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
