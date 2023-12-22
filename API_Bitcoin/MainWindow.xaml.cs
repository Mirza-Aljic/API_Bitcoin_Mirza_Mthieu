using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

using API_Bitcoin.View;

namespace API_Bitcoin
{
    // Assurez-vous que la classe Result implémente INotifyPropertyChanged
    //public class CryptoData : INotifyPropertyChanged
    //{
    //    public event PropertyChangedEventHandler PropertyChanged;

    //    private double _price;
    //    private double _priceChange1h;
    //    private double _priceChange1d;
    //    private double _priceChange1w;
    //    private double _marketCap;
    //    private double _volume;
    //    private double _totalSupply;
    //    private string _name;

    //    public double price
    //    {
    //        get => _price;
    //        set => SetProperty(ref _price, value);
    //    }

    //    public double priceChange1h
    //    {
    //        get => _priceChange1h;
    //        set => SetProperty(ref _priceChange1h, value);
    //    }

    //    public double priceChange1d
    //    {
    //        get => _priceChange1d;
    //        set => SetProperty(ref _priceChange1d, value);
    //    }

    //    public double priceChange1w
    //    {
    //        get => _priceChange1w;
    //        set => SetProperty(ref _priceChange1w, value);
    //    }

    //    public double marketCap
    //    {
    //        get => _marketCap;
    //        set => SetProperty(ref _marketCap, value);
    //    }

    //    public double volume
    //    {
    //        get => _volume;
    //        set => SetProperty(ref _volume, value);
    //    }

    //    public double totalSupply
    //    {
    //        get => _totalSupply;
    //        set => SetProperty(ref _totalSupply, value);
    //    }

    //    public string name
    //    {
    //        get => _name;
    //        set => SetProperty(ref _name, value);
    //    }

    //    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //    }

    //    protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
    //    {
    //        if (EqualityComparer<T>.Default.Equals(backingStore, value))
    //            return false;

    //        backingStore = value;
    //        onChanged?.Invoke();
    //        OnPropertyChanged(propertyName);
    //        return true;
    //    }
    //}

    public partial class MainWindow : Window
    {
        //private DispatcherTimer _timer;
        //public CryptoData BitcoinData { get; set; }
        //public CryptoData EthereumData { get; set; }
        //public CryptoData USDTData { get; set; }
        //public CryptoData SOLData { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            displayCrypto();

            //BitcoinData = new CryptoData { name = "Bitcoin", priceChange1h = 2.5, priceChange1d = 1.5 }; // Valeurs statiques pour tester
            //EthereumData = new CryptoData { name = "Ethereum", priceChange1h = 1.2, priceChange1d = 0.8 }; // Valeurs statiques pour tester
            //USDTData = new CryptoData { name = "Tether", priceChange1h = 0.01, priceChange1d = -0.02 }; // Valeurs statiques pour tester
            //SOLData = new CryptoData { name = "Solana", priceChange1h = 0.5, priceChange1d = 0.2 }; // Valeurs statiques pour tester

            //DataContext = this;

            //_timer = new DispatcherTimer
            //{
            //    Interval = TimeSpan.FromMinutes(5) // Rafraîchir toutes les 5 minutes
            //};
            //_timer.Tick += Timer_Tick;
            //_timer.Start();
            //Task.Run(() => GetCryptoData()); // Appeler la méthode de manière asynchrone
        }

        //public class Root
        //{
        //    [JsonProperty("result")]
        //    public List<CryptoData> Result { get; set; }
        //}

        //private void Timer_Tick(object sender, EventArgs e)
        //{
        //    Task.Run(() => GetCryptoData()); // Appeler la méthode de manière asynchrone
        //}

        //public async Task GetCryptoData()
        //{
        //    try
        //    {
        //        var client = new RestClient("https://openapiv1.coinstats.app/coins");
        //        var request = new RestRequest();
        //        request.AddHeader("accept", "application/json");
        //        request.AddHeader("X-API-KEY", "0qSRvDzjqVmDWRMnBiHkx/2v/wefOSm6q8WIUguCrEE="); // Assurez-vous d'utiliser votre clé API réelle
        //        var response = await client.GetAsync(request);

        //        // Désérialiser la réponse JSON
        //        var data = JsonConvert.DeserializeObject<Root>(response.Content);

        //        var bitcoin = data?.Result?.FirstOrDefault(coin => coin.name == "Bitcoin");
        //        var ethereum = data?.Result?.FirstOrDefault(coin => coin.name == "Ethereum");
        //        var usdt = data?.Result?.FirstOrDefault(coin => coin.name == "Tether");
        //        var sol = data?.Result?.FirstOrDefault(coin => coin.name == "Solana");

        //        if (bitcoin != null)
        //        {
        //            Dispatcher.Invoke(() =>
        //            {
        //                BitcoinData.price = bitcoin.price;
        //                BitcoinData.priceChange1h = bitcoin.priceChange1h;
        //                BitcoinData.priceChange1d = bitcoin.priceChange1d;
        //                BitcoinData.priceChange1w = bitcoin.priceChange1w;
        //                BitcoinData.marketCap = bitcoin.marketCap;
        //                BitcoinData.volume = bitcoin.volume;
        //                BitcoinData.totalSupply = bitcoin.totalSupply;
        //            });
        //        }

        //        if (ethereum != null)
        //        {
        //            Dispatcher.Invoke(() =>
        //            {
        //                EthereumData.price = ethereum.price;
        //                EthereumData.priceChange1h = ethereum.priceChange1h;
        //                EthereumData.priceChange1d = ethereum.priceChange1d;
        //                EthereumData.priceChange1w = ethereum.priceChange1w;
        //                EthereumData.marketCap = ethereum.marketCap;
        //                EthereumData.volume = ethereum.volume;
        //                EthereumData.totalSupply = ethereum.totalSupply;
        //            });
        //        }

        //        if (usdt != null)
        //        {
        //            Dispatcher.Invoke(() =>
        //            {
        //                USDTData.price = usdt.price;
        //                USDTData.priceChange1h = usdt.priceChange1h;
        //                USDTData.priceChange1d = usdt.priceChange1d;
        //                USDTData.priceChange1w = usdt.priceChange1w;
        //                USDTData.marketCap = usdt.marketCap;
        //                USDTData.volume = usdt.volume;
        //                USDTData.totalSupply = usdt.totalSupply;
        //            });
        //        }

        //        if (sol != null)
        //        {
        //            Dispatcher.Invoke(() =>
        //            {
        //                SOLData.price = sol.price;
        //                SOLData.priceChange1h = sol.priceChange1h;
        //                SOLData.priceChange1d = sol.priceChange1d;
        //                SOLData.priceChange1w = sol.priceChange1w;
        //                SOLData.marketCap = sol.marketCap;
        //                SOLData.volume = sol.volume;
        //                SOLData.totalSupply = sol.totalSupply;
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Une erreur s'est produite : {ex.Message}");
        //    }
        //}

        private void BTN_Tendance_Click(object sender, RoutedEventArgs e)
        {
            Windows_Container.Children.Clear();
            Page_Tendance tendance = new Page_Tendance();
            Windows_Container.Children.Add(tendance);
        }

        private void BTN_IndexFear_Click(object sender, RoutedEventArgs e)
        {

            Windows_Container.Children.Clear();
            Page_Index index = new Page_Index();
            Windows_Container.Children.Add(index);
        }

        private void BTN_Acceuil_Click(object sender, RoutedEventArgs e)
        {
            //Windows_Container.Children.Clear();
            //API_Bitcoin.MainWindow acceuil = new API_Bitcoin.MainWindow();
            //Windows_Container.Children.Add(acceuil);
        }


        public void displayCrypto()
        {
            Windows_Container.Children.Clear();
            PageCrypto pageCrypto = new PageCrypto();
            Windows_Container.Children.Add(pageCrypto);
        }
    }
}