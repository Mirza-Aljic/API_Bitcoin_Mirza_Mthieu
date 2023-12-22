using API_Bitcoin.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;



using API_Bitcoin.Service;
using Newtonsoft.Json;
using RestSharp;

namespace API_Bitcoin.View
{
    /// <summary>
    /// Logique d'interaction pour PageCrypto.xaml
    /// </summary>
    public partial class PageCrypto : UserControl
    {

        private DispatcherTimer _timer;
        public CryptData BitcoinData { get; set; }
        public CryptData EthereumData { get; set; }
        public CryptData USDTData { get; set; }
        public CryptData SOLData { get; set; }


        public PageCrypto()
        {
            InitializeComponent();

            BitcoinData = new CryptData { name = "Bitcoin", priceChange1h = 2.5, priceChange1d = 1.5 }; // Valeurs statiques pour tester
            EthereumData = new CryptData { name = "Ethereum", priceChange1h = 1.2, priceChange1d = 0.8 }; // Valeurs statiques pour tester
            USDTData = new CryptData { name = "Tether", priceChange1h = 0.01, priceChange1d = -0.02 }; // Valeurs statiques pour tester
            SOLData = new CryptData { name = "Solana", priceChange1h = 0.5, priceChange1d = 0.2 }; // Valeurs statiques pour tester

            DataContext = this;

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMinutes(5) // Rafraîchir toutes les 5 minutes
            };
            _timer.Tick += Timer_Tick;
            _timer.Start();
            Task.Run(() => GetCryptoData()); // Appeler la méthode de manière asynchrone
        }


        public class Root
        {
            [JsonProperty("result")]
            public List<CryptData> Result { get; set; }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Task.Run(() => GetCryptoData()); // Appeler la méthode de manière asynchrone
        }

        public async Task GetCryptoData()
        {
            try
            {
                var client = new RestClient("https://openapiv1.coinstats.app/coins");
                var request = new RestRequest();
                request.AddHeader("accept", "application/json");
                request.AddHeader("X-API-KEY", "0qSRvDzjqVmDWRMnBiHkx/2v/wefOSm6q8WIUguCrEE="); // Assurez-vous d'utiliser votre clé API réelle
                var response = await client.GetAsync(request);

                // Désérialiser la réponse JSON
                var data = JsonConvert.DeserializeObject<Root>(response.Content);

                var bitcoin = data?.Result?.FirstOrDefault(coin => coin.name == "Bitcoin");
                var ethereum = data?.Result?.FirstOrDefault(coin => coin.name == "Ethereum");
                var usdt = data?.Result?.FirstOrDefault(coin => coin.name == "Tether");
                var sol = data?.Result?.FirstOrDefault(coin => coin.name == "Solana");

                if (bitcoin != null)
                {
                    Dispatcher.Invoke(() =>
                    {
                        BitcoinData.price = bitcoin.price;
                        BitcoinData.priceChange1h = bitcoin.priceChange1h;
                        BitcoinData.priceChange1d = bitcoin.priceChange1d;
                        BitcoinData.priceChange1w = bitcoin.priceChange1w;
                        BitcoinData.marketCap = bitcoin.marketCap;
                        BitcoinData.volume = bitcoin.volume;
                        BitcoinData.totalSupply = bitcoin.totalSupply;
                    });
                }

                if (ethereum != null)
                {
                    Dispatcher.Invoke(() =>
                    {
                        EthereumData.price = ethereum.price;
                        EthereumData.priceChange1h = ethereum.priceChange1h;
                        EthereumData.priceChange1d = ethereum.priceChange1d;
                        EthereumData.priceChange1w = ethereum.priceChange1w;
                        EthereumData.marketCap = ethereum.marketCap;
                        EthereumData.volume = ethereum.volume;
                        EthereumData.totalSupply = ethereum.totalSupply;
                    });
                }

                if (usdt != null)
                {
                    Dispatcher.Invoke(() =>
                    {
                        USDTData.price = usdt.price;
                        USDTData.priceChange1h = usdt.priceChange1h;
                        USDTData.priceChange1d = usdt.priceChange1d;
                        USDTData.priceChange1w = usdt.priceChange1w;
                        USDTData.marketCap = usdt.marketCap;
                        USDTData.volume = usdt.volume;
                        USDTData.totalSupply = usdt.totalSupply;
                    });
                }

                if (sol != null)
                {
                    Dispatcher.Invoke(() =>
                    {
                        SOLData.price = sol.price;
                        SOLData.priceChange1h = sol.priceChange1h;
                        SOLData.priceChange1d = sol.priceChange1d;
                        SOLData.priceChange1w = sol.priceChange1w;
                        SOLData.marketCap = sol.marketCap;
                        SOLData.volume = sol.volume;
                        SOLData.totalSupply = sol.totalSupply;
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite : {ex.Message}");
            }
        }
    }
}
