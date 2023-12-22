using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace API_Bitcoin.Service
{
    public class CryptData :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private double _price;
        private double _priceChange1h;
        private double _priceChange1d;
        private double _priceChange1w;
        private double _marketCap;
        private double _volume;
        private double _totalSupply;
        private string _name;

        public double price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }

        public double priceChange1h
        {
            get => _priceChange1h;
            set => SetProperty(ref _priceChange1h, value);
        }

        public double priceChange1d
        {
            get => _priceChange1d;
            set => SetProperty(ref _priceChange1d, value);
        }

        public double priceChange1w
        {
            get => _priceChange1w;
            set => SetProperty(ref _priceChange1w, value);
        }

        public double marketCap
        {
            get => _marketCap;
            set => SetProperty(ref _marketCap, value);
        }

        public double volume
        {
            get => _volume;
            set => SetProperty(ref _volume, value);
        }

        public double totalSupply
        {
            get => _totalSupply;
            set => SetProperty(ref _totalSupply, value);
        }

        public string name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
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
